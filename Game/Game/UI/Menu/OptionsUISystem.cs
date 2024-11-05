// Decompiled with JetBrains decompiler
// Type: Game.UI.Menu.OptionsUISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.PSI.Common;
using Colossal.UI.Binding;
using Game.Input;
using Game.Modding.Toolchain;
using Game.PSI;
using Game.SceneFlow;
using Game.Settings;
using Game.UI.Editor;
using Game.UI.InGame;
using Game.UI.Localization;
using Game.UI.Widgets;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.Menu
{
  [CompilerGenerated]
  public class OptionsUISystem : UISystemBase
  {
    private const string kGroup = "options";
    private bool m_IsAdvanced;
    private string m_SearchQuery;
    private List<int> m_SearchIds;
    private string m_LastLayout;
    private ValueBinding<string> m_ActivePageBinding;
    private ValueBinding<string> m_ActiveSectionBinding;
    private GetterValueBinding<List<OptionsUISystem.Page>> m_PagesBinding;
    private WidgetBindings m_WidgetBindings;
    private ValueBinding<Dictionary<string, ControlPath>> m_LayoutMapBinding;
    private ValueBinding<bool> m_DirectoryBrowserActive;
    private WidgetBindings m_DirectoryBrowserBinding;
    private DirectoryBrowserPanel m_DirectoryBrowser;
    private DirectoryBrowserPanel m_LastDirectoryBrowser;
    private float m_DisplayConfirmationTime;
    private DisplayMode m_LastDisplayMode;
    private ScreenResolution m_LastResolution;

    public static void UpdateNotificationState(
      ModdingToolStatus toolStatus,
      DeploymentState deploymentState)
    {
      if (toolStatus != ModdingToolStatus.Idle)
      {
        NotificationSystem.Pop("ToolchainStatus");
      }
      else
      {
        if (deploymentState != DeploymentState.Outdated && deploymentState != DeploymentState.Invalid)
          return;
        NotificationSystem.Push("ToolchainStatus", titleId: "ActionRequired", textId: "ToolchainStatus" + deploymentState.ToString(), progressState: new ProgressState?(ProgressState.Warning), onClicked: (Action) (() => ToolchainDeployment.RunWithUI(DeploymentAction.Install)));
      }
    }

    private async void QueryToolchainState()
    {
      try
      {
        // ISSUE: reference to a compiler-generated method
        OptionsUISystem.UpdateNotificationState(ModdingToolStatus.Idle, (DeploymentState) await ToolchainDeployment.dependencyManager.GetCurrentState());
      }
      catch (Exception ex)
      {
        UISystemBase.log.Error(ex, (object) "Toolchain state query failed");
      }
    }

    private void OnModdingToolchainStateChanged(ToolchainDependencyManager.State newState)
    {
      // ISSUE: reference to a compiler-generated method
      GameManager.instance.RunOnMainThread((Action) (() => OptionsUISystem.UpdateNotificationState(newState.m_Status, newState.m_State)));
    }

    public void OpenDirectoryBrowser(string root, Action<string> onSelect)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.m_DirectoryBrowser != null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.m_DirectoryBrowser = new DirectoryBrowserPanel(root, (string) null, (DirectoryBrowserPanel.SelectCallback) (directory =>
      {
        Action<string> action = onSelect;
        if (action != null)
          action(directory);
        // ISSUE: reference to a compiler-generated method
        this.OnCancelDirectory();
      }), (Action) (() =>
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_DirectoryBrowser == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.m_DirectoryBrowser = (DirectoryBrowserPanel) null;
      }));
    }

    private void OnCancelDirectory()
    {
      // ISSUE: reference to a compiler-generated field
      if (this.m_DirectoryBrowser == null)
        return;
      // ISSUE: reference to a compiler-generated field
      this.m_DirectoryBrowser = (DirectoryBrowserPanel) null;
    }

    private void SwitchBindings(bool browserActive)
    {
      // ISSUE: reference to a compiler-generated field
      foreach (IBinding binding in this.m_WidgetBindings.bindings)
      {
        if (binding is RawTriggerBindingBase triggerBindingBase)
          triggerBindingBase.active = !browserActive;
      }
      // ISSUE: reference to a compiler-generated field
      foreach (IBinding binding in this.m_DirectoryBrowserBinding.bindings)
      {
        if (binding is RawTriggerBindingBase triggerBindingBase)
          triggerBindingBase.active = browserActive;
      }
    }

    private Dictionary<string, OptionsUISystem.Page> pages { get; } = new Dictionary<string, OptionsUISystem.Page>();

    private List<OptionsUISystem.Page> sortedPages
    {
      get
      {
        return this.pages.Values.OrderByDescending<OptionsUISystem.Page, bool>((Func<OptionsUISystem.Page, bool>) (p => p.builtIn)).ThenBy<OptionsUISystem.Page, int>((Func<OptionsUISystem.Page, int>) (p => p.index)).ToList<OptionsUISystem.Page>();
      }
    }

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.AddUpdateBinding((IUpdateBinding) (this.m_WidgetBindings = new WidgetBindings("options")));
      // ISSUE: reference to a compiler-generated field
      this.m_WidgetBindings.AddDefaultBindings();
      // ISSUE: reference to a compiler-generated field
      this.m_WidgetBindings.AddBindings<InputBindingField.Bindings>();
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) (this.m_ActivePageBinding = new ValueBinding<string>("options", "activePage", string.Empty)));
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) (this.m_ActiveSectionBinding = new ValueBinding<string>("options", "activeSection", string.Empty)));
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) (this.m_PagesBinding = new GetterValueBinding<List<OptionsUISystem.Page>>("options", "pages", (Func<List<OptionsUISystem.Page>>) (() => this.sortedPages), (IWriter<List<OptionsUISystem.Page>>) new ListWriter<OptionsUISystem.Page>((IWriter<OptionsUISystem.Page>) new ValueWriter<OptionsUISystem.Page>()))));
      // ISSUE: reference to a compiler-generated field
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<bool>("options", "displayConfirmationVisible", (Func<bool>) (() => (double) this.m_DisplayConfirmationTime > 0.0)));
      // ISSUE: reference to a compiler-generated field
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<int>("options", "displayConfirmationTime", (Func<int>) (() => Mathf.Max(Mathf.CeilToInt(this.m_DisplayConfirmationTime), 0))));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<string>("options", "interfaceStyle", (Func<string>) (() => SharedSettings.instance.userInterface.interfaceStyle)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<float>("options", "interfaceTransparency", (Func<float>) (() => SharedSettings.instance.userInterface.interfaceTransparency)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<bool>("options", "interfaceScaling", (Func<bool>) (() => SharedSettings.instance.userInterface.interfaceScaling)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<float>("options", "textScale", (Func<float>) (() => SharedSettings.instance.userInterface.textScale)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<string>("options", "interfaceStyle", (Func<string>) (() => SharedSettings.instance.userInterface.interfaceStyle)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<bool>("options", "unlockHighlightsEnabled", (Func<bool>) (() => SharedSettings.instance.userInterface.unlockHighlightsEnabled)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<bool>("options", "chirperPopupsEnabled", (Func<bool>) (() => SharedSettings.instance.userInterface.chirperPopupsEnabled)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<int>("options", "inputHintsType", (Func<int>) (() => (int) SharedSettings.instance.userInterface.GetFinalInputHintsType())));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<int>("options", "keyboardLayout", (Func<int>) (() => (int) SharedSettings.instance.userInterface.keyboardLayout)));
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<bool>("options", "shortcutHints", (Func<bool>) (() => SharedSettings.instance.userInterface.shortcutHints)));
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) (this.m_LayoutMapBinding = new ValueBinding<Dictionary<string, ControlPath>>("options", "layoutMap", new Dictionary<string, ControlPath>(), (IWriter<Dictionary<string, ControlPath>>) new DictionaryWriter<string, ControlPath>(valueWriter: (IWriter<ControlPath>) new ValueWriter<ControlPath>()))));
      // ISSUE: object of a compiler-generated type is created
      this.AddUpdateBinding((IUpdateBinding) new GetterValueBinding<OptionsUISystem.UnitSettings>("options", "unitSettings", (Func<OptionsUISystem.UnitSettings>) (() => new OptionsUISystem.UnitSettings(SharedSettings.instance.userInterface)), (IWriter<OptionsUISystem.UnitSettings>) new ValueWriter<OptionsUISystem.UnitSettings>()));
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) new TriggerBinding("options", "confirmDisplay", (Action) (() => this.m_DisplayConfirmationTime = -1f)));
      this.AddBinding((IBinding) new TriggerBinding("options", "revertDisplay", (Action) (() =>
      {
        // ISSUE: reference to a compiler-generated field
        this.m_DisplayConfirmationTime = -1f;
        // ISSUE: reference to a compiler-generated field
        SharedSettings.instance.graphics.resolution = this.m_LastResolution;
        // ISSUE: reference to a compiler-generated field
        SharedSettings.instance.graphics.displayMode = this.m_LastDisplayMode;
        SharedSettings.instance.graphics.ApplyAndSave();
      })));
      this.AddBinding((IBinding) new TriggerBinding<string>("options", "onOptionsPageClosed", (Action<string>) (pageId =>
      {
        if (!(pageId == "Graphics"))
          return;
        Telemetry.GraphicsSettings();
      })));
      this.AddBinding((IBinding) new TriggerBinding<string, string, bool>("options", "selectPage", (Action<string, string, bool>) ((pageID, sectionID, isAdvanced) =>
      {
        // ISSUE: reference to a compiler-generated field
        this.m_IsAdvanced = isAdvanced;
        // ISSUE: reference to a compiler-generated method
        this.SelectSection(pageID, sectionID);
      })));
      this.AddBinding((IBinding) new TriggerBinding<List<int>, string>("options", "filteredWidgets", (Action<List<int>, string>) ((ids, query) =>
      {
        // ISSUE: reference to a compiler-generated field
        this.m_SearchQuery = query;
        // ISSUE: reference to a compiler-generated field
        this.m_SearchIds = ids.Distinct<int>().ToList<int>();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.SelectSection(this.m_ActivePageBinding.value, this.m_ActiveSectionBinding.value);
      }), (IReader<List<int>>) new ListReader<int>()));
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) new TriggerBinding("options", "toolchain.dependency.action", (Action) (() => this.m_DisplayConfirmationTime = -1f)));
      // ISSUE: reference to a compiler-generated field
      this.AddUpdateBinding((IUpdateBinding) (this.m_DirectoryBrowserBinding = new WidgetBindings("options", "directoryBrowser")));
      // ISSUE: reference to a compiler-generated field
      this.m_DirectoryBrowserBinding.AddDefaultBindings();
      // ISSUE: reference to a compiler-generated field
      this.m_DirectoryBrowserBinding.AddBindings<IItemPicker.Bindings>();
      // ISSUE: reference to a compiler-generated field
      this.AddBinding((IBinding) (this.m_DirectoryBrowserActive = new ValueBinding<bool>("options", "directoryBrowserActive", false)));
      this.AddBinding((IBinding) new TriggerBinding("options", "cancelDirectoryBrowser", (Action) (() =>
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_DirectoryBrowser == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.m_DirectoryBrowser = (DirectoryBrowserPanel) null;
      })));
      // ISSUE: reference to a compiler-generated method
      this.SwitchBindings(false);
      // ISSUE: reference to a compiler-generated method
      this.SelectDefaultPage();
      // ISSUE: reference to a compiler-generated method
      this.QueryToolchainState();
      // ISSUE: reference to a compiler-generated method
      ToolchainDeployment.dependencyManager.OnStateChanged += (Action<ToolchainDependencyManager.State>) (newState => GameManager.instance.RunOnMainThread((Action) (() => OptionsUISystem.UpdateNotificationState(newState.m_Status, newState.m_State))));
    }

    [Preserve]
    protected override void OnDestroy()
    {
      base.OnDestroy();
      // ISSUE: reference to a compiler-generated method
      ToolchainDeployment.dependencyManager.OnStateChanged -= (Action<ToolchainDependencyManager.State>) (newState => GameManager.instance.RunOnMainThread((Action) (() => OptionsUISystem.UpdateNotificationState(newState.m_Status, newState.m_State))));
    }

    public void RegisterSetting(Setting setting, string id, bool addPrefix = false)
    {
      bool flag = this.pages.Count == 0;
      // ISSUE: variable of a compiler-generated type
      OptionsUISystem.Page page1 = setting.GetPageData(id, addPrefix).BuildPage();
      page1.builtIn = setting.builtIn;
      // ISSUE: variable of a compiler-generated type
      OptionsUISystem.Page page2;
      page1.index = !this.pages.TryGetValue(page1.id, out page2) ? this.pages.Count : page2.index;
      for (int index = 0; index < page1.sections.Count; ++index)
        page1.sections[index].index = index;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      page1.UpdateVisibility(this.m_IsAdvanced);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      page1.UpdateNameAndDescription(this.m_IsAdvanced);
      this.pages[page1.id] = page1;
      if (flag && page1.sections.Count != 0)
      {
        // ISSUE: reference to a compiler-generated method
        this.SelectVisibleSection(page1);
      }
      // ISSUE: reference to a compiler-generated field
      this.m_PagesBinding.Update();
      // ISSUE: reference to a compiler-generated method
      this.RefreshPage();
    }

    public void UnregisterSettings(string id)
    {
      this.pages.Remove(id);
      // ISSUE: reference to a compiler-generated field
      if (this.m_ActivePageBinding.value == id && this.pages.Count != 0)
      {
        // ISSUE: reference to a compiler-generated method
        this.SelectVisibleSection(this.pages.Values.First<OptionsUISystem.Page>());
      }
      // ISSUE: reference to a compiler-generated field
      this.m_PagesBinding.Update();
      // ISSUE: reference to a compiler-generated method
      this.RefreshPage();
    }

    private void SelectSection(string pageID, string sectionID, bool isAdvanced)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_IsAdvanced = isAdvanced;
      // ISSUE: reference to a compiler-generated method
      this.SelectSection(pageID, sectionID);
    }

    private void SelectSection(string pageID, string sectionID)
    {
      // ISSUE: reference to a compiler-generated field
      if (this.m_SearchQuery != null)
      {
        // ISSUE: reference to a compiler-generated method
        this.FilterWidgets();
      }
      else
      {
        // ISSUE: variable of a compiler-generated type
        OptionsUISystem.Page page;
        if (this.pages.TryGetValue(pageID, out page))
        {
          // ISSUE: variable of a compiler-generated type
          OptionsUISystem.Section section = page.visibleSections.FirstOrDefault<OptionsUISystem.Section>((Func<OptionsUISystem.Section, bool>) (s => s.id == sectionID));
          if (section != null)
          {
            // ISSUE: reference to a compiler-generated method
            this.SelectSection(page, section);
          }
          else
          {
            // ISSUE: reference to a compiler-generated method
            this.SelectVisibleSection(page);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated method
          this.SelectDefaultPage();
        }
      }
    }

    private void FilterWidgets(List<int> ids, string query)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_SearchQuery = query;
      // ISSUE: reference to a compiler-generated field
      this.m_SearchIds = ids.Distinct<int>().ToList<int>();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.SelectSection(this.m_ActivePageBinding.value, this.m_ActiveSectionBinding.value);
    }

    private void FilterWidgets()
    {
      List<IWidget> widgetList = new List<IWidget>();
      int num1 = -1;
      int num2 = -1;
      int num3 = -1;
      List<OptionsUISystem.Page> sortedPages = this.sortedPages;
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < this.m_SearchIds.Count; ++index)
      {
        int page1;
        int section1;
        int widget;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        OptionsUISystem.WidgetInfo.GetIndices(this.m_SearchIds[index], out page1, out section1, out widget);
        if (page1 < sortedPages.Count)
        {
          bool flag1 = page1 != num1;
          if (flag1)
            num2 = -1;
          // ISSUE: variable of a compiler-generated type
          OptionsUISystem.Page page2 = sortedPages[page1];
          if (section1 < page2.sections.Count)
          {
            bool flag2 = section1 != num2;
            if (flag2)
              num3 = -1;
            // ISSUE: variable of a compiler-generated type
            OptionsUISystem.Section section2 = page2.sections[section1];
            if (widget < section2.options.Count)
            {
              // ISSUE: variable of a compiler-generated type
              OptionsUISystem.Option option = section2.options[widget];
              if (!option.searchHidden && option.isVisible)
              {
                string groupName = section2.groupNames[option.advancedGroupIndex];
                bool flag3 = option.advancedGroupIndex != num3;
                if (flag1 | flag2 | flag3)
                {
                  Breadcrumbs breadcrumbs = new Breadcrumbs();
                  Label label1 = new Label();
                  label1.displayName = LocalizedString.Id("Options.SECTION[" + page2.id + "]");
                  label1.level = Label.Level.Title;
                  label1.beta = BetaFilter.options.Contains<string>(page2.id);
                  Label label2 = label1;
                  breadcrumbs.WithLabel(label2);
                  if (page2.sections.Count > 1)
                  {
                    Label label3 = new Label();
                    label3.displayName = LocalizedString.Id("Options.TAB[" + section2.id + "]");
                    label3.level = Label.Level.SubTitle;
                    label3.beta = BetaFilter.options.Contains<string>(section2.id);
                    Label label4 = label3;
                    breadcrumbs.WithLabel(label4);
                  }
                  if (section2.groupNames.Length > 1 && section2.groupToShowName.Contains(groupName))
                  {
                    // ISSUE: reference to a compiler-generated method
                    Label label5 = OptionsUISystem.BuildGroupLabel(page2.id, groupName);
                    breadcrumbs.WithLabel(label5);
                  }
                  widgetList.Add((IWidget) breadcrumbs);
                }
                widgetList.Add(option.widget);
                num1 = page1;
                num2 = section1;
                num3 = option.advancedGroupIndex;
              }
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      this.m_WidgetBindings.children = (IList<IWidget>) widgetList;
    }

    private void SelectVisibleSection(OptionsUISystem.Page page)
    {
      // ISSUE: reference to a compiler-generated method
      this.SelectSection(page, page.visibleSections.FirstOrDefault<OptionsUISystem.Section>());
    }

    private void SelectSection(
      OptionsUISystem.Page page,
      OptionsUISystem.Section section,
      bool isAdvanced)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_IsAdvanced = isAdvanced;
      // ISSUE: reference to a compiler-generated method
      this.SelectSection(page, section);
    }

    private void SelectSection(OptionsUISystem.Page page, OptionsUISystem.Section section)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_ActivePageBinding.Update(page?.id ?? string.Empty);
      // ISSUE: reference to a compiler-generated field
      this.m_ActiveSectionBinding.Update(section?.id ?? string.Empty);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_WidgetBindings.children = (IList<IWidget>) section.GetItems(this.m_IsAdvanced);
    }

    private void RefreshPage()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.SelectSection(this.m_ActivePageBinding.value, this.m_ActiveSectionBinding.value);
    }

    private void SelectDefaultPage()
    {
      foreach (OptionsUISystem.Page page in this.pages.Values)
      {
        foreach (OptionsUISystem.Section section in page.sections)
        {
          if (section.isVisible)
          {
            // ISSUE: reference to a compiler-generated method
            this.SelectSection(page, section);
            return;
          }
        }
      }
    }

    public void OpenPage(string pageID, string sectionID, bool isAdvanced)
    {
      switch (GameManager.instance.gameMode)
      {
        case GameMode.Game:
        case GameMode.Editor:
          GameScreenUISystem systemManaged1 = this.World.GetOrCreateSystemManaged<GameScreenUISystem>();
          if (systemManaged1 == null)
            break;
          systemManaged1.OpenScreen(GameScreenUISystem.GameScreen.Options);
          // ISSUE: reference to a compiler-generated method
          this.SelectSection(pageID, sectionID, isAdvanced);
          break;
        case GameMode.MainMenu:
          // ISSUE: variable of a compiler-generated type
          MenuUISystem systemManaged2 = this.World.GetOrCreateSystemManaged<MenuUISystem>();
          if (systemManaged2 == null)
            break;
          // ISSUE: reference to a compiler-generated method
          systemManaged2.OpenScreen(MenuUISystem.MenuScreen.Options);
          // ISSUE: reference to a compiler-generated method
          this.SelectSection(pageID, sectionID, isAdvanced);
          break;
      }
    }

    [Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated field
      if (!string.IsNullOrEmpty(this.m_SearchQuery))
      {
        bool flag = false;
        foreach (OptionsUISystem.Page page in this.pages.Values)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          flag |= page.UpdateVisibility(this.m_IsAdvanced);
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          flag |= page.UpdateNameAndDescription(this.m_IsAdvanced);
        }
        if (flag)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_PagesBinding.Update();
        }
      }
      else
      {
        // ISSUE: variable of a compiler-generated type
        OptionsUISystem.Page page;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        if (this.pages.TryGetValue(this.m_ActivePageBinding.value, out page) && page.UpdateVisibility(this.m_IsAdvanced))
        {
          // ISSUE: reference to a compiler-generated field
          this.m_PagesBinding.Update();
          // ISSUE: reference to a compiler-generated field
          // ISSUE: variable of a compiler-generated type
          OptionsUISystem.Section section = page.sections.FirstOrDefault<OptionsUISystem.Section>((Func<OptionsUISystem.Section, bool>) (s => s.id == this.m_ActiveSectionBinding.value));
          if (section != null && !section.isVisible)
          {
            // ISSUE: reference to a compiler-generated method
            this.RefreshPage();
          }
        }
      }
      base.OnUpdate();
      // ISSUE: reference to a compiler-generated field
      if ((double) this.m_DisplayConfirmationTime > 0.0)
      {
        // ISSUE: reference to a compiler-generated field
        this.m_DisplayConfirmationTime -= UnityEngine.Time.deltaTime;
        // ISSUE: reference to a compiler-generated field
        if ((double) this.m_DisplayConfirmationTime <= 0.0)
        {
          // ISSUE: reference to a compiler-generated method
          this.RevertDisplay();
        }
      }
      // ISSUE: reference to a compiler-generated field
      if (this.m_DirectoryBrowser != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.m_DirectoryBrowserActive.Update(true);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.m_DirectoryBrowserBinding.children = this.m_DirectoryBrowser.children;
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        this.m_DirectoryBrowserActive.Update(false);
        // ISSUE: reference to a compiler-generated field
        this.m_DirectoryBrowserBinding.children = (IList<IWidget>) Array.Empty<IWidget>();
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (this.m_LastDirectoryBrowser != this.m_DirectoryBrowser)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.SwitchBindings(this.m_DirectoryBrowser != null);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.m_LastDirectoryBrowser = this.m_DirectoryBrowser;
      }
      string keyboardLayout = SharedSettings.instance.userInterface.keyboardLayout == InterfaceSettings.KeyboardLayout.AutoDetect ? Keyboard.current?.keyboardLayout : (string) null;
      // ISSUE: reference to a compiler-generated field
      if (!(keyboardLayout != this.m_LastLayout))
        return;
      // ISSUE: reference to a compiler-generated field
      this.m_LastLayout = keyboardLayout;
      Dictionary<string, ControlPath> newValue = new Dictionary<string, ControlPath>();
      Keyboard current = Keyboard.current;
      // ISSUE: reference to a compiler-generated field
      if (this.m_LastLayout != null && current != null)
      {
        foreach (KeyControl allKey in current.allKeys)
        {
          KeyControl key = allKey;
          if (ControlPath.NeedLocalName(current, key))
          {
            InputControl inputControl = current.allControls.FirstOrDefault<InputControl>((Func<InputControl, bool>) (c =>
            {
              string displayName = c.displayName;
              return c.m_DisplayNameFromLayout == key.displayName;
            }));
            ControlPath controlPath1;
            if (inputControl == null)
            {
              Dictionary<string, ControlPath> dictionary = newValue;
              string name = key.name;
              controlPath1 = new ControlPath();
              controlPath1.name = key.displayName;
              controlPath1.displayName = key.displayName;
              ControlPath controlPath2 = controlPath1;
              dictionary[name] = controlPath2;
            }
            else if (key.name != inputControl.name)
            {
              Dictionary<string, ControlPath> dictionary = newValue;
              string name = key.name;
              controlPath1 = new ControlPath();
              controlPath1.name = inputControl.name;
              controlPath1.displayName = inputControl.name.Length == 1 ? inputControl.name.ToUpper() : inputControl.name;
              ControlPath controlPath3 = controlPath1;
              dictionary[name] = controlPath3;
            }
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      this.m_LayoutMapBinding.Update(newValue);
    }

    public void ShowDisplayConfirmation()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_DisplayConfirmationTime = 15f;
      // ISSUE: reference to a compiler-generated field
      this.m_LastResolution = SharedSettings.instance.graphics.resolution;
      // ISSUE: reference to a compiler-generated field
      this.m_LastDisplayMode = SharedSettings.instance.graphics.displayMode;
    }

    private void ConfirmDisplay() => this.m_DisplayConfirmationTime = -1f;

    private void RevertDisplay()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_DisplayConfirmationTime = -1f;
      // ISSUE: reference to a compiler-generated field
      SharedSettings.instance.graphics.resolution = this.m_LastResolution;
      // ISSUE: reference to a compiler-generated field
      SharedSettings.instance.graphics.displayMode = this.m_LastDisplayMode;
      SharedSettings.instance.graphics.ApplyAndSave();
    }

    private void OnPageClosed(string pageId)
    {
      if (!(pageId == "Graphics"))
        return;
      Telemetry.GraphicsSettings();
    }

    private static Label BuildGroupLabel(string pageId, string groupId)
    {
      string str = pageId + "." + groupId;
      Label label = new Label();
      label.displayName = LocalizedString.Id("Options.GROUP[" + str + "]");
      label.level = Label.Level.SubTitle;
      label.beta = BetaFilter.options.Contains<string>(str);
      return label;
    }

    [Preserve]
    public OptionsUISystem()
    {
    }

    [DebuggerDisplay("{id}")]
    public class Page : IJsonWritable
    {
      internal bool builtIn { get; set; }

      public string id { get; set; }

      public int index { get; set; }

      public bool beta { get; set; }

      [NotNull]
      public List<OptionsUISystem.Section> sections { get; } = new List<OptionsUISystem.Section>();

      public ReadOnlyCollection<OptionsUISystem.Section> visibleSections
      {
        get
        {
          return new ReadOnlyCollection<OptionsUISystem.Section>((IList<OptionsUISystem.Section>) this.sections.Where<OptionsUISystem.Section>((Func<OptionsUISystem.Section, bool>) (s => s.isVisible)).ToArray<OptionsUISystem.Section>());
        }
      }

      public bool UpdateVisibility(bool isAdvanced)
      {
        bool flag = false;
        foreach (OptionsUISystem.Section section in this.sections)
        {
          // ISSUE: reference to a compiler-generated method
          flag |= section.UpdateVisibility(isAdvanced);
        }
        return flag;
      }

      public bool UpdateNameAndDescription(bool isAdvanced)
      {
        bool flag = false;
        foreach (OptionsUISystem.Section section in this.sections)
        {
          if (section.isVisible)
          {
            // ISSUE: reference to a compiler-generated method
            flag |= section.UpdateNameAndDescription(isAdvanced);
          }
        }
        return flag;
      }

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin(this.GetType().FullName);
        writer.PropertyName("id");
        writer.Write(this.id);
        writer.PropertyName("sections");
        writer.Write<OptionsUISystem.Section>((IList<OptionsUISystem.Section>) this.sections);
        writer.PropertyName("beta");
        writer.Write(this.beta);
        writer.PropertyName("builtIn");
        writer.Write(this.builtIn);
        writer.TypeEnd();
      }
    }

    [DebuggerDisplay("{id}")]
    public class Section : IJsonWritable
    {
      public OptionsUISystem.Page page { get; }

      public string id { get; set; }

      public int index { get; set; }

      public string[] groupNames { get; }

      public HashSet<string> groupToShowName { get; }

      private Dictionary<int, bool> groupVisible { get; set; } = new Dictionary<int, bool>();

      private Dictionary<int, bool> prevGroupVisible { get; set; } = new Dictionary<int, bool>();

      [NotNull]
      public List<OptionsUISystem.Option> options { get; } = new List<OptionsUISystem.Option>();

      public bool isVisible { get; private set; }

      public Section(
        string id,
        OptionsUISystem.Page page,
        AutomaticSettings.SettingPageData pageData)
      {
        this.page = page;
        this.id = id;
        this.groupNames = pageData.groupNames.ToArray<string>();
        this.groupToShowName = new HashSet<string>(pageData.groupToShowName);
      }

      public List<IWidget> GetItems(bool isAdvanced)
      {
        List<IWidget> items = new List<IWidget>();
        int num = -1;
        foreach (OptionsUISystem.Option option in isAdvanced ? (IEnumerable<OptionsUISystem.Option>) this.options.OrderBy<OptionsUISystem.Option, int>((Func<OptionsUISystem.Option, int>) (o => o.advancedGroupIndex)) : (IEnumerable<OptionsUISystem.Option>) this.options.Where<OptionsUISystem.Option>((Func<OptionsUISystem.Option, bool>) (o => !o.isAdvanced)).OrderBy<OptionsUISystem.Option, int>((Func<OptionsUISystem.Option, int>) (o => o.simpleGroupIndex)))
        {
          if (option.isVisible)
          {
            int index = isAdvanced ? option.advancedGroupIndex : option.simpleGroupIndex;
            if (num != index)
            {
              Breadcrumbs breadcrumbs = new Breadcrumbs();
              if (this.groupNames != null && index < this.groupNames.Length)
              {
                string groupName = this.groupNames[index];
                if (this.groupToShowName.Contains(groupName))
                {
                  // ISSUE: reference to a compiler-generated method
                  Label label = OptionsUISystem.BuildGroupLabel(this.page.id, groupName);
                  breadcrumbs.WithLabel(label);
                }
                items.Add((IWidget) breadcrumbs);
              }
            }
            items.Add(option.widget);
            num = index;
          }
        }
        return items;
      }

      public bool UpdateVisibility(bool isAdvanced)
      {
        bool flag1 = false;
        this.groupVisible = (this.prevGroupVisible = this.groupVisible) = this.prevGroupVisible;
        this.groupVisible.Clear();
        foreach (OptionsUISystem.Option option in this.options)
        {
          if (option.widget is Widget widget)
          {
            int num = (int) widget.UpdateVisibility();
            option.isVisible = widget.isVisible;
            if (isAdvanced || !option.isAdvanced)
            {
              flag1 |= option.isVisible;
              int key = isAdvanced ? option.advancedGroupIndex : option.simpleGroupIndex;
              bool flag2;
              this.groupVisible.TryGetValue(key, out flag2);
              this.groupVisible[key] = flag2 || option.isVisible;
            }
          }
        }
        if (this.isVisible != flag1)
        {
          this.isVisible = flag1;
          return true;
        }
        bool flag3;
        return this.groupVisible.Any<KeyValuePair<int, bool>>((Func<KeyValuePair<int, bool>, bool>) (g => !this.prevGroupVisible.TryGetValue(g.Key, out flag3) || flag3 != g.Value));
      }

      public bool UpdateNameAndDescription(bool isAdvanced)
      {
        WidgetChanges widgetChanges = WidgetChanges.None;
        foreach (NamedWidget namedWidget in this.options.Where<OptionsUISystem.Option>((Func<OptionsUISystem.Option, bool>) (o => isAdvanced || !o.isAdvanced)).Select<OptionsUISystem.Option, IWidget>((Func<OptionsUISystem.Option, IWidget>) (o => o.widget)).OfType<NamedWidget>())
        {
          if (namedWidget.isVisible)
            widgetChanges |= namedWidget.UpdateNameAndDescription();
        }
        return (widgetChanges & WidgetChanges.Properties) != 0;
      }

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin(this.GetType().FullName);
        writer.PropertyName("id");
        writer.Write(this.id);
        writer.PropertyName("isVisible");
        writer.Write(this.isVisible);
        List<OptionsUISystem.WidgetInfo> widgetInfoList1 = new List<OptionsUISystem.WidgetInfo>();
        for (int index = 0; index < this.options.Count; ++index)
        {
          // ISSUE: variable of a compiler-generated type
          OptionsUISystem.Option option = this.options[index];
          // ISSUE: variable of a compiler-generated type
          OptionsUISystem.WidgetInfo widgetInfo1;
          if (option.widget is INamed widget2)
          {
            List<OptionsUISystem.WidgetInfo> widgetInfoList2 = widgetInfoList1;
            // ISSUE: object of a compiler-generated type is created
            widgetInfo1 = new OptionsUISystem.WidgetInfo();
            // ISSUE: reference to a compiler-generated method
            widgetInfo1.id = OptionsUISystem.WidgetInfo.GetId(this.page.index, this.index, index);
            widgetInfo1.displayName = widget2.displayName;
            widgetInfo1.isVisible = option.isVisible;
            widgetInfo1.isAdvanced = option.isAdvanced;
            widgetInfo1.searchHidden = option.searchHidden;
            // ISSUE: variable of a compiler-generated type
            OptionsUISystem.WidgetInfo widgetInfo2 = widgetInfo1;
            widgetInfoList2.Add(widgetInfo2);
          }
          else if (option.widget is ButtonRow widget1)
          {
            foreach (Button child in widget1.children)
            {
              List<OptionsUISystem.WidgetInfo> widgetInfoList3 = widgetInfoList1;
              // ISSUE: object of a compiler-generated type is created
              widgetInfo1 = new OptionsUISystem.WidgetInfo();
              // ISSUE: reference to a compiler-generated method
              widgetInfo1.id = OptionsUISystem.WidgetInfo.GetId(this.page.index, this.index, index);
              widgetInfo1.displayName = child.displayName;
              widgetInfo1.isVisible = option.isVisible;
              widgetInfo1.isAdvanced = option.isAdvanced;
              widgetInfo1.searchHidden = option.searchHidden;
              // ISSUE: variable of a compiler-generated type
              OptionsUISystem.WidgetInfo widgetInfo3 = widgetInfo1;
              widgetInfoList3.Add(widgetInfo3);
            }
          }
        }
        writer.PropertyName("items");
        writer.Write<OptionsUISystem.WidgetInfo>((IList<OptionsUISystem.WidgetInfo>) widgetInfoList1);
        writer.TypeEnd();
      }
    }

    [DebuggerDisplay("{widget}, isAdvanced={isAdvanced}")]
    public class Option
    {
      public IWidget widget { get; set; }

      public bool isVisible { get; set; }

      public bool isAdvanced { get; set; }

      public int simpleGroupIndex { get; set; }

      public int advancedGroupIndex { get; set; }

      public bool searchHidden { get; set; }
    }

    public struct WidgetInfo : IJsonWritable
    {
      public int id { get; set; }

      public LocalizedString displayName { get; set; }

      public bool isVisible { get; set; }

      public bool isAdvanced { get; set; }

      public bool searchHidden { get; set; }

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin(this.GetType().FullName);
        writer.PropertyName("id");
        writer.Write(this.id);
        writer.PropertyName("displayName");
        writer.Write<LocalizedString>(this.displayName);
        writer.PropertyName("isVisible");
        writer.Write(this.isVisible);
        writer.PropertyName("isAdvanced");
        writer.Write(this.isAdvanced);
        writer.PropertyName("searchHidden");
        writer.Write(this.searchHidden);
        writer.TypeEnd();
      }

      public static int GetId(int page, int section, int widget)
      {
        return ((page & (int) ushort.MaxValue) << 16) + ((section & (int) byte.MaxValue) << 8) + (widget & (int) byte.MaxValue);
      }

      public static void GetIndices(int id, out int page, out int section, out int widget)
      {
        page = id >> 16 & (int) ushort.MaxValue;
        section = id >> 8 & (int) byte.MaxValue;
        widget = id & (int) byte.MaxValue;
      }
    }

    public struct UnitSettings : IJsonWritable, IEquatable<OptionsUISystem.UnitSettings>
    {
      public InterfaceSettings.TimeFormat timeFormat;
      public InterfaceSettings.TemperatureUnit temperatureUnit;
      public InterfaceSettings.UnitSystem unitSystem;

      public UnitSettings(InterfaceSettings settings)
      {
        // ISSUE: reference to a compiler-generated field
        this.timeFormat = settings.timeFormat;
        // ISSUE: reference to a compiler-generated field
        this.temperatureUnit = settings.temperatureUnit;
        // ISSUE: reference to a compiler-generated field
        this.unitSystem = settings.unitSystem;
      }

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin(this.GetType().FullName);
        writer.PropertyName("timeFormat");
        // ISSUE: reference to a compiler-generated field
        writer.Write((int) this.timeFormat);
        writer.PropertyName("temperatureUnit");
        // ISSUE: reference to a compiler-generated field
        writer.Write((int) this.temperatureUnit);
        writer.PropertyName("unitSystem");
        // ISSUE: reference to a compiler-generated field
        writer.Write((int) this.unitSystem);
        writer.TypeEnd();
      }

      public bool Equals(OptionsUISystem.UnitSettings other)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        return this.timeFormat == other.timeFormat && this.temperatureUnit == other.temperatureUnit && this.unitSystem == other.unitSystem;
      }

      public override bool Equals(object obj)
      {
        // ISSUE: reference to a compiler-generated method
        return obj is OptionsUISystem.UnitSettings other && this.Equals(other);
      }

      public override int GetHashCode()
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        return HashCode.Combine<int, int, int>((int) this.timeFormat, (int) this.temperatureUnit, (int) this.unitSystem);
      }
    }
  }
}

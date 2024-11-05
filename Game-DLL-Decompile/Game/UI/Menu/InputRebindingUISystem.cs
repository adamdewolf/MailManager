// Decompiled with JetBrains decompiler
// Type: Game.UI.Menu.InputRebindingUISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.Menu
{
  public class InputRebindingUISystem : UISystemBase
  {
    private const string kGroup = "inputRebinding";
    private ValueBinding<ProxyBinding?> m_ActiveRebindingBinding;
    private ValueBinding<InputRebindingUISystem.ConflictInfo?> m_ActiveConflictBinding;
    private InputActionRebindingExtensions.RebindingOperation m_Operation;
    private InputActionRebindingExtensions.RebindingOperation m_ModifierOperation;
    private ProxyBinding? m_ActiveRebinding;
    private Action<ProxyBinding> m_OnSetBinding;
    private ProxyBinding? m_PendingRebinding;
    private Dictionary<string, InputRebindingUISystem.ConflictInfoItem> m_Conflicts = new Dictionary<string, InputRebindingUISystem.ConflictInfoItem>();

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.AddBinding((IBinding) (this.m_ActiveRebindingBinding = new ValueBinding<ProxyBinding?>("inputRebinding", "activeRebinding", new ProxyBinding?(), (IWriter<ProxyBinding?>) new ValueWriter<ProxyBinding>().Nullable<ProxyBinding>())));
      this.AddBinding((IBinding) (this.m_ActiveConflictBinding = new ValueBinding<InputRebindingUISystem.ConflictInfo?>("inputRebinding", "activeConflict", new InputRebindingUISystem.ConflictInfo?(), (IWriter<InputRebindingUISystem.ConflictInfo?>) new ValueWriter<InputRebindingUISystem.ConflictInfo>().Nullable<InputRebindingUISystem.ConflictInfo>())));
      this.AddBinding((IBinding) new TriggerBinding("inputRebinding", "cancelRebinding", new Action(this.Cancel)));
      this.AddBinding((IBinding) new TriggerBinding("inputRebinding", "completeAndSwapConflicts", new Action(this.CompleteAndSwapConflicts)));
      this.AddBinding((IBinding) new TriggerBinding("inputRebinding", "completeAndUnsetConflicts", new Action(this.CompleteAndUnsetConflicts)));
      this.m_Operation = new InputActionRebindingExtensions.RebindingOperation();
      this.m_Operation.OnApplyBinding(new Action<InputActionRebindingExtensions.RebindingOperation, string>(this.OnApplyBinding));
      this.m_Operation.OnComplete(new Action<InputActionRebindingExtensions.RebindingOperation>(this.OnComplete));
      this.m_Operation.OnCancel(new Action<InputActionRebindingExtensions.RebindingOperation>(this.OnCancel));
      this.m_ModifierOperation = new InputActionRebindingExtensions.RebindingOperation();
      this.m_ModifierOperation.OnPotentialMatch(new Action<InputActionRebindingExtensions.RebindingOperation>(this.OnModifierPotentialMatch));
      this.m_ModifierOperation.OnApplyBinding(new Action<InputActionRebindingExtensions.RebindingOperation, string>(this.OnModifierApplyBinding));
      UnityEngine.InputSystem.InputSystem.onDeviceChange += new Action<InputDevice, InputDeviceChange>(this.OnDeviceChange);
    }

    [Preserve]
    protected override void OnDestroy()
    {
      this.m_Operation.Dispose();
      this.m_ModifierOperation.Dispose();
      UnityEngine.InputSystem.InputSystem.onDeviceChange -= new Action<InputDevice, InputDeviceChange>(this.OnDeviceChange);
      base.OnDestroy();
    }

    private void OnDeviceChange(InputDevice changedDevice, InputDeviceChange change)
    {
      if (change != InputDeviceChange.Added && change != InputDeviceChange.Removed || !this.m_ActiveRebinding.HasValue)
        return;
      foreach (InputDevice device in UnityEngine.InputSystem.InputSystem.devices)
      {
        if (device.added)
        {
          ProxyBinding proxyBinding;
          if (device is Keyboard)
          {
            proxyBinding = this.m_ActiveRebinding.Value;
            if (proxyBinding.isKeyboard)
              return;
          }
          if (device is Mouse)
          {
            proxyBinding = this.m_ActiveRebinding.Value;
            if (proxyBinding.isMouse)
              return;
          }
          if (device is Gamepad)
          {
            proxyBinding = this.m_ActiveRebinding.Value;
            if (proxyBinding.isGamepad)
              return;
          }
        }
      }
      this.Cancel();
    }

    public void Start(ProxyBinding binding, Action<ProxyBinding> onSetBinding)
    {
      ProxyBinding? activeRebinding = this.m_ActiveRebinding;
      ProxyBinding proxyBinding1 = binding;
      if ((activeRebinding.HasValue ? (activeRebinding.HasValue ? (activeRebinding.GetValueOrDefault() == proxyBinding1 ? 1 : 0) : 1) : 0) != 0 || onSetBinding == null)
        return;
      this.m_ActiveRebinding = new ProxyBinding?(binding);
      this.m_OnSetBinding = onSetBinding;
      this.m_Conflicts.Clear();
      ProxyBinding proxyBinding2 = this.m_ActiveRebinding.Value;
      if (proxyBinding2.isKeyboard)
      {
        Game.Input.InputManager.instance.blockedControlTypes = Game.Input.InputManager.DeviceType.Keyboard;
      }
      else
      {
        proxyBinding2 = this.m_ActiveRebinding.Value;
        if (proxyBinding2.isMouse)
        {
          Game.Input.InputManager.instance.blockedControlTypes = Game.Input.InputManager.DeviceType.Mouse;
        }
        else
        {
          proxyBinding2 = this.m_ActiveRebinding.Value;
          Game.Input.InputManager.instance.blockedControlTypes = !proxyBinding2.isGamepad ? Game.Input.InputManager.DeviceType.None : Game.Input.InputManager.DeviceType.Gamepad;
        }
      }
      this.m_ActiveRebindingBinding.Update(new ProxyBinding?(binding));
      this.m_ActiveConflictBinding.Update(new InputRebindingUISystem.ConflictInfo?());
      this.m_Operation.Reset().WithMagnitudeHavingToBeGreaterThan(0.6f).OnMatchWaitForAnother(0.1f);
      this.m_ModifierOperation.Reset().WithMagnitudeHavingToBeGreaterThan(0.6f);
      if (binding.isKeyboard)
      {
        this.m_Operation.WithControlsHavingToMatchPath("<Keyboard>/<Key>").WithControlsExcluding("<Keyboard>/leftShift").WithControlsExcluding("<Keyboard>/rightShift").WithControlsExcluding("<Keyboard>/leftCtrl").WithControlsExcluding("<Keyboard>/rightCtrl").WithControlsExcluding("<Keyboard>/leftAlt").WithControlsExcluding("<Keyboard>/rightAlt").WithControlsExcluding("<Keyboard>/capsLock").WithControlsExcluding("<Keyboard>/leftWindows").WithControlsExcluding("<Keyboard>/rightWindow").WithControlsExcluding("<Keyboard>/leftMeta").WithControlsExcluding("<Keyboard>/rightMeta").WithControlsExcluding("<Keyboard>/numLock").WithControlsExcluding("<Keyboard>/printScreen").WithControlsExcluding("<Keyboard>/scrollLock").WithControlsExcluding("<Keyboard>/insert").WithControlsExcluding("<Keyboard>/contextMenu").WithControlsExcluding("<Keyboard>/pause").Start();
        if (!binding.allowModifiers)
          return;
        this.m_ModifierOperation.WithControlsHavingToMatchPath("<Keyboard>/shift").WithControlsHavingToMatchPath("<Keyboard>/ctrl").WithControlsHavingToMatchPath("<Keyboard>/alt").Start();
      }
      else if (binding.isMouse)
      {
        this.m_Operation.WithControlsHavingToMatchPath("<Mouse>/<Button>").Start();
        if (!binding.allowModifiers)
          return;
        this.m_ModifierOperation.WithControlsHavingToMatchPath("<Keyboard>/shift").WithControlsHavingToMatchPath("<Keyboard>/ctrl").WithControlsHavingToMatchPath("<Keyboard>/alt").Start();
      }
      else
      {
        if (!binding.isGamepad)
          return;
        this.m_Operation.WithControlsHavingToMatchPath("<Gamepad>/<Button>").WithControlsHavingToMatchPath("<Gamepad>/*/<Button>").WithControlsExcluding("<Gamepad>/leftStickPress").WithControlsExcluding("<Gamepad>/rightStickPress").WithControlsExcluding("<DualSenseGamepadHID>/leftTriggerButton").WithControlsExcluding("<DualSenseGamepadHID>/rightTriggerButton").WithControlsExcluding("<DualSenseGamepadHID>/systemButton").WithControlsExcluding("<DualSenseGamepadHID>/micButton").Start();
        if (!binding.allowModifiers)
          return;
        this.m_ModifierOperation.WithControlsHavingToMatchPath("<Gamepad>/leftStickPress").WithControlsHavingToMatchPath("<Gamepad>/rightStickPress").Start();
      }
    }

    public void Start(
      ProxyBinding binding,
      ProxyBinding newBinding,
      Action<ProxyBinding> onSetBinding)
    {
      ProxyBinding? activeRebinding = this.m_ActiveRebinding;
      ProxyBinding proxyBinding = binding;
      if ((activeRebinding.HasValue ? (activeRebinding.HasValue ? (activeRebinding.GetValueOrDefault() == proxyBinding ? 1 : 0) : 1) : 0) != 0 || onSetBinding == null)
        return;
      this.m_ActiveRebinding = new ProxyBinding?(binding);
      this.m_OnSetBinding = onSetBinding;
      this.m_ActiveRebindingBinding.Update(new ProxyBinding?(binding));
      this.m_ActiveConflictBinding.Update(new InputRebindingUISystem.ConflictInfo?());
      this.Process(binding, newBinding);
    }

    public void Cancel()
    {
      this.m_Operation.Reset();
      this.Reset();
    }

    private void CompleteAndSwapConflicts()
    {
      if (this.m_PendingRebinding.HasValue)
      {
        using (Game.Input.InputManager.DeferUpdating())
        {
          Game.Input.InputManager.instance.SetBindings(this.m_Conflicts.Values.Where<InputRebindingUISystem.ConflictInfoItem>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (c => !c.isAlias)).Select<InputRebindingUISystem.ConflictInfoItem, ProxyBinding>((Func<InputRebindingUISystem.ConflictInfoItem, ProxyBinding>) (c => c.resolution)), out List<ProxyBinding> _);
          this.Apply(this.m_PendingRebinding.Value);
        }
      }
      this.Reset();
    }

    private void CompleteAndUnsetConflicts()
    {
      if (this.m_PendingRebinding.HasValue)
      {
        using (Game.Input.InputManager.DeferUpdating())
        {
          Game.Input.InputManager.instance.SetBindings(this.m_Conflicts.Values.Where<InputRebindingUISystem.ConflictInfoItem>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (c => !c.isAlias)).Select<InputRebindingUISystem.ConflictInfoItem, ProxyBinding>((Func<InputRebindingUISystem.ConflictInfoItem, ProxyBinding>) (c => c.binding.WithPath(string.Empty).WithModifiers((IReadOnlyList<ProxyModifier>) Array.Empty<ProxyModifier>()))), out List<ProxyBinding> _);
          this.Apply(this.m_PendingRebinding.Value);
        }
      }
      this.Reset();
    }

    private void OnApplyBinding(
      InputActionRebindingExtensions.RebindingOperation operation,
      string path)
    {
      if (!this.m_ActiveRebinding.HasValue)
        return;
      Game.Input.InputManager.instance.blockedControlTypes = Game.Input.InputManager.DeviceType.None;
      if (path != null && path.StartsWith("<DualShockGamepad>"))
        path = path.Replace("<DualShockGamepad>", "<Gamepad>");
      ProxyBinding oldBinding = this.m_ActiveRebinding.Value;
      ProxyBinding newBinding = oldBinding.Copy() with
      {
        path = path,
        modifiers = (IReadOnlyList<ProxyModifier>) this.m_ModifierOperation.candidates.Where<InputControl>((Func<InputControl, bool>) (c => c.IsPressed())).Select<InputControl, ProxyModifier>((Func<InputControl, ProxyModifier>) (c => new ProxyModifier()
        {
          m_Component = oldBinding.component,
          m_Name = Game.Input.InputManager.GetModifierName(oldBinding.component),
          m_Path = Game.Input.InputManager.GeneratePathForControl(c)
        })).ToList<ProxyModifier>()
      };
      this.m_ModifierOperation.Reset();
      this.Process(oldBinding, newBinding);
    }

    private void OnComplete(
      InputActionRebindingExtensions.RebindingOperation operation)
    {
      Game.Input.InputManager.instance.blockedControlTypes = Game.Input.InputManager.DeviceType.None;
      if (this.m_PendingRebinding.HasValue)
        return;
      this.Reset();
    }

    private void OnCancel(
      InputActionRebindingExtensions.RebindingOperation operation)
    {
      Game.Input.InputManager.instance.blockedControlTypes = Game.Input.InputManager.DeviceType.None;
      this.Reset();
    }

    private void Process(ProxyBinding oldBinding, ProxyBinding newBinding)
    {
      UISystemBase.log.InfoFormat("Rebinding from {0} to {1}", (object) oldBinding, (object) newBinding);
      ProxyAction action = newBinding.action;
      if (action == null)
        this.Reset();
      else if (action.linkedActions.Count == 0 && action.m_UIAliases.All<UIInputAction>((Func<UIInputAction, bool>) (a => !a.m_ShowInOptions || (a.m_Mask & newBinding.device) == Game.Input.InputManager.DeviceType.None)) && newBinding.hasConflicts == ProxyBinding.ConflictType.None)
      {
        this.Apply(newBinding);
        this.Reset();
      }
      else
      {
        this.GetRebindOptions(oldBinding, newBinding);
        if (this.m_Conflicts.Count == 0)
        {
          this.Apply(newBinding);
          this.Reset();
        }
        else
        {
          bool flag1 = this.m_Conflicts.Values.Any<InputRebindingUISystem.ConflictInfoItem>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (c => (c.options & InputRebindingUISystem.Options.Backward) != 0));
          bool flag2 = this.m_Conflicts.Values.All<InputRebindingUISystem.ConflictInfoItem>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (c => (c.options & InputRebindingUISystem.Options.Swap) != InputRebindingUISystem.Options.None && (c.options & InputRebindingUISystem.Options.Backward) == InputRebindingUISystem.Options.None));
          bool flag3 = this.m_Conflicts.Values.All<InputRebindingUISystem.ConflictInfoItem>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (c => (c.options & InputRebindingUISystem.Options.Unset) != InputRebindingUISystem.Options.None && (c.options & InputRebindingUISystem.Options.Backward) == InputRebindingUISystem.Options.None));
          bool flag4 = this.m_Conflicts.Values.Any<InputRebindingUISystem.ConflictInfoItem>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (c => (c.options & InputRebindingUISystem.Options.Unsolved) != 0));
          if (flag1)
            this.m_Conflicts.Add(oldBinding.title, new InputRebindingUISystem.ConflictInfoItem()
            {
              binding = oldBinding,
              resolution = newBinding
            });
          this.m_PendingRebinding = new ProxyBinding?(newBinding);
          this.m_ActiveConflictBinding.Update(new InputRebindingUISystem.ConflictInfo?(new InputRebindingUISystem.ConflictInfo()
          {
            binding = newBinding,
            conflicts = this.m_Conflicts.Values.OrderByDescending<InputRebindingUISystem.ConflictInfoItem, bool>((Func<InputRebindingUISystem.ConflictInfoItem, bool>) (b => b.binding.Equals(newBinding))).ThenBy<InputRebindingUISystem.ConflictInfoItem, string>((Func<InputRebindingUISystem.ConflictInfoItem, string>) (b => b.binding.mapName)).ToArray<InputRebindingUISystem.ConflictInfoItem>(),
            unsolved = flag4,
            swap = flag2,
            unset = flag3,
            batchSwap = flag1
          }));
        }
      }
    }

    private void GetRebindOptions(ProxyBinding oldBinding, ProxyBinding newBinding)
    {
      List<ProxyBinding> list1 = Collect(oldBinding).ToList<ProxyBinding>();
      List<ProxyBinding> list2 = Collect(newBinding).ToList<ProxyBinding>();
      this.m_Conflicts.Clear();
      Usages otherUsages1 = new Usages(0, false);
      Usages otherUsages2 = newBinding.usages.Copy(false);
      ProxyAction action = newBinding.action;
      if (action != null)
      {
        foreach (ProxyAction linkedAction in (IEnumerable<ProxyAction>) action.linkedActions)
        {
          foreach (ProxyBinding binding in (IEnumerable<ProxyBinding>) linkedAction.bindings)
          {
            if (!binding.isDummy && ProxyBinding.componentComparer.Equals(newBinding, binding) && !newBinding.PathEquals(binding))
            {
              otherUsages2 = Usages.Combine(otherUsages2, binding.usages);
              ProxyBinding proxyBinding = binding.Copy() with
              {
                path = newBinding.path,
                modifiers = newBinding.modifiers
              };
              this.m_Conflicts.Add(binding.title, new InputRebindingUISystem.ConflictInfoItem()
              {
                binding = binding.Copy(),
                resolution = proxyBinding,
                options = InputRebindingUISystem.Options.Backward
              });
            }
          }
        }
        foreach (UIInputAction uiAlias in action.m_UIAliases)
        {
          if (!((UnityEngine.Object) newBinding.alies == (UnityEngine.Object) uiAlias) && uiAlias.m_ShowInOptions && (uiAlias.m_Transform == UIInputAction.Transform.None || (newBinding.component.ToTransform() & uiAlias.m_Transform) != UIInputAction.Transform.None) && (uiAlias.m_Mask & newBinding.device) != Game.Input.InputManager.DeviceType.None)
          {
            ProxyBinding proxyBinding = newBinding.Copy() with
            {
              alies = uiAlias
            };
            this.m_Conflicts.Add(proxyBinding.title, new InputRebindingUISystem.ConflictInfoItem()
            {
              binding = proxyBinding,
              resolution = proxyBinding,
              options = InputRebindingUISystem.Options.Backward,
              isAlias = true
            });
          }
        }
        if (newBinding.isAlias)
        {
          ProxyBinding proxyBinding = newBinding.Copy() with
          {
            alies = (UIInputAction) null
          };
          this.m_Conflicts.Add(proxyBinding.title, new InputRebindingUISystem.ConflictInfoItem()
          {
            binding = proxyBinding,
            resolution = proxyBinding,
            options = InputRebindingUISystem.Options.Backward,
            isAlias = true
          });
        }
      }
      bool changed = true;
      while (changed)
      {
        if (newBinding.PathEquals(oldBinding))
        {
          ProcessConflict(list2, newBinding, otherUsages2, InputRebindingUISystem.Options.None, ref otherUsages2, out changed);
          break;
        }
        ProcessConflict(list2, oldBinding, otherUsages2, InputRebindingUISystem.Options.Forward, ref otherUsages1, out changed);
        if (!changed)
          break;
        ProcessConflict(list1, newBinding, otherUsages1, InputRebindingUISystem.Options.Backward, ref otherUsages2, out changed);
        if (!changed)
          break;
      }

      void ProcessConflict(
        List<ProxyBinding> conflicts,
        ProxyBinding binding,
        Usages usages,
        InputRebindingUISystem.Options direction,
        ref Usages otherUsages,
        out bool changed)
      {
        changed = false;
        for (int index = 0; index < conflicts.Count; ++index)
        {
          Usages usages1_1 = usages;
          ProxyBinding conflict = conflicts[index];
          Usages usages1 = conflict.usages;
          if (Usages.TestAny(usages1_1, usages1))
          {
            InputRebindingUISystem.Options options = direction;
            int num;
            if (binding.isSet)
            {
              conflict = conflicts[index];
              if (conflict.isRebindable)
              {
                if (binding.modifiers.Count != 0)
                {
                  conflict = conflicts[index];
                  if (!conflict.allowModifiers)
                    goto label_9;
                }
                if (direction != InputRebindingUISystem.Options.Forward)
                {
                  Usages usages2 = binding.usages;
                  conflict = conflicts[index];
                  Usages usages3 = conflict.usages;
                  num = !Usages.TestAny(usages2, usages3) ? 1 : 0;
                  goto label_10;
                }
                else
                {
                  num = 1;
                  goto label_10;
                }
              }
            }
label_9:
            num = 0;
label_10:
            conflict = conflicts[index];
            bool canBeEmpty = conflict.canBeEmpty;
            if (num != 0)
              options |= InputRebindingUISystem.Options.Swap;
            if (canBeEmpty)
              options |= InputRebindingUISystem.Options.Unset;
            if (num == 0 && !canBeEmpty)
              options |= InputRebindingUISystem.Options.Unsolved;
            InputRebindingUISystem.ConflictInfoItem conflictInfoItem1;
            if ((options & InputRebindingUISystem.Options.Swap) != InputRebindingUISystem.Options.None)
            {
              changed = true;
              ref Usages local1 = ref otherUsages;
              Usages usages1_2 = otherUsages;
              conflict = conflicts[index];
              Usages usages4 = conflict.usages;
              Usages usages5 = Usages.Combine(usages1_2, usages4);
              local1 = usages5;
              conflict = conflicts[index];
              ProxyBinding proxyBinding1 = conflict.Copy() with
              {
                path = binding.path,
                modifiers = binding.modifiers
              };
              Dictionary<string, InputRebindingUISystem.ConflictInfoItem> conflicts1 = this.m_Conflicts;
              conflict = conflicts[index];
              string title = conflict.title;
              conflictInfoItem1 = new InputRebindingUISystem.ConflictInfoItem();
              ref InputRebindingUISystem.ConflictInfoItem local2 = ref conflictInfoItem1;
              conflict = conflicts[index];
              ProxyBinding proxyBinding2 = conflict.Copy();
              local2.binding = proxyBinding2;
              conflictInfoItem1.resolution = proxyBinding1;
              conflictInfoItem1.options = options;
              InputRebindingUISystem.ConflictInfoItem conflictInfoItem2 = conflictInfoItem1;
              conflicts1.Add(title, conflictInfoItem2);
            }
            else if ((options & InputRebindingUISystem.Options.Unset) != InputRebindingUISystem.Options.None)
            {
              changed = true;
              conflict = conflicts[index];
              ProxyBinding proxyBinding3 = conflict.Copy() with
              {
                path = string.Empty,
                modifiers = (IReadOnlyList<ProxyModifier>) Array.Empty<ProxyModifier>()
              };
              Dictionary<string, InputRebindingUISystem.ConflictInfoItem> conflicts2 = this.m_Conflicts;
              conflict = conflicts[index];
              string title = conflict.title;
              conflictInfoItem1 = new InputRebindingUISystem.ConflictInfoItem();
              ref InputRebindingUISystem.ConflictInfoItem local = ref conflictInfoItem1;
              conflict = conflicts[index];
              ProxyBinding proxyBinding4 = conflict.Copy();
              local.binding = proxyBinding4;
              conflictInfoItem1.resolution = proxyBinding3;
              conflictInfoItem1.options = options;
              InputRebindingUISystem.ConflictInfoItem conflictInfoItem3 = conflictInfoItem1;
              conflicts2.Add(title, conflictInfoItem3);
            }
            else if ((options & InputRebindingUISystem.Options.Unsolved) != InputRebindingUISystem.Options.None)
            {
              changed = true;
              Dictionary<string, InputRebindingUISystem.ConflictInfoItem> conflicts3 = this.m_Conflicts;
              conflict = conflicts[index];
              string title = conflict.title;
              conflictInfoItem1 = new InputRebindingUISystem.ConflictInfoItem();
              ref InputRebindingUISystem.ConflictInfoItem local3 = ref conflictInfoItem1;
              conflict = conflicts[index];
              ProxyBinding proxyBinding5 = conflict.Copy();
              local3.binding = proxyBinding5;
              ref InputRebindingUISystem.ConflictInfoItem local4 = ref conflictInfoItem1;
              conflict = conflicts[index];
              ProxyBinding proxyBinding6 = conflict.Copy();
              local4.resolution = proxyBinding6;
              conflictInfoItem1.options = options;
              InputRebindingUISystem.ConflictInfoItem conflictInfoItem4 = conflictInfoItem1;
              conflicts3.Add(title, conflictInfoItem4);
            }
            conflicts.RemoveAt(index);
            --index;
          }
        }
      }

      static IEnumerable<ProxyBinding> Collect(ProxyBinding source)
      {
        HashSet<ProxyAction> proxyActionSet;
        if (Game.Input.InputManager.instance.keyActionMap.TryGetValue(source.path, out proxyActionSet))
        {
          ProxyAction sourceAction = source.action;
          foreach (ProxyAction b in proxyActionSet)
          {
            bool canConflict = ProxyAction.CanConflict(sourceAction, b);
            foreach (ProxyBinding binding in (IEnumerable<ProxyBinding>) b.bindings)
            {
              if (!binding.isDummy && (canConflict || !ProxyBinding.componentComparer.Equals(binding, source)) && source.PathEquals(binding) && !binding.Equals(source) && !binding.usages.isNone)
                yield return binding;
            }
          }
          sourceAction = (ProxyAction) null;
        }
      }
    }

    private void Apply(ProxyBinding newBinding)
    {
      using (Game.Input.InputManager.DeferUpdating())
      {
        Action<ProxyBinding> onSetBinding = this.m_OnSetBinding;
        if (onSetBinding == null)
          return;
        onSetBinding(newBinding);
      }
    }

    private void Reset()
    {
      this.m_ActiveRebindingBinding.Update(new ProxyBinding?());
      this.m_ActiveConflictBinding.Update(new InputRebindingUISystem.ConflictInfo?());
      this.m_ModifierOperation.Reset();
      this.m_ActiveRebinding = new ProxyBinding?();
      this.m_OnSetBinding = (Action<ProxyBinding>) null;
      this.m_PendingRebinding = new ProxyBinding?();
      this.m_Conflicts.Clear();
    }

    private void OnModifierPotentialMatch(
      InputActionRebindingExtensions.RebindingOperation operation)
    {
    }

    private void OnModifierApplyBinding(
      InputActionRebindingExtensions.RebindingOperation operation,
      string path)
    {
    }

    [Preserve]
    public InputRebindingUISystem()
    {
    }

    [Flags]
    private enum Options
    {
      None = 0,
      Unsolved = 1,
      Swap = 2,
      Unset = 4,
      Forward = 8,
      Backward = 16, // 0x00000010
    }

    private struct ConflictInfo : IJsonWritable
    {
      public ProxyBinding binding;
      public InputRebindingUISystem.ConflictInfoItem[] conflicts;

      public bool unsolved { get; set; }

      public bool swap { get; set; }

      public bool unset { get; set; }

      public bool batchSwap { get; set; }

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin(typeof (InputRebindingUISystem.ConflictInfo).FullName);
        writer.PropertyName("binding");
        writer.Write<ProxyBinding>(this.binding);
        writer.PropertyName("conflicts");
        writer.Write<InputRebindingUISystem.ConflictInfoItem>((IList<InputRebindingUISystem.ConflictInfoItem>) this.conflicts);
        writer.PropertyName("unsolved");
        writer.Write(this.unsolved);
        writer.PropertyName("swap");
        writer.Write(this.swap);
        writer.PropertyName("unset");
        writer.Write(this.unset);
        writer.PropertyName("batchSwap");
        writer.Write(this.batchSwap);
        writer.TypeEnd();
      }
    }

    private struct ConflictInfoItem : IJsonWritable
    {
      public ProxyBinding binding;
      public ProxyBinding resolution;
      public InputRebindingUISystem.Options options;
      public bool isAlias;

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin(typeof (InputRebindingUISystem.ConflictInfoItem).FullName);
        writer.PropertyName("binding");
        writer.Write<ProxyBinding>(this.binding);
        writer.PropertyName("resolution");
        writer.Write<ProxyBinding>(this.resolution);
        writer.TypeEnd();
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Settings.About
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using cohtml.Net;
using Colossal.PSI.Common;
using Game.UI.Menu;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

#nullable disable
namespace Game.Settings
{
  public class About : Setting
  {
    public string gameVersion => Game.Version.current.fullVersion;

    public string gameConfiguration => !Debug.isDebugBuild ? "Release" : "Development";

    public string coreVersion => Colossal.Core.Version.current.fullVersion;

    public string uiVersion => Colossal.UI.Version.current.fullVersion;

    public string unityVersion => Application.unityVersion;

    public string cohtmlVersion => Versioning.Build.ToString();

    public string atlVersion => ATL.Version.getVersion();

    public override void SetDefaults()
    {
    }

    public override AutomaticSettings.SettingPageData GetPageData(string id, bool addPrefix)
    {
      AutomaticSettings.SettingPageData pageData = base.GetPageData(id, addPrefix);
      foreach (IPlatformServiceIntegration serviceIntegration in (IEnumerable<IPlatformServiceIntegration>) PlatformManager.instance.platformServiceIntegrations)
      {
        StringBuilder b = new StringBuilder();
        serviceIntegration.LogVersion(b);
        string[] strArray = b.ToString().Split(Environment.NewLine, StringSplitOptions.None);
        int num = 0;
        foreach (string str in strArray)
        {
          string line = str;
          int sep = line.IndexOf(":", StringComparison.Ordinal);
          if (sep != -1)
          {
            AutomaticSettings.SettingItemData settingItemData = new AutomaticSettings.SettingItemData(AutomaticSettings.WidgetType.StringField, (Setting) this, (AutomaticSettings.IProxyProperty) new AutomaticSettings.ManualProperty(typeof (About), typeof (string), serviceIntegration.name)
            {
              canRead = true,
              canWrite = false,
              attributes = {
                (Attribute) new SettingsUIPathAttribute(string.Format("{0}{1}.{2}", (object) serviceIntegration.GetType().Name, (object) num++, (object) serviceIntegration.name)),
                (Attribute) new SettingsUIDisplayNameAttribute(overrideValue: line.Substring(0, sep))
              },
              getter = (Func<object, object>) (obj => (object) line.Substring(sep + 1))
            }, pageData.prefix);
            pageData["General"].AddItem(settingItemData);
          }
        }
      }
      return pageData;
    }
  }
}

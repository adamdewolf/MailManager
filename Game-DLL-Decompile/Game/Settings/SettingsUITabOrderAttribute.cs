// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUITabOrderAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public class SettingsUITabOrderAttribute : Attribute
  {
    public readonly ReadOnlyCollection<string> tabs;
    public readonly Type checkType;
    public readonly string checkMethod;

    public SettingsUITabOrderAttribute(params string[] tabs)
    {
      this.tabs = new ReadOnlyCollection<string>((IList<string>) tabs);
    }

    public SettingsUITabOrderAttribute(Type checkType, string checkMethod)
    {
      this.checkType = checkType;
      this.checkMethod = checkMethod;
    }
  }
}

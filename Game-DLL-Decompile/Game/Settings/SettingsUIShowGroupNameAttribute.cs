// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIShowGroupNameAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
  public class SettingsUIShowGroupNameAttribute : Attribute
  {
    public readonly bool showAll;
    public readonly ReadOnlyCollection<string> groups;

    public SettingsUIShowGroupNameAttribute() => this.showAll = true;

    public SettingsUIShowGroupNameAttribute(params string[] groups)
    {
      this.groups = new ReadOnlyCollection<string>((IList<string>) groups);
    }
  }
}

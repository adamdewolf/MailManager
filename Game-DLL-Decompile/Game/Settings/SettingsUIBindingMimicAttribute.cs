// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIBindingMimicAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Property)]
  public class SettingsUIBindingMimicAttribute : Attribute
  {
    public readonly string map;
    public readonly string action;

    public SettingsUIBindingMimicAttribute(string map, string action)
    {
      this.map = map;
      this.action = action;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIDescriptionAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Enum | AttributeTargets.Property, Inherited = true)]
  public class SettingsUIDescriptionAttribute : Attribute
  {
    public readonly string id;
    public readonly string value;
    public readonly Type getterType;
    public readonly string getterMethod;

    public SettingsUIDescriptionAttribute(string overrideId = null, string overrideValue = null)
    {
      this.id = overrideId;
      this.value = overrideValue;
    }

    public SettingsUIDescriptionAttribute(Type getterType, string getterMethod)
    {
      this.getterType = getterType;
      this.getterMethod = getterMethod;
    }
  }
}

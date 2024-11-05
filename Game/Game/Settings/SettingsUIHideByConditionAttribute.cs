// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIHideByConditionAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true)]
  public class SettingsUIHideByConditionAttribute : Attribute
  {
    public readonly Type checkType;
    public readonly string checkMethod;
    public readonly bool invert;

    public SettingsUIHideByConditionAttribute(Type checkType, string checkMethod)
    {
      this.checkType = checkType;
      this.checkMethod = checkMethod;
    }

    public SettingsUIHideByConditionAttribute(Type checkType, string checkMethod, bool invert)
    {
      this.checkType = checkType;
      this.checkMethod = checkMethod;
      this.invert = invert;
    }
  }
}

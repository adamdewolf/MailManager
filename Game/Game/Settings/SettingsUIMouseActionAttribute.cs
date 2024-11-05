// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIMouseActionAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class SettingsUIMouseActionAttribute : SettingsUIInputActionAttribute
  {
    public SettingsUIMouseActionAttribute(
      string name,
      ActionType type = ActionType.Button,
      bool allowModifiers = true,
      bool developerOnly = false,
      string[] usages = null,
      string[] interactions = null,
      string[] processors = null)
      : base(name, InputManager.DeviceType.Mouse, type, allowModifiers, developerOnly, Game.Input.Mode.DigitalNormalized, usages, interactions, processors)
    {
    }

    public SettingsUIMouseActionAttribute(
      string name,
      ActionType type,
      params string[] customUsages)
      : base(name, InputManager.DeviceType.Mouse, type, Game.Input.Mode.DigitalNormalized, customUsages)
    {
    }

    public SettingsUIMouseActionAttribute(string name, params string[] customUsages)
      : base(name, InputManager.DeviceType.Mouse, ActionType.Button, Game.Input.Mode.DigitalNormalized, customUsages)
    {
    }
  }
}

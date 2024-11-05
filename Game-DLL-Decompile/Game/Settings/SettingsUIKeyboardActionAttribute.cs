// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIKeyboardActionAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
  public class SettingsUIKeyboardActionAttribute : SettingsUIInputActionAttribute
  {
    public SettingsUIKeyboardActionAttribute(
      string name,
      ActionType type = ActionType.Button,
      bool allowModifiers = true,
      bool developerOnly = false,
      Game.Input.Mode mode = Game.Input.Mode.DigitalNormalized,
      string[] usages = null,
      string[] interactions = null,
      string[] processors = null)
      : base(name, InputManager.DeviceType.Keyboard, type, allowModifiers, developerOnly, mode, usages, interactions, processors)
    {
    }

    public SettingsUIKeyboardActionAttribute(
      string name,
      ActionType type,
      Game.Input.Mode mode,
      params string[] customUsages)
      : base(name, InputManager.DeviceType.Keyboard, type, mode, customUsages)
    {
    }

    public SettingsUIKeyboardActionAttribute(
      string name,
      ActionType type,
      params string[] customUsages)
      : base(name, InputManager.DeviceType.Keyboard, type, Game.Input.Mode.DigitalNormalized, customUsages)
    {
    }

    public SettingsUIKeyboardActionAttribute(string name, Game.Input.Mode mode, params string[] customUsages)
      : base(name, InputManager.DeviceType.Keyboard, ActionType.Button, mode, customUsages)
    {
    }

    public SettingsUIKeyboardActionAttribute(string name, params string[] customUsages)
      : base(name, InputManager.DeviceType.Keyboard, ActionType.Button, Game.Input.Mode.DigitalNormalized, customUsages)
    {
    }
  }
}

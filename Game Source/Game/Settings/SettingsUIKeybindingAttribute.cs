﻿// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUIKeybindingAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using System;
using System.Collections.Generic;

#nullable disable
namespace Game.Settings
{
  public abstract class SettingsUIKeybindingAttribute : Attribute
  {
    public readonly string actionName;
    public readonly InputManager.DeviceType device;
    public readonly ActionType type;
    public readonly ActionComponent component;

    public abstract string control { get; }

    public abstract IEnumerable<string> modifierControls { get; }

    protected SettingsUIKeybindingAttribute(
      string actionName,
      InputManager.DeviceType device,
      ActionType type,
      ActionComponent component)
    {
      this.actionName = actionName;
      this.device = device;
      this.type = type;
      this.component = component;
    }
  }
}
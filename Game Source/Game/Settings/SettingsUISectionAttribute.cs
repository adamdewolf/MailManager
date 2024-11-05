﻿// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUISectionAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property, Inherited = true, AllowMultiple = true)]
  public class SettingsUISectionAttribute : Attribute
  {
    public const string kGeneral = "General";
    public readonly string tab;
    public readonly string simpleGroup;
    public readonly string advancedGroup;

    public SettingsUISectionAttribute(string tab, string simpleGroup, string advancedGroup)
    {
      this.tab = tab ?? "General";
      this.simpleGroup = simpleGroup ?? string.Empty;
      this.advancedGroup = advancedGroup ?? string.Empty;
    }

    public SettingsUISectionAttribute(string tab, string group)
      : this(tab, group, group)
    {
    }

    public SettingsUISectionAttribute(string group)
      : this((string) null, group, group)
    {
    }
  }
}

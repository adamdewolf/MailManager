﻿// Decompiled with JetBrains decompiler
// Type: Game.Settings.SettingsUICustomFormatAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Settings
{
  [AttributeUsage(AttributeTargets.Property, Inherited = true)]
  public class SettingsUICustomFormatAttribute : Attribute
  {
    public int fractionDigits;
    public bool separateThousands = true;
    public float maxValueWithFraction = 100f;
    public bool signed;
  }
}
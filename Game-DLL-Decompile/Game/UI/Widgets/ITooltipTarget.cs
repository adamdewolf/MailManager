﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.ITooltipTarget
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.UI.Localization;

#nullable disable
namespace Game.UI.Widgets
{
  public interface ITooltipTarget
  {
    LocalizedString? tooltip { get; set; }
  }
}
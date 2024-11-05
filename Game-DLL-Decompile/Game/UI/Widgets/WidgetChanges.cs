// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.WidgetChanges
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.UI.Widgets
{
  [Flags]
  public enum WidgetChanges : byte
  {
    None = 0,
    Path = 1,
    Properties = 2,
    Children = 4,
    Visibility = 8,
    Activity = 16, // 0x10
    TotalProperties = Activity | Visibility | Properties, // 0x1A
  }
}

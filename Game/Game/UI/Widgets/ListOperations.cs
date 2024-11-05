// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.ListOperations
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.UI.Widgets
{
  [Flags]
  public enum ListOperations
  {
    None = 0,
    AddElement = 1,
    Clear = 2,
    MoveUp = Clear, // 0x00000002
    MoveDown = 4,
    Duplicate = 8,
    Delete = 16, // 0x00000010
  }
}

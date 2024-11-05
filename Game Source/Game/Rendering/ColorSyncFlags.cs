// Decompiled with JetBrains decompiler
// Type: Game.Rendering.ColorSyncFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Rendering
{
  [Flags]
  public enum ColorSyncFlags : byte
  {
    None = 0,
    SameGroup = 1,
    SameIndex = 2,
    DifferentGroup = 4,
    DifferentIndex = 8,
    SyncRangeVariation = 16, // 0x10
  }
}

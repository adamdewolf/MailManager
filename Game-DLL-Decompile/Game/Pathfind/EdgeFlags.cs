﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.EdgeFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  [Flags]
  public enum EdgeFlags : ushort
  {
    Forward = 1,
    Backward = 2,
    AllowMiddle = 4,
    SingleOnly = 8,
    SecondaryStart = 16, // 0x0010
    SecondaryEnd = 32, // 0x0020
    FreeForward = 64, // 0x0040
    FreeBackward = 128, // 0x0080
    Secondary = 256, // 0x0100
    AllowEnter = 512, // 0x0200
    AllowExit = 1024, // 0x0400
    RequireAuthorization = 16384, // 0x4000
    OutsideConnection = 32768, // 0x8000
    DefaultMask = 65279, // 0xFEFF
  }
}
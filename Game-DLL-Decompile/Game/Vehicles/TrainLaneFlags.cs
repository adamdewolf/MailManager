﻿// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.TrainLaneFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum TrainLaneFlags : uint
  {
    EndOfPath = 1,
    EndReached = 2,
    Return = 4,
    PushBlockers = 8,
    ResetSpeed = 16, // 0x00000010
    HighBeams = 32, // 0x00000020
    Obsolete = 64, // 0x00000040
    Reserved = 128, // 0x00000080
    TurnLeft = 256, // 0x00000100
    TurnRight = 512, // 0x00000200
    BlockReserve = 1024, // 0x00000400
    KeepClear = 16384, // 0x00004000
    TryReserve = 32768, // 0x00008000
    Connection = 65536, // 0x00010000
    Exclusive = 131072, // 0x00020000
    FullReserve = 262144, // 0x00040000
  }
}
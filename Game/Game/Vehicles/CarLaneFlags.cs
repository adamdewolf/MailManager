﻿// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.CarLaneFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum CarLaneFlags : uint
  {
    EndOfPath = 1,
    EndReached = 2,
    UpdateOptimalLane = 4,
    TransformTarget = 8,
    ParkingSpace = 16, // 0x00000010
    EnteringRoad = 32, // 0x00000020
    Obsolete = 64, // 0x00000040
    Reserved = 128, // 0x00000080
    FixedLane = 256, // 0x00000100
    Waypoint = 512, // 0x00000200
    Checked = 1024, // 0x00000400
    GroupTarget = 2048, // 0x00000800
    Queue = 4096, // 0x00001000
    IgnoreBlocker = 8192, // 0x00002000
    IsBlocked = 16384, // 0x00004000
    QueueReached = 32768, // 0x00008000
    Validated = 65536, // 0x00010000
    Interruption = 131072, // 0x00020000
    TurnLeft = 262144, // 0x00040000
    TurnRight = 524288, // 0x00080000
    PushBlockers = 1048576, // 0x00100000
    HighBeams = 2097152, // 0x00200000
    RequestSpace = 4194304, // 0x00400000
    FixedStart = 8388608, // 0x00800000
    Connection = 16777216, // 0x01000000
    ResetSpeed = 33554432, // 0x02000000
    Area = 67108864, // 0x04000000
    Roundabout = 134217728, // 0x08000000
    CanReverse = 268435456, // 0x10000000
    ClearedForPathfind = 536870912, // 0x20000000
  }
}
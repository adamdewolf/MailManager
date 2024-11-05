// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.AircraftLaneFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum AircraftLaneFlags : uint
  {
    EndOfPath = 1,
    EndReached = 2,
    Connection = 4,
    TransformTarget = 8,
    ResetSpeed = 32, // 0x00000020
    Obsolete = 64, // 0x00000040
    Reserved = 128, // 0x00000080
    SkipLane = 256, // 0x00000100
    Checked = 1024, // 0x00000400
    IgnoreBlocker = 8192, // 0x00002000
    Runway = 65536, // 0x00010000
    Airway = 131072, // 0x00020000
    Approaching = 1048576, // 0x00100000
    Flying = 2097152, // 0x00200000
    Landing = 4194304, // 0x00400000
    TakingOff = 8388608, // 0x00800000
  }
}

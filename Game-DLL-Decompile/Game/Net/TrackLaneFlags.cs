// Decompiled with JetBrains decompiler
// Type: Game.Net.TrackLaneFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Net
{
  [Flags]
  public enum TrackLaneFlags
  {
    Invert = 1,
    Twoway = 2,
    Switch = 4,
    DiamondCrossing = 8,
    Exclusive = 16, // 0x00000010
    LevelCrossing = 32, // 0x00000020
    AllowMiddle = 64, // 0x00000040
    CrossingTraffic = 128, // 0x00000080
    MergingTraffic = 256, // 0x00000100
    StartingLane = 512, // 0x00000200
    EndingLane = 1024, // 0x00000400
    Station = 2048, // 0x00000800
    TurnLeft = 4096, // 0x00001000
    TurnRight = 8192, // 0x00002000
    DoubleSwitch = 16384, // 0x00004000
  }
}

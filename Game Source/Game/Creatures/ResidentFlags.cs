﻿// Decompiled with JetBrains decompiler
// Type: Game.Creatures.ResidentFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Creatures
{
  [Flags]
  public enum ResidentFlags : uint
  {
    None = 0,
    Disembarking = 1,
    ActivityDone = 2,
    WaitingTransport = 4,
    Arrived = 8,
    Hangaround = 16, // 0x00000010
    InVehicle = 32, // 0x00000020
    PreferredLeader = 64, // 0x00000040
    NoLateDeparture = 128, // 0x00000080
    IgnoreTaxi = 256, // 0x00000100
    IgnoreTransport = 512, // 0x00000200
    IgnoreBenches = 1024, // 0x00000400
    IgnoreAreas = 2048, // 0x00000800
    CannotIgnore = 4096, // 0x00001000
    DummyTraffic = 8192, // 0x00002000
  }
}
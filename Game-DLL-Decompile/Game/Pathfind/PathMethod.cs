﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathMethod
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  [Flags]
  public enum PathMethod : ushort
  {
    Pedestrian = 1,
    Road = 2,
    Parking = 4,
    PublicTransportDay = 8,
    Track = 16, // 0x0010
    Taxi = 32, // 0x0020
    CargoTransport = 64, // 0x0040
    CargoLoading = 128, // 0x0080
    Flying = 256, // 0x0100
    PublicTransportNight = 512, // 0x0200
    Boarding = 1024, // 0x0400
    Offroad = 2048, // 0x0800
  }
}
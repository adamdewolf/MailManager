﻿// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.TaxiFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum TaxiFlags : uint
  {
    Returning = 1,
    Requested = 2,
    Arriving = 4,
    Boarding = 8,
    Disembarking = 16, // 0x00000010
    Transporting = 32, // 0x00000020
    RequiresMaintenance = 64, // 0x00000040
    Dispatched = 128, // 0x00000080
    FromOutside = 256, // 0x00000100
    Disabled = 512, // 0x00000200
  }
}
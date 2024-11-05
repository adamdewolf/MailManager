// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.AircraftFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum AircraftFlags : uint
  {
    StayOnTaxiway = 1,
    Emergency = 2,
    StayMidAir = 4,
    Blocking = 8,
    Working = 16, // 0x00000010
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.WatercraftFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum WatercraftFlags : uint
  {
    StayOnWaterway = 1,
    AnyLaneTarget = 2,
    Queueing = 4,
    DeckLights = 8,
    LightsOff = 16, // 0x00000010
  }
}

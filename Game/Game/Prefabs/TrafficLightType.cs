// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TrafficLightType
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum TrafficLightType
  {
    VehicleLeft = 1,
    VehicleRight = 2,
    CrossingLeft = 4,
    CrossingRight = 8,
    AllowFlipped = 16, // 0x00000010
  }
}

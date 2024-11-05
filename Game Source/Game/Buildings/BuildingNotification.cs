// Decompiled with JetBrains decompiler
// Type: Game.Buildings.BuildingNotification
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Buildings
{
  [Flags]
  public enum BuildingNotification : byte
  {
    None = 0,
    AirPollution = 1,
    NoisePollution = 2,
    GroundPollution = 4,
  }
}

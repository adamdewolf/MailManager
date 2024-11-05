// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.RoadFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum RoadFlags
  {
    EnableZoning = 1,
    SeparatedCarriageways = 2,
    PreferTrafficLights = 4,
    DefaultIsForward = 8,
    UseHighwayRules = 16, // 0x00000010
    DefaultIsBackward = 32, // 0x00000020
    HasStreetLights = 64, // 0x00000040
  }
}

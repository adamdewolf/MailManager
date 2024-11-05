// Decompiled with JetBrains decompiler
// Type: Game.Rendering.DecalLayers
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Rendering
{
  [Flags]
  public enum DecalLayers
  {
    Terrain = 1,
    Roads = 2,
    Buildings = 4,
    Vehicles = 8,
    Creatures = 16, // 0x00000010
    Other = 32, // 0x00000020
  }
}

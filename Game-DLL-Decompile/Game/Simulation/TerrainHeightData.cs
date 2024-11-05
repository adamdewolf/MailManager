// Decompiled with JetBrains decompiler
// Type: Game.Simulation.TerrainHeightData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public struct TerrainHeightData
  {
    public NativeArray<ushort> heights { get; private set; }

    public int3 resolution { get; private set; }

    public float3 scale { get; private set; }

    public float3 offset { get; private set; }

    public bool isCreated => this.heights.IsCreated;

    public TerrainHeightData(
      NativeArray<ushort> _heights,
      int3 _resolution,
      float3 _scale,
      float3 _offset)
    {
      this.heights = _heights;
      this.resolution = _resolution;
      this.scale = _scale;
      this.offset = _offset;
    }
  }
}

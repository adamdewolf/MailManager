// Decompiled with JetBrains decompiler
// Type: Game.Simulation.WaterSurfaceData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public struct WaterSurfaceData
  {
    public NativeArray<SurfaceWater> depths { get; private set; }

    public int3 resolution { get; private set; }

    public float3 scale { get; private set; }

    public float3 offset { get; private set; }

    public bool isCreated => this.depths.IsCreated;

    public WaterSurfaceData(
      NativeArray<SurfaceWater> _depths,
      int3 _resolution,
      float3 _scale,
      float3 _offset)
    {
      this.depths = _depths;
      this.resolution = _resolution;
      this.scale = _scale;
      this.offset = _offset;
    }
  }
}

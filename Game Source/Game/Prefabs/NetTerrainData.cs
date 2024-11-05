// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetTerrainData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct NetTerrainData : IComponentData, IQueryTypeParameter
  {
    public float2 m_WidthOffset;
    public float2 m_ClipHeightOffset;
    public float3 m_MinHeightOffset;
    public float3 m_MaxHeightOffset;
  }
}

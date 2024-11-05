// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetCompositionMeshData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct NetCompositionMeshData : IComponentData, IQueryTypeParameter
  {
    public MeshLayer m_DefaultLayers;
    public MeshLayer m_AvailableLayers;
    public MeshFlags m_State;
    public CompositionFlags m_Flags;
    public Bounds1 m_HeightRange;
    public float m_Width;
    public float m_IndexFactor;
    public float m_LodBias;
    public float m_ShadowBias;
    public int m_Hash;
  }
}

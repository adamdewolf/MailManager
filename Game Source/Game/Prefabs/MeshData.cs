﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MeshData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Rendering;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct MeshData : IComponentData, IQueryTypeParameter
  {
    public Bounds3 m_Bounds;
    public MeshFlags m_State;
    public DecalLayers m_DecalLayer;
    public MeshLayer m_DefaultLayers;
    public MeshLayer m_AvailableLayers;
    public MeshType m_AvailableTypes;
    public byte m_MinLod;
    public byte m_ShadowLod;
    public float m_LodBias;
    public float m_ShadowBias;
    public float m_SmoothingDistance;
    public int m_SubMeshCount;
    public int m_IndexCount;
    public int m_TilingCount;
  }
}
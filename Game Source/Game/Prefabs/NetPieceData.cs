﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetPieceData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct NetPieceData : IComponentData, IQueryTypeParameter
  {
    public Bounds1 m_HeightRange;
    public float4 m_SurfaceHeights;
    public float m_Width;
    public float m_Length;
    public float m_WidthOffset;
    public float m_NodeOffset;
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetPieceLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct NetPieceLane : IBufferElementData, IComparable<NetPieceLane>
  {
    public Entity m_Lane;
    public float3 m_Position;
    public LaneFlags m_ExtraFlags;

    public int CompareTo(NetPieceLane other)
    {
      return math.select(0, math.select(-1, 1, (double) this.m_Position.x > (double) other.m_Position.x), (double) this.m_Position.x != (double) other.m_Position.x);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.LaneObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Net
{
  [InternalBufferCapacity(0)]
  public struct LaneObject : 
    IBufferElementData,
    IEquatable<LaneObject>,
    IComparable<LaneObject>,
    IEmptySerializable
  {
    public Entity m_LaneObject;
    public float2 m_CurvePosition;

    public LaneObject(Entity laneObject)
    {
      this.m_LaneObject = laneObject;
      this.m_CurvePosition = new float2();
    }

    public LaneObject(Entity laneObject, float2 curvePosition)
    {
      this.m_LaneObject = laneObject;
      this.m_CurvePosition = curvePosition;
    }

    public bool Equals(LaneObject other) => this.m_LaneObject.Equals(other.m_LaneObject);

    public int CompareTo(LaneObject other)
    {
      return (int) math.sign(this.m_CurvePosition.x - other.m_CurvePosition.x);
    }

    public override int GetHashCode()
    {
      return (17 * 31 + this.m_LaneObject.GetHashCode()) * 31 + this.m_CurvePosition.GetHashCode();
    }
  }
}
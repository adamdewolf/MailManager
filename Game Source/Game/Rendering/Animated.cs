﻿// Decompiled with JetBrains decompiler
// Type: Game.Rendering.Animated
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Rendering
{
  [InternalBufferCapacity(1)]
  public struct Animated : IBufferElementData, IEmptySerializable
  {
    public NativeHeapBlock m_BoneAllocation;
    public int m_MetaIndex;
    public float4 m_Time;
    public float2 m_MovementSpeed;
    public float m_Interpolation;
    public float m_PreviousTime;
    public short m_ClipIndexBody0;
    public short m_ClipIndexBody0I;
    public short m_ClipIndexBody1;
    public short m_ClipIndexBody1I;
    public short m_ClipIndexFace0;
    public short m_ClipIndexFace1;
  }
}
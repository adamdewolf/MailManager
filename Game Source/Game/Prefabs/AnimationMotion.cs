﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AnimationMotion
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct AnimationMotion : IBufferElementData
  {
    public float3 m_StartOffset;
    public float3 m_EndOffset;
    public quaternion m_StartRotation;
    public quaternion m_EndRotation;
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ActivityLocationElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Rendering;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct ActivityLocationElement : IBufferElementData
  {
    public Entity m_Prefab;
    public ActivityMask m_ActivityMask;
    public ActivityFlags m_ActivityFlags;
    public float3 m_Position;
    public quaternion m_Rotation;
    public AnimatedPropID m_PropID;
  }
}
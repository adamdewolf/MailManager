﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SubMesh
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(1)]
  public struct SubMesh : IBufferElementData, IEmptySerializable
  {
    public Entity m_SubMesh;
    public float3 m_Position;
    public quaternion m_Rotation;
    public SubMeshFlags m_Flags;
    public ushort m_RandomSeed;

    public SubMesh(Entity mesh, SubMeshFlags flags, ushort randomSeed)
    {
      this.m_SubMesh = mesh;
      this.m_Position = new float3();
      this.m_Rotation = quaternion.identity;
      this.m_Flags = flags;
      this.m_RandomSeed = randomSeed;
    }

    public SubMesh(
      Entity mesh,
      float3 position,
      quaternion rotation,
      SubMeshFlags flags,
      ushort randomSeed)
    {
      this.m_SubMesh = mesh;
      this.m_Position = position;
      this.m_Rotation = rotation;
      this.m_Flags = flags;
      this.m_RandomSeed = randomSeed;
    }
  }
}
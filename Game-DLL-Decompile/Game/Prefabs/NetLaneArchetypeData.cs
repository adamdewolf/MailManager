﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetLaneArchetypeData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct NetLaneArchetypeData : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public EntityArchetype m_LaneArchetype;
    public EntityArchetype m_AreaLaneArchetype;
    public EntityArchetype m_EdgeLaneArchetype;
    public EntityArchetype m_EdgeSlaveArchetype;
    public EntityArchetype m_EdgeMasterArchetype;
    public EntityArchetype m_NodeLaneArchetype;
    public EntityArchetype m_NodeSlaveArchetype;
    public EntityArchetype m_NodeMasterArchetype;
  }
}
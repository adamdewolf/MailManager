﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PlaceableNetPiece
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/", new Type[] {typeof (NetPiecePrefab)})]
  public class PlaceableNetPiece : ComponentBase
  {
    public uint m_ConstructionCost;
    public uint m_ElevationCost;
    public float m_UpkeepCost;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<PlaceableNetPieceData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<PlaceableNetPieceData>(entity, new PlaceableNetPieceData()
      {
        m_ConstructionCost = this.m_ConstructionCost,
        m_ElevationCost = this.m_ElevationCost,
        m_UpkeepCost = this.m_UpkeepCost
      });
    }
  }
}
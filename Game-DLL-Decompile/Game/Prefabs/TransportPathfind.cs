﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TransportPathfind
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Pathfind/", new Type[] {typeof (PathfindPrefab)})]
  public class TransportPathfind : ComponentBase
  {
    public PathfindCostInfo m_OrderingCost = new PathfindCostInfo(5f, 0.0f, 0.0f, 5f);
    public PathfindCostInfo m_StartingCost = new PathfindCostInfo(5f, 0.0f, 10f, 5f);
    public PathfindCostInfo m_TravelCost = new PathfindCostInfo(0.0f, 0.0f, 0.02f, 0.0f);

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<PathfindTransportData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<PathfindTransportData>(entity, new PathfindTransportData()
      {
        m_OrderingCost = this.m_OrderingCost.ToPathfindCosts(),
        m_StartingCost = this.m_StartingCost.ToPathfindCosts(),
        m_TravelCost = this.m_TravelCost.ToPathfindCosts()
      });
    }
  }
}
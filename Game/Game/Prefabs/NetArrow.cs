﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetArrow
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Net;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/", new System.Type[] {typeof (AggregateNetPrefab)})]
  public class NetArrow : ComponentBase
  {
    public Material m_ArrowMaterial;
    public Color m_RoadArrowColor = Color.white;
    public Color m_TrackArrowColor = Color.white;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<NetArrowData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ArrowMaterial>());
      components.Add(ComponentType.ReadWrite<ArrowPosition>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<NetArrowData>(entity, new NetArrowData()
      {
        m_RoadColor = (Color32) this.m_RoadArrowColor.linear,
        m_TrackColor = (Color32) this.m_TrackArrowColor.linear
      });
    }
  }
}
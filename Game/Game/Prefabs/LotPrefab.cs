﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LotPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Areas;
using Game.Common;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Areas/", new System.Type[] {})]
  public class LotPrefab : AreaPrefab
  {
    public float m_MaxRadius = 200f;
    public UnityEngine.Color m_RangeColor = UnityEngine.Color.white;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<LotData>());
      components.Add(ComponentType.ReadWrite<AreaGeometryData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
      components.Add(ComponentType.ReadWrite<Lot>());
      components.Add(ComponentType.ReadWrite<Geometry>());
      components.Add(ComponentType.ReadWrite<Game.Objects.SubObject>());
      components.Add(ComponentType.ReadWrite<PseudoRandomSeed>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<LotData>(entity, new LotData(this.m_MaxRadius, (Color32) this.m_RangeColor));
    }
  }
}
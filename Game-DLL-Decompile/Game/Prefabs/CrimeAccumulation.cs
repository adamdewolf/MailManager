﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CrimeAccumulation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Services/", new Type[] {typeof (ServicePrefab), typeof (ZonePrefab)})]
  public class CrimeAccumulation : ComponentBase
  {
    public float m_CrimeRate = 7f;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<CrimeAccumulationData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      CrimeAccumulationData componentData;
      componentData.m_CrimeRate = this.m_CrimeRate;
      entityManager.SetComponentData<CrimeAccumulationData>(entity, componentData);
    }
  }
}
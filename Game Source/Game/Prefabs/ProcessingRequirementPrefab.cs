﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ProcessingRequirementPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Prefabs/Unlocking/", new Type[] {})]
  public class ProcessingRequirementPrefab : UnlockRequirementPrefab
  {
    public ResourceInEditor m_ResourceType;
    public int m_MinimumProducedAmount = 10000;

    public override void GetDependencies(List<PrefabBase> prefabs) => base.GetDependencies(prefabs);

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<ProcessingRequirementData>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      entityManager.GetBuffer<UnlockRequirement>(entity).Add(new UnlockRequirement(entity, UnlockFlags.RequireAll));
      entityManager.SetComponentData<ProcessingRequirementData>(entity, new ProcessingRequirementData()
      {
        m_ResourceType = EconomyUtils.GetResource(this.m_ResourceType),
        m_MinimumProducedAmount = this.m_MinimumProducedAmount
      });
    }
  }
}
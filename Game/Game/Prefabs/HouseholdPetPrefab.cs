﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.HouseholdPetPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Citizens;
using Game.Simulation;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Citizens/", new Type[] {})]
  public class HouseholdPetPrefab : ArchetypePrefab
  {
    public PetType m_Type;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<HouseholdPetData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
      components.Add(ComponentType.ReadWrite<HouseholdPet>());
      components.Add(ComponentType.ReadWrite<UpdateFrame>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      HouseholdPetData componentData;
      componentData.m_Type = this.m_Type;
      entityManager.SetComponentData<HouseholdPetData>(entity, componentData);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BuildingOptions
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Buildings;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Policies/", new Type[] {typeof (PolicyPrefab)})]
  public class BuildingOptions : ComponentBase
  {
    public BuildingOption[] m_Options;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<BuildingOptionData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      if (this.m_Options == null)
        return;
      BuildingOptionData componentData = new BuildingOptionData();
      for (int index = 0; index < this.m_Options.Length; ++index)
        componentData.m_OptionMask |= 1U << (int) (this.m_Options[index] & (BuildingOption) 31);
      entityManager.SetComponentData<BuildingOptionData>(entity, componentData);
    }
  }
}
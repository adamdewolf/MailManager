﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CityOptions
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Policies/", new Type[] {typeof (PolicyPrefab)})]
  public class CityOptions : ComponentBase
  {
    public CityOption[] m_Options;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<CityOptionData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      if (this.m_Options == null)
        return;
      CityOptionData componentData = new CityOptionData();
      for (int index = 0; index < this.m_Options.Length; ++index)
        componentData.m_OptionMask |= 1U << (int) (this.m_Options[index] & (CityOption) 31);
      entityManager.SetComponentData<CityOptionData>(entity, componentData);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BrandPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Companies/", new System.Type[] {})]
  public class BrandPrefab : PrefabBase
  {
    public CompanyPrefab[] m_Companies;
    public Color[] m_BrandColors;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      for (int index = 0; index < this.m_Companies.Length; ++index)
        prefabs.Add((PrefabBase) this.m_Companies[index]);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<BrandData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      BrandData componentData = new BrandData();
      for (int index = 0; index < this.m_BrandColors.Length; ++index)
        componentData.m_ColorSet[index] = this.m_BrandColors[index];
      entityManager.SetComponentData<BrandData>(entity, componentData);
    }
  }
}
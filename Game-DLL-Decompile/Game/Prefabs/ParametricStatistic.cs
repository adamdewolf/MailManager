﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ParametricStatistic
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
  [ComponentMenu("Statistics/", new Type[] {})]
  public abstract class ParametricStatistic : StatisticsPrefab
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<StatisticParameterData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
      components.Add(ComponentType.ReadWrite<StatisticParameter>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      DynamicBuffer<StatisticParameterData> buffer = entityManager.GetBuffer<StatisticParameterData>(entity);
      foreach (StatisticParameterData parameter in this.GetParameters())
        buffer.Add(parameter);
    }

    public abstract IEnumerable<StatisticParameterData> GetParameters();

    public abstract string GetParameterName(int parameter);
  }
}
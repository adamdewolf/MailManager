﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TimeSettingsPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Settings/", new Type[] {})]
  public class TimeSettingsPrefab : PrefabBase
  {
    public int m_DaysPerYear = 12;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<TimeSettingsData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      entityManager.SetComponentData<TimeSettingsData>(entity, new TimeSettingsData()
      {
        m_DaysPerYear = this.m_DaysPerYear
      });
    }
  }
}
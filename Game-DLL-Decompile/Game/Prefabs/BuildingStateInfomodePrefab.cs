﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BuildingStateInfomodePrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tools/Infomode/", new Type[] {})]
  public class BuildingStateInfomodePrefab : ColorInfomodeBasePrefab
  {
    public BuildingStatusType m_Type;

    public override string infomodeTypeLocaleKey => "BuildingColor";

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<InfoviewBuildingStatusData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<InfoviewBuildingStatusData>(entity, new InfoviewBuildingStatusData()
      {
        m_Type = this.m_Type
      });
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.VehicleInfomodePrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tools/Infomode/", new Type[] {})]
  public class VehicleInfomodePrefab : ColorInfomodeBasePrefab
  {
    public VehicleType m_Type;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<InfoviewVehicleData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<InfoviewVehicleData>(entity, new InfoviewVehicleData()
      {
        m_Type = this.m_Type,
        m_Color = new float4(this.m_Color.r, this.m_Color.g, this.m_Color.b, this.m_Color.a)
      });
    }
  }
}
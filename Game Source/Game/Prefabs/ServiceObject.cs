﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ServiceObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Services/", new Type[] {typeof (ObjectPrefab), typeof (NetPrefab), typeof (AreaPrefab), typeof (ZonePrefab), typeof (RoutePrefab), typeof (TerraformingPrefab)})]
  public class ServiceObject : ComponentBase
  {
    public ServicePrefab m_Service;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ServiceObjectData>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      // ISSUE: variable of a compiler-generated type
      PrefabSystem existingSystemManaged = entityManager.World.GetExistingSystemManaged<PrefabSystem>();
      // ISSUE: reference to a compiler-generated method
      entityManager.SetComponentData<ServiceObjectData>(entity, new ServiceObjectData()
      {
        m_Service = existingSystemManaged.GetEntity((PrefabBase) this.m_Service)
      });
    }

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      prefabs.Add((PrefabBase) this.m_Service);
    }
  }
}
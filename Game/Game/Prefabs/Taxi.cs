﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Taxi
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Simulation;
using Game.Vehicles;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Vehicles/", new Type[] {typeof (CarPrefab)})]
  public class Taxi : ComponentBase
  {
    public int m_PassengerCapacity = 4;
    public float m_MaintenanceRange = 600f;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<TaxiData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Vehicles.Taxi>());
      components.Add(ComponentType.ReadWrite<Odometer>());
      components.Add(ComponentType.ReadWrite<Passenger>());
      components.Add(ComponentType.ReadWrite<ServiceDispatch>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<TaxiData>(entity, new TaxiData(this.m_PassengerCapacity, this.m_MaintenanceRange * 1000f));
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(6));
    }
  }
}
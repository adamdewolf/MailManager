// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CargoTransport
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using Game.Pathfind;
using Game.Simulation;
using Game.Vehicles;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Vehicles/", new Type[] {typeof (VehiclePrefab)})]
  public class CargoTransport : ComponentBase
  {
    public int m_CargoCapacity = 10000;
    public int m_MaxResourceCount = 1;
    public float m_MaintenanceRange;
    public ResourceInEditor[] m_TransportedResources;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<CargoTransportVehicleData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Vehicles.CargoTransport>());
      components.Add(ComponentType.ReadWrite<Odometer>());
      components.Add(ComponentType.ReadWrite<Resources>());
      components.Add(ComponentType.ReadWrite<PathInformation>());
      components.Add(ComponentType.ReadWrite<ServiceDispatch>());
      components.Add(ComponentType.ReadWrite<LoadingResources>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      Resource resources = Resource.NoResource;
      if (this.m_TransportedResources != null)
      {
        for (int index = 0; index < this.m_TransportedResources.Length; ++index)
          resources |= EconomyUtils.GetResource(this.m_TransportedResources[index]);
      }
      entityManager.SetComponentData<CargoTransportVehicleData>(entity, new CargoTransportVehicleData(resources, this.m_CargoCapacity, this.m_MaxResourceCount, this.m_MaintenanceRange * 1000f));
    }
  }
}

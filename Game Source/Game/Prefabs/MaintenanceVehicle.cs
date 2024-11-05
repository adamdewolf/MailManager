// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MaintenanceVehicle
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using Game.Simulation;
using Game.Vehicles;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Vehicles/", new Type[] {typeof (CarPrefab)})]
  public class MaintenanceVehicle : ComponentBase
  {
    public MaintenanceType m_MaintenanceType = MaintenanceType.Park;
    public int m_MaintenanceCapacity = 1000;
    public int m_MaintenanceRate = 200;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<MaintenanceVehicleData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Vehicles.MaintenanceVehicle>());
      components.Add(ComponentType.ReadWrite<PathInformation>());
      components.Add(ComponentType.ReadWrite<ServiceDispatch>());
      if ((this.m_MaintenanceType & MaintenanceType.Park) != MaintenanceType.None)
        components.Add(ComponentType.ReadWrite<ParkMaintenanceVehicle>());
      if ((this.m_MaintenanceType & (MaintenanceType.Road | MaintenanceType.Snow | MaintenanceType.Vehicle)) == MaintenanceType.None)
        return;
      components.Add(ComponentType.ReadWrite<RoadMaintenanceVehicle>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.SetComponentData<MaintenanceVehicleData>(entity, new MaintenanceVehicleData(this.m_MaintenanceType, this.m_MaintenanceCapacity, this.m_MaintenanceRate));
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(7));
    }
  }
}

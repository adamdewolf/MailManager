// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Ambulance
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using Game.PSI;
using Game.Simulation;
using Game.Vehicles;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ExcludeGeneratedModTag]
  [ComponentMenu("Vehicles/", new System.Type[] {typeof (CarPrefab), typeof (AircraftPrefab)})]
  public class Ambulance : ComponentBase
  {
    public int m_PatientCapacity = 1;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<AmbulanceData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Vehicles.Ambulance>());
      components.Add(ComponentType.ReadWrite<Passenger>());
      components.Add(ComponentType.ReadWrite<PathInformation>());
      components.Add(ComponentType.ReadWrite<ServiceDispatch>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.SetComponentData<AmbulanceData>(entity, new AmbulanceData(this.m_PatientCapacity));
      if (!entityManager.HasComponent<CarData>(entity))
        return;
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(0));
    }

    public override IEnumerable<string> modTags
    {
      get
      {
        Ambulance ambulance = this;
        foreach (string modTag in ambulance.\u003C\u003En__0())
          yield return modTag;
        if ((UnityEngine.Object) ambulance.GetComponent<AircraftPrefab>() != (UnityEngine.Object) null)
          yield return "AmbulanceAircraft";
        else
          yield return nameof (Ambulance);
      }
    }
  }
}

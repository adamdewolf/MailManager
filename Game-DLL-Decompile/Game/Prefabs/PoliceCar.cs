// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PoliceCar
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;
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
  public class PoliceCar : ComponentBase
  {
    public int m_CriminalCapacity = 2;
    public float m_CrimeReductionRate = 10000f;
    public float m_ShiftDuration = 1f;
    [EnumFlag]
    public PolicePurpose m_Purposes = PolicePurpose.Patrol | PolicePurpose.Emergency;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<PoliceCarData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Vehicles.PoliceCar>());
      components.Add(ComponentType.ReadWrite<Passenger>());
      components.Add(ComponentType.ReadWrite<PathInformation>());
      components.Add(ComponentType.ReadWrite<ServiceDispatch>());
      components.Add(ComponentType.ReadWrite<PointOfInterest>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      uint shiftDuration = (uint) ((double) this.m_ShiftDuration * 262144.0);
      entityManager.SetComponentData<PoliceCarData>(entity, new PoliceCarData(this.m_CriminalCapacity, this.m_CrimeReductionRate, shiftDuration, this.m_Purposes));
      if (!entityManager.HasComponent<CarData>(entity))
        return;
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(5));
    }

    public override IEnumerable<string> modTags
    {
      get
      {
        PoliceCar policeCar = this;
        foreach (string modTag in policeCar.\u003C\u003En__0())
          yield return modTag;
        if ((UnityEngine.Object) policeCar.GetComponent<AircraftPrefab>() != (UnityEngine.Object) null)
          yield return "PoliceCarAircraft";
        else
          yield return nameof (PoliceCar);
      }
    }
  }
}

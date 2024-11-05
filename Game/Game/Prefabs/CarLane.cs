// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CarLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Net;
using Game.Simulation;
using Game.Vehicles;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/", new System.Type[] {typeof (NetLanePrefab)})]
  public class CarLane : ComponentBase
  {
    public NetLanePrefab m_NotTrackLane;
    public NetLanePrefab m_NotBusLane;
    public RoadTypes m_RoadType = RoadTypes.Car;
    public SizeClass m_MaxSize = SizeClass.Large;
    public float m_Width = 3f;
    public bool m_StartingLane;
    public bool m_EndingLane;
    public bool m_Twoway;
    public bool m_BusLane;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      if ((UnityEngine.Object) this.m_NotTrackLane != (UnityEngine.Object) null)
        prefabs.Add((PrefabBase) this.m_NotTrackLane);
      if (!((UnityEngine.Object) this.m_NotBusLane != (UnityEngine.Object) null))
        return;
      prefabs.Add((PrefabBase) this.m_NotBusLane);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<CarLaneData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Net.CarLane>());
      if (components.Contains(ComponentType.ReadWrite<MasterLane>()))
        return;
      components.Add(ComponentType.ReadWrite<LaneObject>());
      components.Add(ComponentType.ReadWrite<Game.Net.LaneReservation>());
      components.Add(ComponentType.ReadWrite<LaneFlow>());
      components.Add(ComponentType.ReadWrite<LaneOverlap>());
      components.Add(ComponentType.ReadWrite<UpdateFrame>());
    }
  }
}

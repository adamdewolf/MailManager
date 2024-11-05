// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Hearse
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
  public class Hearse : ComponentBase
  {
    public int m_CorpseCapacity = 1;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<HearseData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Vehicles.Hearse>());
      components.Add(ComponentType.ReadWrite<Passenger>());
      components.Add(ComponentType.ReadWrite<PathInformation>());
      components.Add(ComponentType.ReadWrite<ServiceDispatch>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.SetComponentData<HearseData>(entity, new HearseData(this.m_CorpseCapacity));
      if (!entityManager.HasComponent<CarData>(entity))
        return;
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(11));
    }
  }
}

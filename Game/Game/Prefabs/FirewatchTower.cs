// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FirewatchTower
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Buildings;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Buildings/CityServices/", new System.Type[] {typeof (BuildingPrefab), typeof (BuildingExtensionPrefab)})]
  public class FirewatchTower : ComponentBase, IServiceUpgrade
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<FirewatchTowerData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Buildings.FirewatchTower>());
      if (!((UnityEngine.Object) this.GetComponent<ServiceUpgrade>() == (UnityEngine.Object) null) || !((UnityEngine.Object) this.GetComponent<CityServiceBuilding>() != (UnityEngine.Object) null))
        return;
      components.Add(ComponentType.ReadWrite<Efficiency>());
    }

    public void GetUpgradeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Buildings.FirewatchTower>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(1));
    }
  }
}

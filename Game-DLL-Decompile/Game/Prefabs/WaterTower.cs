// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WaterTower
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Buildings/CityServices/", new Type[] {typeof (BuildingPrefab), typeof (BuildingExtensionPrefab)})]
  public class WaterTower : ComponentBase
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<WaterTowerData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Buildings.WaterTower>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.AddComponent<WaterTowerData>(entity);
    }
  }
}

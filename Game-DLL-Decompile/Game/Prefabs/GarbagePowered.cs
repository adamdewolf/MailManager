// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.GarbagePowered
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [RequireComponent(typeof (GarbageFacility), typeof (PowerPlant))]
  [ComponentMenu("Buildings/CityServices/", new System.Type[] {typeof (BuildingPrefab), typeof (BuildingExtensionPrefab)})]
  public class GarbagePowered : ComponentBase
  {
    public float m_ProductionPerUnit;
    public int m_Capacity;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<GarbagePoweredData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.SetComponentData<GarbagePoweredData>(entity, new GarbagePoweredData()
      {
        m_ProductionPerUnit = this.m_ProductionPerUnit,
        m_Capacity = this.m_Capacity
      });
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AnimalPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;
using Game.Creatures;
using Game.Vehicles;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Creatures/", new Type[] {})]
  public class AnimalPrefab : CreaturePrefab
  {
    public float m_MoveSpeed = 20f;
    public float m_Acceleration = 10f;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<AnimalData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
      components.Add(ComponentType.ReadWrite<Animal>());
      components.Add(ComponentType.ReadWrite<AnimalNavigation>());
      components.Add(ComponentType.ReadWrite<Target>());
      components.Add(ComponentType.ReadWrite<Blocker>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      AnimalData componentData = entityManager.GetComponentData<AnimalData>(entity) with
      {
        m_MoveSpeed = this.m_MoveSpeed / 3.6f,
        m_Acceleration = this.m_Acceleration
      };
      entityManager.SetComponentData<AnimalData>(entity, componentData);
    }
  }
}

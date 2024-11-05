// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FlyingAnimal
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Creatures/", new Type[] {typeof (AnimalPrefab)})]
  public class FlyingAnimal : ComponentBase
  {
    public float m_FlySpeed = 100f;
    public Bounds1 m_FlyHeight = new Bounds1(20f, 100f);

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      AnimalData componentData = entityManager.GetComponentData<AnimalData>(entity) with
      {
        m_FlySpeed = this.m_FlySpeed / 3.6f,
        m_FlyHeight = this.m_FlyHeight
      };
      entityManager.SetComponentData<AnimalData>(entity, componentData);
    }
  }
}

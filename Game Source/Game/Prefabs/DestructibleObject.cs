﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DestructibleObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Objects/", new Type[] {typeof (ObjectPrefab)})]
  public class DestructibleObject : ComponentBase
  {
    public float m_FireHazard = 100f;
    public float m_StructuralIntegrity = 15000f;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<DestructibleObjectData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      DestructibleObjectData componentData;
      componentData.m_FireHazard = this.m_FireHazard;
      componentData.m_StructuralIntegrity = this.m_StructuralIntegrity;
      entityManager.SetComponentData<DestructibleObjectData>(entity, componentData);
    }
  }
}
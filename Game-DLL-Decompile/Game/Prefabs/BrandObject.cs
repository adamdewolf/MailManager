﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BrandObject
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
  public class BrandObject : ComponentBase
  {
    public BrandPrefab m_Brand;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      prefabs.Add((PrefabBase) this.m_Brand);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ObjectRequirementElement>());
      components.Add(ComponentType.ReadWrite<BrandObjectData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      // ISSUE: variable of a compiler-generated type
      PrefabSystem existingSystemManaged = entityManager.World.GetExistingSystemManaged<PrefabSystem>();
      DynamicBuffer<ObjectRequirementElement> buffer = entityManager.GetBuffer<ObjectRequirementElement>(entity);
      int length = buffer.Length;
      // ISSUE: reference to a compiler-generated method
      buffer.Add(new ObjectRequirementElement(existingSystemManaged.GetEntity((PrefabBase) this.m_Brand), length));
    }
  }
}
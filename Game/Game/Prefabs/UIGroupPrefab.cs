﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UIGroupPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("UI/", new Type[] {})]
  public abstract class UIGroupPrefab : PrefabBase
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<UIGroupElement>());
      components.Add(ComponentType.ReadWrite<UnlockRequirement>());
      components.Add(ComponentType.ReadWrite<Locked>());
    }

    public void AddElement(EntityManager entityManager, Entity entity)
    {
      // ISSUE: reference to a compiler-generated method
      Entity entity1 = entityManager.World.GetExistingSystemManaged<PrefabSystem>().GetEntity((PrefabBase) this);
      entityManager.GetBuffer<UIGroupElement>(entity1).Add(new UIGroupElement(entity));
      entityManager.GetBuffer<UnlockRequirement>(entity1).Add(new UnlockRequirement(entity, UnlockFlags.RequireAny));
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      entityManager.GetBuffer<UnlockRequirement>(entity).Add(new UnlockRequirement(entity, UnlockFlags.RequireAny));
      base.LateInitialize(entityManager, entity);
    }
  }
}
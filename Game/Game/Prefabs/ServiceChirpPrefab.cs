﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ServiceChirpPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Triggers/", new System.Type[] {})]
  public class ServiceChirpPrefab : ChirpPrefab
  {
    public PrefabBase m_Account;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      if (!((UnityEngine.Object) this.m_Account != (UnityEngine.Object) null))
        return;
      prefabs.Add(this.m_Account);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<ServiceChirpData>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      // ISSUE: variable of a compiler-generated type
      PrefabSystem existingSystemManaged = entityManager.World.GetExistingSystemManaged<PrefabSystem>();
      if (!((UnityEngine.Object) this.m_Account != (UnityEngine.Object) null))
        return;
      // ISSUE: reference to a compiler-generated method
      Entity entity1 = existingSystemManaged.GetEntity(this.m_Account);
      entityManager.SetComponentData<ServiceChirpData>(entity, new ServiceChirpData()
      {
        m_Account = entity1
      });
    }
  }
}
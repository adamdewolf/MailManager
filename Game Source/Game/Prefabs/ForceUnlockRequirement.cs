﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ForceUnlockRequirement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Prefabs/Unlocking", new System.Type[] {typeof (UIGroupPrefab)})]
  public class ForceUnlockRequirement : ComponentBase
  {
    public PrefabBase m_Prefab;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ForceUnlockRequirementData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      Entity entity1;
      // ISSUE: reference to a compiler-generated method
      if (!((UnityEngine.Object) this.m_Prefab != (UnityEngine.Object) null) || !entityManager.World.GetExistingSystemManaged<PrefabSystem>().TryGetEntity(this.m_Prefab, out entity1))
        return;
      ForceUnlockRequirementData componentData;
      componentData.m_Prefab = entity1;
      entityManager.SetComponentData<ForceUnlockRequirementData>(entity, componentData);
    }
  }
}
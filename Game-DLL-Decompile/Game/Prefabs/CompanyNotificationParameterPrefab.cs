// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CompanyNotificationParameterPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Settings/", new Type[] {})]
  public class CompanyNotificationParameterPrefab : PrefabBase
  {
    public NotificationIconPrefab m_NoInputsNotificationPrefab;
    public NotificationIconPrefab m_NoCustomersNotificationPrefab;
    public float m_NoInputCostLimit = 5f;
    public float m_NoCustomersServiceLimit = 0.9f;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      prefabs.Add((PrefabBase) this.m_NoInputsNotificationPrefab);
      prefabs.Add((PrefabBase) this.m_NoCustomersNotificationPrefab);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<CompanyNotificationParameterData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      // ISSUE: variable of a compiler-generated type
      PrefabSystem systemManaged = entityManager.World.GetOrCreateSystemManaged<PrefabSystem>();
      CompanyNotificationParameterData componentData;
      // ISSUE: reference to a compiler-generated method
      componentData.m_NoCustomersNotificationPrefab = systemManaged.GetEntity((PrefabBase) this.m_NoCustomersNotificationPrefab);
      // ISSUE: reference to a compiler-generated method
      componentData.m_NoInputsNotificationPrefab = systemManaged.GetEntity((PrefabBase) this.m_NoInputsNotificationPrefab);
      componentData.m_NoCustomersServiceLimit = this.m_NoCustomersServiceLimit;
      componentData.m_NoInputCostLimit = this.m_NoInputCostLimit;
      entityManager.SetComponentData<CompanyNotificationParameterData>(entity, componentData);
    }
  }
}

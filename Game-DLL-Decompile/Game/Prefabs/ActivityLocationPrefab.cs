// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ActivityLocationPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Objects/", new Type[] {})]
  public class ActivityLocationPrefab : TransformPrefab
  {
    public ActivityType[] m_Activities;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<ActivityLocationData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      ActivityLocationData componentData;
      componentData.m_ActivityMask = new ActivityMask();
      if (this.m_Activities != null)
      {
        for (int index = 0; index < this.m_Activities.Length; ++index)
          componentData.m_ActivityMask.m_Mask |= new ActivityMask(this.m_Activities[index]).m_Mask;
      }
      entityManager.SetComponentData<ActivityLocationData>(entity, componentData);
    }
  }
}

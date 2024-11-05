// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TriggerLimit
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Triggers/", new System.Type[] {typeof (TriggerPrefab)})]
  public class TriggerLimit : ComponentBase
  {
    public float m_IntervalSeconds;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<TriggerLimitData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<TriggerLimitData>(entity, new TriggerLimitData()
      {
        m_FrameInterval = (uint) Mathf.RoundToInt(this.m_IntervalSeconds * 60f)
      });
    }
  }
}

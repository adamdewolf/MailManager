// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CullingEffect
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Effects/", new System.Type[] {typeof (EffectPrefab)})]
  public class CullingEffect : ComponentBase
  {
    [Tooltip("The audio culling group")]
    public CullingEffect.AudioCullingGroup m_AudioCullGroup;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      if (this.m_AudioCullGroup == CullingEffect.AudioCullingGroup.None)
        return;
      components.Add(ComponentType.ReadWrite<CullingGroupData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      if (this.m_AudioCullGroup == CullingEffect.AudioCullingGroup.None)
        return;
      CullingGroupData componentData = new CullingGroupData()
      {
        m_GroupIndex = (int) this.m_AudioCullGroup
      };
      entityManager.SetComponentData<CullingGroupData>(entity, componentData);
    }

    public enum AudioCullingGroup : byte
    {
      None,
      Fire,
      CarEngine,
      PublicTrans,
      Count,
    }
  }
}

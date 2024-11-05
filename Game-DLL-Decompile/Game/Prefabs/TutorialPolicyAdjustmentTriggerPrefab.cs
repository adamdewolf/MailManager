// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TutorialPolicyAdjustmentTriggerPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Tutorials;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tutorials/Triggers/", new Type[] {})]
  public class TutorialPolicyAdjustmentTriggerPrefab : TutorialTriggerPrefabBase
  {
    public PolicyAdjustmentTriggerFlags m_Flags;
    public PolicyAdjustmentTriggerTargetFlags m_TargetFlags;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<PolicyAdjustmentTriggerData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<PolicyAdjustmentTriggerData>(entity, new PolicyAdjustmentTriggerData(this.m_Flags, this.m_TargetFlags));
    }
  }
}

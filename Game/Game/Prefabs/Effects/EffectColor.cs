// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Effects.EffectColor
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs.Effects
{
  [ComponentMenu("Effects/", new System.Type[] {typeof (EffectPrefab)})]
  public class EffectColor : ComponentBase
  {
    public EffectColorSource m_Source;
    [Range(0.0f, 100f)]
    public float m_HueRandomness;
    [Range(0.0f, 100f)]
    public float m_SaturationRandomness;
    [Range(0.0f, 100f)]
    public float m_BrightnessRandomness;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<EffectColorData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      EffectColorData componentData = entityManager.GetComponentData<EffectColorData>(entity) with
      {
        m_Source = this.m_Source
      };
      componentData.m_VaritationRanges.x = this.m_HueRandomness * 0.01f;
      componentData.m_VaritationRanges.y = this.m_SaturationRandomness * 0.01f;
      componentData.m_VaritationRanges.z = this.m_BrightnessRandomness * 0.01f;
      entityManager.SetComponentData<EffectColorData>(entity, componentData);
    }
  }
}

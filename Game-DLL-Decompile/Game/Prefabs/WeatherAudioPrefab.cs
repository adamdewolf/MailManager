// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WeatherAudioPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public class WeatherAudioPrefab : PrefabBase
  {
    [Header("Water")]
    [Tooltip("The depth range of small water")]
    public float2 m_SmallWaterDepth;
    [Tooltip("The water audio's intensity that will be applied to the audio clip's volume")]
    public float m_WaterAudioIntensity;
    [Tooltip("The water audio's fade in & fade out speed")]
    public float m_WaterFadeSpeed;
    [Tooltip("The water audio will not be heard when the camera zoom is bigger than it")]
    public int m_WaterAudioEnabledZoom;
    [Tooltip("The near cell's index distance that can play the water audio ")]
    public int m_WaterAudioNearDistance;
    [Tooltip("The small water audio clip")]
    public EffectPrefab m_SmallWaterAudio;
    [Tooltip("The depth range of medium water")]
    public float2 m_MediumWaterDepth;
    [Tooltip("The medium water audio clip")]
    public EffectPrefab m_MediumWaterAudio;
    [Tooltip("The depth range of big water")]
    public float2 m_BigWaterDepth;
    [Tooltip("The big water audio clip")]
    public EffectPrefab m_BigWaterAudio;
    [Tooltip("The lightning sound speed that affect the delay")]
    public float m_LightningSoundSpeed;
    [Tooltip("The lightning audio clip")]
    public EffectPrefab m_LightningAudio;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<WeatherAudioData>());
    }

    public override void GetDependencies(List<PrefabBase> prefabs) => base.GetDependencies(prefabs);

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      // ISSUE: variable of a compiler-generated type
      PrefabSystem systemManaged = entityManager.World.GetOrCreateSystemManaged<PrefabSystem>();
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated method
      WeatherAudioData componentData = new WeatherAudioData()
      {
        m_SmallWaterDepth = this.m_SmallWaterDepth,
        m_WaterFadeSpeed = this.m_WaterFadeSpeed,
        m_WaterAudioIntensity = this.m_WaterAudioIntensity,
        m_WaterAudioEnabledZoom = this.m_WaterAudioEnabledZoom,
        m_WaterAudioNearDistance = this.m_WaterAudioNearDistance,
        m_SmallWaterAudio = systemManaged.GetEntity((PrefabBase) this.m_SmallWaterAudio),
        m_MediumWaterDepth = this.m_MediumWaterDepth,
        m_MediumWaterAudio = systemManaged.GetEntity((PrefabBase) this.m_MediumWaterAudio),
        m_BigWaterDepth = this.m_BigWaterDepth,
        m_BigWaterAudio = systemManaged.GetEntity((PrefabBase) this.m_BigWaterAudio),
        m_LightningAudio = systemManaged.GetEntity((PrefabBase) this.m_LightningAudio),
        m_LightningSoundSpeed = this.m_LightningSoundSpeed
      };
      entityManager.SetComponentData<WeatherAudioData>(entity, componentData);
    }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Effects.VehicleSFX
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs.Effects
{
  [ComponentMenu("Effects/", new Type[] {typeof (EffectPrefab)})]
  public class VehicleSFX : ComponentBase
  {
    public float2 m_SpeedLimits;
    public float2 m_SpeedPitches;
    public float2 m_SpeedVolumes;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<VehicleAudioEffectData>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      VehicleAudioEffectData componentData = new VehicleAudioEffectData()
      {
        m_SpeedLimits = this.m_SpeedLimits,
        m_SpeedPitches = this.m_SpeedPitches,
        m_SpeedVolumes = this.m_SpeedVolumes
      };
      entityManager.SetComponentData<VehicleAudioEffectData>(entity, componentData);
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ExtractorFacility
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Common;
using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Buildings/", new Type[] {typeof (BuildingPrefab)})]
  public class ExtractorFacility : ComponentBase
  {
    public Bounds1 m_RotationRange;
    public Bounds1 m_HeightOffset;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ExtractorFacilityData>());
      components.Add(ComponentType.ReadWrite<UpdateFrameData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Buildings.ExtractorFacility>());
      components.Add(ComponentType.ReadWrite<PointOfInterest>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      ExtractorFacilityData componentData;
      componentData.m_RotationRange.min = math.radians(this.m_RotationRange.min);
      componentData.m_RotationRange.max = math.radians(this.m_RotationRange.max);
      componentData.m_HeightOffset = this.m_HeightOffset;
      entityManager.SetComponentData<ExtractorFacilityData>(entity, componentData);
      entityManager.SetComponentData<UpdateFrameData>(entity, new UpdateFrameData(14));
    }
  }
}
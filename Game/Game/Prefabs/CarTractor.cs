﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CarTractor
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Vehicles/", new System.Type[] {typeof (CarPrefab), typeof (CarTrailerPrefab)})]
  public class CarTractor : ComponentBase
  {
    public CarTrailerType m_TrailerType = CarTrailerType.Towbar;
    public float3 m_AttachOffset = new float3(0.0f, 0.5f, 0.0f);
    public CarTrailerPrefab m_FixedTrailer;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      if (!((UnityEngine.Object) this.m_FixedTrailer != (UnityEngine.Object) null))
        return;
      prefabs.Add((PrefabBase) this.m_FixedTrailer);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<CarTractorData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}
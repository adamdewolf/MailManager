﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.RenderedArea
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal;
using Game.Rendering;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Areas/", new System.Type[] {typeof (SurfacePrefab), typeof (LotPrefab)})]
  public class RenderedArea : ComponentBase
  {
    public Material m_Material;
    public float m_Roundness = 0.5f;
    public float m_LodBias;
    public int m_RendererPriority;
    [BitMask]
    public DecalLayers m_DecalLayerMask = DecalLayers.Terrain;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<RenderedAreaData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Areas.Batch>());
    }
  }
}
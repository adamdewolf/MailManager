﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DecalProperties
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal;
using Colossal.Mathematics;
using Game.Rendering;
using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Rendering/", new Type[] {typeof (RenderPrefab)})]
  public class DecalProperties : ComponentBase
  {
    public Bounds2 m_TextureArea = new Bounds2((float2) 0.0f, (float2) 1f);
    public int m_RendererPriority;
    [BitMask]
    public DecalLayers m_LayerMask = DecalLayers.Terrain | DecalLayers.Roads | DecalLayers.Buildings;
    public bool m_EnableInfoviewColor;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }
  }
}
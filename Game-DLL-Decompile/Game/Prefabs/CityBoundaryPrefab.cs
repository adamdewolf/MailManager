﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CityBoundaryPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Areas/", new System.Type[] {})]
  public class CityBoundaryPrefab : PrefabBase
  {
    public Material m_Material;
    public float m_Width = 20f;
    public float m_TilingLength = 80f;
    public Color m_CityBorderColor = new Color(1f, 1f, 1f, 0.75f);
    public Color m_MapBorderColor = new Color(1f, 1f, 1f, 0.25f);

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<CityBoundaryData>());
    }
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.Rendering.TerrainMaterialPropertiesPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Prefabs;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Rendering
{
  public class TerrainMaterialPropertiesPrefab : PrefabBase
  {
    public Material m_SplatmapMaterial;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<TerrainMaterialPropertiesData>());
    }
  }
}

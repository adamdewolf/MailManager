﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SpawnableArea
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Areas/", new System.Type[] {typeof (AreaPrefab)})]
  public class SpawnableArea : ComponentBase
  {
    public AreaPrefab[] m_Placeholders;
    [Range(0.0f, 100f)]
    public int m_Probability = 100;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      for (int index = 0; index < this.m_Placeholders.Length; ++index)
        prefabs.Add((PrefabBase) this.m_Placeholders[index]);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<SpawnableObjectData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}
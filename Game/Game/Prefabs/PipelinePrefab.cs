﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PipelinePrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Net;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/Prefab/", new Type[] {})]
  public class PipelinePrefab : NetGeometryPrefab
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<PipelineData>());
      components.Add(ComponentType.ReadWrite<LocalConnectData>());
      components.Add(ComponentType.ReadWrite<DefaultNetLane>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      base.GetArchetypeComponents(components);
      if (components.Contains(ComponentType.ReadWrite<Edge>()))
      {
        components.Add(ComponentType.ReadWrite<EdgeColor>());
      }
      else
      {
        if (!components.Contains(ComponentType.ReadWrite<Game.Net.Node>()))
          return;
        components.Add(ComponentType.ReadWrite<NodeColor>());
      }
    }
  }
}
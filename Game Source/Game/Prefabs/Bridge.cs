﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Bridge
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
  [ComponentMenu("Net/", new Type[] {typeof (RoadPrefab), typeof (TrackPrefab), typeof (PathwayPrefab)})]
  public class Bridge : ComponentBase
  {
    public float m_SegmentLength = 100f;
    public float m_Hanging;
    public BridgeWaterFlow m_WaterFlow;
    public FixedNetSegmentInfo[] m_FixedSegments;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<BridgeData>());
      if (this.m_FixedSegments == null || this.m_FixedSegments.Length == 0)
        return;
      components.Add(ComponentType.ReadWrite<FixedNetElement>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      if (this.m_FixedSegments == null || this.m_FixedSegments.Length == 0 || !components.Contains(ComponentType.ReadWrite<Edge>()))
        return;
      components.Add(ComponentType.ReadWrite<Fixed>());
    }
  }
}
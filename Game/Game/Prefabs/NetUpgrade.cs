﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetUpgrade
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/", new Type[] {typeof (NetPrefab)})]
  public class NetUpgrade : ComponentBase
  {
    public NetPieceRequirements[] m_SetState;
    public NetPieceRequirements[] m_UnsetState;
    public bool m_Standalone;
    public bool m_Underground;

    public override void GetDependencies(List<PrefabBase> prefabs) => base.GetDependencies(prefabs);

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<PlaceableNetData>());
      components.Add(ComponentType.ReadWrite<PlaceableInfoviewItem>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      if (!components.Contains(ComponentType.ReadWrite<NetCompositionData>()))
        return;
      components.Add(ComponentType.ReadWrite<PlaceableNetComposition>());
    }
  }
}
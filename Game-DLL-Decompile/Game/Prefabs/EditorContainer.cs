﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.EditorContainer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;
using Game.Net;
using Game.Objects;
using Game.Rendering;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tools/", new Type[] {typeof (NetPrefab), typeof (ObjectPrefab)})]
  public class EditorContainer : ComponentBase
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<EditorContainerData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      if (components.Contains(ComponentType.ReadWrite<Edge>()))
      {
        components.Add(ComponentType.ReadWrite<Game.Tools.EditorContainer>());
        components.Add(ComponentType.ReadWrite<Game.Net.SubLane>());
        components.Add(ComponentType.ReadWrite<Curve>());
        components.Add(ComponentType.ReadWrite<CullingInfo>());
        components.Add(ComponentType.ReadWrite<PseudoRandomSeed>());
      }
      else if (components.Contains(ComponentType.ReadWrite<Game.Net.Node>()))
      {
        components.Add(ComponentType.ReadWrite<Game.Tools.EditorContainer>());
        components.Add(ComponentType.ReadWrite<CullingInfo>());
      }
      else
      {
        if (!components.Contains(ComponentType.ReadWrite<Game.Objects.Object>()))
          return;
        components.Add(ComponentType.ReadWrite<Game.Tools.EditorContainer>());
        components.Add(ComponentType.ReadWrite<Game.Objects.SubObject>());
        components.Add(ComponentType.ReadWrite<Static>());
        components.Add(ComponentType.ReadWrite<CullingInfo>());
      }
    }
  }
}
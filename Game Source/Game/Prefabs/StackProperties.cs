﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.StackProperties
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Rendering/", new Type[] {typeof (RenderPrefab)})]
  public class StackProperties : ComponentBase
  {
    public StackDirection m_Direction = StackDirection.Up;
    public StackOrder m_Order = StackOrder.Middle;
    public float m_StartOverlap;
    public float m_EndOverlap;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.VFX
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine.VFX;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("VFX/", new Type[] {typeof (EffectPrefab)})]
  public class VFX : ComponentBase
  {
    public VisualEffectAsset m_Effect;
    public int m_MaxCount;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<VFXData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Serialization.PreSerialize`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Serialization
{
  public class PreSerialize<T> : GameSystemBase where T : ComponentSystemBase, IPreSerialize
  {
    private SaveGameSystem m_SaveGameSystem;
    private T m_System;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_SaveGameSystem = this.World.GetOrCreateSystemManaged<SaveGameSystem>();
      this.m_System = this.World.GetOrCreateSystemManaged<T>();
    }

    [Preserve]
    protected override void OnUpdate() => this.m_System.PreSerialize(this.m_SaveGameSystem.context);

    [Preserve]
    public PreSerialize()
    {
    }
  }
}
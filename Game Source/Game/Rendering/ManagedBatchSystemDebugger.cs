﻿// Decompiled with JetBrains decompiler
// Type: Game.Rendering.ManagedBatchSystemDebugger
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Game.Rendering
{
  public class ManagedBatchSystemDebugger : MonoBehaviour
  {
    public const string kSectionName = "======System======";

    public ManagedBatchSystem managedBatchSystem { get; set; }

    public IReadOnlyDictionary<ManagedBatchSystem.MaterialKey, Material> materials
    {
      get => this.managedBatchSystem?.materials;
    }
  }
}
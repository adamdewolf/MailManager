﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.DensityAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Collections;

#nullable disable
namespace Game.Pathfind
{
  public struct DensityAction : IDisposable
  {
    public NativeQueue<DensityActionData> m_DensityData;

    public DensityAction(Allocator allocator)
    {
      this.m_DensityData = new NativeQueue<DensityActionData>((AllocatorManager.AllocatorHandle) allocator);
    }

    public void Dispose() => this.m_DensityData.Dispose();
  }
}
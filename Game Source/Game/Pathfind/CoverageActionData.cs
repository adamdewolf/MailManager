﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.CoverageActionData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

#nullable disable
namespace Game.Pathfind
{
  public struct CoverageActionData : IDisposable
  {
    public UnsafeQueue<PathTarget> m_Sources;
    public UnsafeList<CoverageResult> m_Results;
    public CoverageParameters m_Parameters;
    public PathfindActionState m_State;

    public CoverageActionData(Allocator allocator)
    {
      this.m_Sources = new UnsafeQueue<PathTarget>((AllocatorManager.AllocatorHandle) allocator);
      this.m_Results = new UnsafeList<CoverageResult>(100, (AllocatorManager.AllocatorHandle) allocator);
      this.m_Parameters = new CoverageParameters();
      this.m_State = PathfindActionState.Pending;
    }

    public void Dispose()
    {
      this.m_Sources.Dispose();
      this.m_Results.Dispose();
    }
  }
}
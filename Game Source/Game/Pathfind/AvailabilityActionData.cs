﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.AvailabilityActionData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;

#nullable disable
namespace Game.Pathfind
{
  public struct AvailabilityActionData : IDisposable
  {
    public UnsafeQueue<PathTarget> m_Sources;
    public UnsafeQueue<AvailabilityProvider> m_Providers;
    public UnsafeList<AvailabilityResult> m_Results;
    public AvailabilityParameters m_Parameters;
    public PathfindActionState m_State;

    public AvailabilityActionData(Allocator allocator, AvailabilityParameters parameters)
    {
      this.m_Sources = new UnsafeQueue<PathTarget>((AllocatorManager.AllocatorHandle) allocator);
      this.m_Providers = new UnsafeQueue<AvailabilityProvider>((AllocatorManager.AllocatorHandle) allocator);
      this.m_Results = new UnsafeList<AvailabilityResult>(100, (AllocatorManager.AllocatorHandle) allocator);
      this.m_Parameters = parameters;
      this.m_State = PathfindActionState.Pending;
    }

    public void Dispose()
    {
      this.m_Sources.Dispose();
      this.m_Providers.Dispose();
      this.m_Results.Dispose();
    }
  }
}
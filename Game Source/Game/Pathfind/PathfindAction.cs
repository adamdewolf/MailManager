﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathfindAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using System;
using Unity.Collections;

#nullable disable
namespace Game.Pathfind
{
  public struct PathfindAction : IDisposable
  {
    public NativeReference<PathfindActionData> m_Data;

    public PathfindAction(
      int startCount,
      int endCount,
      Allocator allocator,
      PathfindParameters parameters,
      SetupTargetType originType,
      SetupTargetType destinationType)
    {
      this.m_Data = new NativeReference<PathfindActionData>(new PathfindActionData(startCount, endCount, allocator, parameters, originType, destinationType), (AllocatorManager.AllocatorHandle) allocator);
    }

    public ref PathfindActionData data => ref this.m_Data.ValueAsRef<PathfindActionData>();

    public PathfindActionData readOnlyData => this.m_Data.Value;

    public void Dispose()
    {
      this.data.Dispose();
      this.m_Data.Dispose();
    }
  }
}
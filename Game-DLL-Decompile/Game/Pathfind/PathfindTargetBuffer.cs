﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathfindTargetBuffer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;

#nullable disable
namespace Game.Pathfind
{
  public struct PathfindTargetBuffer : IPathfindTargetBuffer
  {
    private UnsafeQueue<PathTarget>.ParallelWriter m_Queue;

    public void Enqueue(PathTarget pathTarget) => this.m_Queue.Enqueue(pathTarget);

    public static implicit operator PathfindTargetBuffer(
      UnsafeQueue<PathTarget>.ParallelWriter queue)
    {
      return new PathfindTargetBuffer() { m_Queue = queue };
    }
  }
}
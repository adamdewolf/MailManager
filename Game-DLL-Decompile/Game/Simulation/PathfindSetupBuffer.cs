// Decompiled with JetBrains decompiler
// Type: Game.Simulation.PathfindSetupBuffer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using Unity.Collections;

#nullable disable
namespace Game.Simulation
{
  public struct PathfindSetupBuffer : IPathfindTargetBuffer
  {
    public NativeQueue<PathfindSetupTarget>.ParallelWriter m_Queue;
    public int m_SetupIndex;

    public void Enqueue(PathTarget pathTarget)
    {
      this.m_Queue.Enqueue(new PathfindSetupTarget()
      {
        m_SetupIndex = this.m_SetupIndex,
        m_PathTarget = pathTarget
      });
    }
  }
}

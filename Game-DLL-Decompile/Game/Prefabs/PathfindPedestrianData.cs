// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PathfindPedestrianData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct PathfindPedestrianData : IComponentData, IQueryTypeParameter
  {
    public PathfindCosts m_WalkingCost;
    public PathfindCosts m_CrosswalkCost;
    public PathfindCosts m_UnsafeCrosswalkCost;
    public PathfindCosts m_SpawnCost;
  }
}

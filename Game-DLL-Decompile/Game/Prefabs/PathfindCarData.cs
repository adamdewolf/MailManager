// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PathfindCarData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct PathfindCarData : IComponentData, IQueryTypeParameter
  {
    public PathfindCosts m_DrivingCost;
    public PathfindCosts m_TurningCost;
    public PathfindCosts m_UnsafeTurningCost;
    public PathfindCosts m_UTurnCost;
    public PathfindCosts m_UnsafeUTurnCost;
    public PathfindCosts m_CurveAngleCost;
    public PathfindCosts m_LaneCrossCost;
    public PathfindCosts m_ParkingCost;
    public PathfindCosts m_SpawnCost;
    public PathfindCosts m_ForbiddenCost;
  }
}

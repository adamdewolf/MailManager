// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PathfindConnectionData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct PathfindConnectionData : IComponentData, IQueryTypeParameter
  {
    public PathfindCosts m_BorderCost;
    public PathfindCosts m_PedestrianBorderCost;
    public PathfindCosts m_DistanceCost;
    public PathfindCosts m_AirwayCost;
    public PathfindCosts m_InsideCost;
    public PathfindCosts m_AreaCost;
    public PathfindCosts m_CarSpawnCost;
    public PathfindCosts m_PedestrianSpawnCost;
    public PathfindCosts m_HelicopterTakeoffCost;
    public PathfindCosts m_AirplaneTakeoffCost;
    public PathfindCosts m_TaxiStartCost;
    public PathfindCosts m_ParkingCost;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathfindParameters
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Pathfind
{
  public struct PathfindParameters
  {
    public Entity m_ParkingTarget;
    public Entity m_Authorization1;
    public Entity m_Authorization2;
    public PathfindWeights m_Weights;
    public float2 m_MaxSpeed;
    public float2 m_WalkSpeed;
    public float2 m_ParkingSize;
    public float m_ParkingDelta;
    public float m_MaxCost;
    public int m_MaxResultCount;
    public PathMethod m_Methods;
    public PathfindFlags m_PathfindFlags;
    public RuleFlags m_IgnoredRules;
    public RuleFlags m_SecondaryIgnoredRules;
  }
}

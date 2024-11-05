// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.SetupQueueTarget
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using Game.Net;
using Game.Prefabs;
using Game.Simulation;
using Unity.Entities;

#nullable disable
namespace Game.Pathfind
{
  public struct SetupQueueTarget
  {
    public SetupTargetType m_Type;
    public PathMethod m_Methods;
    public Entity m_Entity;
    public Entity m_Entity2;
    public Resource m_Resource;
    public ActivityMask m_ActivityMask;
    public MaintenanceType m_MaintenanceType;
    public SetupTargetFlags m_Flags;
    public TrackTypes m_TrackTypes;
    public RoadTypes m_RoadTypes;
    public RoadTypes m_FlyingTypes;
    public int m_Value;
    public float m_Value2;
    public float m_RandomCost;
    public int m_Value3;
  }
}

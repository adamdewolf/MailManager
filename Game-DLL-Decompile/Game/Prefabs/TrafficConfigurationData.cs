// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TrafficConfigurationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct TrafficConfigurationData : IComponentData, IQueryTypeParameter
  {
    public Entity m_BottleneckNotification;
    public Entity m_DeadEndNotification;
    public Entity m_RoadConnectionNotification;
    public Entity m_TrackConnectionNotification;
    public Entity m_CarConnectionNotification;
    public Entity m_ShipConnectionNotification;
    public Entity m_TrainConnectionNotification;
    public Entity m_PedestrianConnectionNotification;
  }
}

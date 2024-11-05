// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WeatherPhenomenonData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Events;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct WeatherPhenomenonData : IComponentData, IQueryTypeParameter
  {
    public float m_OccurenceProbability;
    public float m_HotspotInstability;
    public float m_DamageSeverity;
    public float m_DangerLevel;
    public Bounds1 m_PhenomenonRadius;
    public Bounds1 m_HotspotRadius;
    public Bounds1 m_LightningInterval;
    public Bounds1 m_Duration;
    public Bounds1 m_OccurenceTemperature;
    public Bounds1 m_OccurenceRain;
    public DangerFlags m_DangerFlags;
  }
}

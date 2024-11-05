// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ZonePollutionData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ZonePollutionData : IComponentData, IQueryTypeParameter
  {
    public float m_GroundPollution;
    public float m_AirPollution;
    public float m_NoisePollution;
  }
}

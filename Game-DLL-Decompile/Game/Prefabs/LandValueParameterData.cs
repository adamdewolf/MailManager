// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LandValueParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct LandValueParameterData : IComponentData, IQueryTypeParameter
  {
    public Entity m_LandValueInfoViewPrefab;
    public float m_LandValueBaseline;
    public float m_HealthCoverageBonusMultiplier;
    public float m_EducationCoverageBonusMultiplier;
    public float m_PoliceCoverageBonusMultiplier;
    public float m_AttractivenessBonusMultiplier;
    public float m_TelecomCoverageBonusMultiplier;
    public float m_CommercialServiceBonusMultiplier;
    public float m_TramSubwayBonusMultiplier;
    public float m_BusBonusMultiplier;
    public float m_CommonFactorMaxBonus;
    public float m_GroundPollutionPenaltyMultiplier;
    public float m_AirPollutionPenaltyMultiplier;
    public float m_NoisePollutionPenaltyMultiplier;
  }
}

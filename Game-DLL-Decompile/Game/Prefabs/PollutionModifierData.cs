// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PollutionModifierData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct PollutionModifierData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<PollutionModifierData>
  {
    public float m_GroundPollutionMultiplier;
    public float m_AirPollutionMultiplier;
    public float m_NoisePollutionMultiplier;

    public void Combine(PollutionModifierData otherData)
    {
      this.m_GroundPollutionMultiplier += otherData.m_GroundPollutionMultiplier;
      this.m_AirPollutionMultiplier += otherData.m_AirPollutionMultiplier;
      this.m_NoisePollutionMultiplier += otherData.m_NoisePollutionMultiplier;
    }
  }
}

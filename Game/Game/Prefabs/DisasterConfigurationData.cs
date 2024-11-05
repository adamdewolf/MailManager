// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DisasterConfigurationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct DisasterConfigurationData : IComponentData, IQueryTypeParameter
  {
    public Entity m_WeatherDamageNotificationPrefab;
    public Entity m_WeatherDestroyedNotificationPrefab;
    public Entity m_WaterDamageNotificationPrefab;
    public Entity m_WaterDestroyedNotificationPrefab;
    public Entity m_DestroyedNotificationPrefab;
    public float m_FloodDamageRate;
    public AnimationCurve1 m_EmergencyShelterDangerLevelExitProbability;
    public float m_InoperableEmergencyShelterExitProbability;
  }
}

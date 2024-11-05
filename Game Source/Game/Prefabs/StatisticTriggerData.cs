// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.StatisticTriggerData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct StatisticTriggerData : IComponentData, IQueryTypeParameter
  {
    public StatisticTriggerType m_Type;
    public Entity m_StatisticEntity;
    public int m_StatisticParameter;
    public Entity m_NormalizeWithPrefab;
    public int m_NormalizeWithParameter;
    public int m_TimeFrame;
    public int m_MinSamples;
  }
}

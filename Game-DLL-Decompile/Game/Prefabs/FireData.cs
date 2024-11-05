// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FireData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct FireData : IComponentData, IQueryTypeParameter
  {
    public EventTargetType m_RandomTargetType;
    public float m_StartProbability;
    public float m_StartIntensity;
    public float m_EscalationRate;
    public float m_SpreadProbability;
    public float m_SpreadRange;
  }
}

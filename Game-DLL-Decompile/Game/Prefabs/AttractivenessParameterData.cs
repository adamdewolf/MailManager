// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AttractivenessParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct AttractivenessParameterData : IComponentData, IQueryTypeParameter
  {
    public float m_ForestEffect;
    public float m_ForestDistance;
    public float m_ShoreEffect;
    public float m_ShoreDistance;
    public float3 m_HeightBonus;
    public float2 m_AttractiveTemperature;
    public float2 m_ExtremeTemperature;
    public float2 m_TemperatureAffect;
    public float2 m_RainEffectRange;
    public float2 m_SnowEffectRange;
    public float3 m_SnowRainExtremeAffect;
  }
}

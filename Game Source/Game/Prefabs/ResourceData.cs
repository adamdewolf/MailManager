// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ResourceData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct ResourceData : IComponentData, IQueryTypeParameter
  {
    public float2 m_Price;
    public bool m_IsProduceable;
    public bool m_IsTradable;
    public bool m_IsMaterial;
    public bool m_IsLeisure;
    public float m_Weight;
    public float m_WealthModifier;
    public float m_BaseConsumption;
    public int m_ChildWeight;
    public int m_TeenWeight;
    public int m_AdultWeight;
    public int m_ElderlyWeight;
    public int m_CarConsumption;
    public bool m_RequireTemperature;
    public float m_RequiredTemperature;
    public bool m_RequireNaturalResource;
    public int2 m_NeededWorkPerUnit;
  }
}

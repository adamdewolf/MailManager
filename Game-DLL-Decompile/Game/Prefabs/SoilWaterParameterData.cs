﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SoilWaterParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct SoilWaterParameterData : IComponentData, IQueryTypeParameter
  {
    public float m_RainMultiplier;
    public float m_HeightEffect;
    public float m_MaxDiffusion;
    public float m_WaterPerUnit;
    public float m_MoistureUnderWater;
    public float m_MaximumWaterDepth;
    public float m_OverflowRate;
  }
}
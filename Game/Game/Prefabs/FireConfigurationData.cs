﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FireConfigurationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct FireConfigurationData : IComponentData, IQueryTypeParameter
  {
    public Entity m_FireNotificationPrefab;
    public Entity m_BurnedDownNotificationPrefab;
    public float m_DefaultStructuralIntegrity;
    public float m_BuildingStructuralIntegrity;
    public float m_StructuralIntegrityLevel1;
    public float m_StructuralIntegrityLevel2;
    public float m_StructuralIntegrityLevel3;
    public float m_StructuralIntegrityLevel4;
    public float m_StructuralIntegrityLevel5;
    public Bounds1 m_ResponseTimeRange;
    public float m_TelecomResponseTimeModifier;
    public float m_DarknessResponseTimeModifier;
    public float m_DeathRateOfFireAccident;
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.GarbageParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct GarbageParameterData : IComponentData, IQueryTypeParameter
  {
    public Entity m_GarbageServicePrefab;
    public Entity m_GarbageNotificationPrefab;
    public Entity m_FacilityFullNotificationPrefab;
    public int m_HomelessGarbageProduce;
    public int m_CollectionGarbageLimit;
    public int m_RequestGarbageLimit;
    public int m_WarningGarbageLimit;
    public int m_MaxGarbageAccumulation;
    public float m_BuildingLevelBalance;
    public float m_EducationBalance;
    public int m_HappinessEffectBaseline;
    public int m_HappinessEffectStep;
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.StatisticsData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public struct StatisticsData : IComponentData, IQueryTypeParameter
  {
    public Entity m_Category;
    public Entity m_Group;
    public StatisticType m_StatisticType;
    public StatisticCollectionType m_CollectionType;
    public StatisticUnitType m_UnitType;
    public Color m_Color;
    public bool m_Stacked;
  }
}
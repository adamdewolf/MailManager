// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UIStatisticsGroupData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public struct UIStatisticsGroupData : IComponentData, IQueryTypeParameter
  {
    public Entity m_Category;
    public Color m_Color;
    public StatisticUnitType m_UnitType;
    public bool m_Stacked;
  }
}

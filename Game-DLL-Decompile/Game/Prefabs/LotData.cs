// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LotData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public struct LotData : IComponentData, IQueryTypeParameter
  {
    public float m_MaxRadius;
    public Color32 m_RangeColor;

    public LotData(float maxRadius, Color32 rangeColor)
    {
      this.m_MaxRadius = maxRadius;
      this.m_RangeColor = rangeColor;
    }
  }
}

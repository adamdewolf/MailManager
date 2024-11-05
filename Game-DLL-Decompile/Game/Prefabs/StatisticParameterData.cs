// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.StatisticParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public struct StatisticParameterData : IBufferElementData
  {
    public int m_Value;
    public Color m_Color;

    public StatisticParameterData(int value, Color color)
    {
      this.m_Value = value;
      this.m_Color = color;
    }
  }
}

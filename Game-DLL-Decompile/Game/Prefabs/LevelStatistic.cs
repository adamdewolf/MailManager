﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LevelStatistic
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Statistics/", new System.Type[] {typeof (StatisticsPrefab)})]
  public class LevelStatistic : ParametricStatistic
  {
    public LevelInfo[] m_Levels;

    public override IEnumerable<StatisticParameterData> GetParameters()
    {
      if (this.m_Levels != null)
      {
        LevelInfo[] levelInfoArray = this.m_Levels;
        for (int index = 0; index < levelInfoArray.Length; ++index)
          yield return new StatisticParameterData(levelInfoArray[index].m_Value, Color.black);
        levelInfoArray = (LevelInfo[]) null;
      }
    }

    public override string GetParameterName(int parameter) => parameter.ToString();
  }
}
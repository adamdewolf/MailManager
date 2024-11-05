// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AgeStatistic
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Citizens;
using System;
using System.Collections.Generic;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Statistics/", new Type[] {typeof (StatisticsPrefab)})]
  public class AgeStatistic : ParametricStatistic
  {
    public PopulationAgeGroupInfo[] m_AgeGroups;

    public override IEnumerable<StatisticParameterData> GetParameters()
    {
      if (this.m_AgeGroups != null)
      {
        for (int i = 0; i < this.m_AgeGroups.Length; ++i)
          yield return new StatisticParameterData((int) this.m_AgeGroups[i].m_Group, this.m_AgeGroups[i].m_Color);
      }
    }

    public override string GetParameterName(int parameter)
    {
      return Enum.GetName(typeof (CitizenAge), (object) parameter);
    }
  }
}

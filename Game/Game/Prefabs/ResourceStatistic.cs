﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ResourceStatistic
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using System;
using System.Collections.Generic;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Statistics/", new Type[] {typeof (StatisticsPrefab)})]
  public class ResourceStatistic : ParametricStatistic
  {
    public ResourcePrefab[] m_Resources;

    public override IEnumerable<StatisticParameterData> GetParameters()
    {
      if (this.m_Resources != null)
      {
        ResourcePrefab[] resourcePrefabArray = this.m_Resources;
        for (int index = 0; index < resourcePrefabArray.Length; ++index)
        {
          ResourcePrefab resourcePrefab = resourcePrefabArray[index];
          yield return new StatisticParameterData(EconomyUtils.GetResourceIndex(EconomyUtils.GetResource(resourcePrefab.m_Resource)), resourcePrefab.m_Color);
        }
        resourcePrefabArray = (ResourcePrefab[]) null;
      }
    }

    public override string GetParameterName(int parameter)
    {
      return Enum.GetName(typeof (Resource), (object) EconomyUtils.GetResource(parameter));
    }
  }
}
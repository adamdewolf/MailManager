﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.HomelessShelterAISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using Game.Prefabs;
using UnityEngine;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Simulation
{
  public class HomelessShelterAISystem : GameSystemBase
  {
    public static int GetShelterCapacity(
      Game.Prefabs.BuildingData buildingData,
      BuildingPropertyData propertyData)
    {
      int num1 = buildingData.m_LotSize.x * buildingData.m_LotSize.y;
      float num2 = (float) propertyData.m_ResidentialProperties;
      if (propertyData.m_AllowedSold != Resource.NoResource || propertyData.m_AllowedManufactured != Resource.NoResource || propertyData.m_AllowedStored != Resource.NoResource)
        num2 += propertyData.m_SpaceMultiplier * (float) num1;
      if ((double) num2 == 0.0)
        num2 = (float) num1 / 4f;
      return Mathf.CeilToInt(num2 / 2f);
    }

    [Preserve]
    protected override void OnCreate() => base.OnCreate();

    [Preserve]
    protected override void OnUpdate()
    {
    }

    [Preserve]
    public HomelessShelterAISystem()
    {
    }
  }
}
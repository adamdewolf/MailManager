﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BuildingConfigurationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct BuildingConfigurationData : IComponentData, IQueryTypeParameter
  {
    public int m_BuildingConditionIncrement;
    public int m_BuildingConditionDecrement;
    public Entity m_AbandonedCollapsedNotification;
    public Entity m_AbandonedNotification;
    public Entity m_CondemnedNotification;
    public Entity m_LevelUpNotification;
    public Entity m_TurnedOffNotification;
    public Entity m_ElectricityConnectionLane;
    public Entity m_SewageConnectionLane;
    public Entity m_WaterConnectionLane;
    public uint m_AbandonedDestroyDelay;
    public Entity m_HighRentNotification;
    public Entity m_DefaultRenterBrand;
    public Entity m_ConstructionSurface;
    public Entity m_ConstructionBorder;
    public Entity m_ConstructionObject;
    public Entity m_CollapsedObject;
    public Entity m_CollapseVFX;
    public Entity m_CollapseSFX;
    public Entity m_CollapsedSurface;
    public Entity m_FireLoopSFX;
    public Entity m_FireSpotSFX;
  }
}
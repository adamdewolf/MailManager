﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DeliveryTruckSelectItem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct DeliveryTruckSelectItem : IComparable<DeliveryTruckSelectItem>
  {
    public int m_Capacity;
    public int m_Cost;
    public Resource m_Resources;
    public Entity m_Prefab1;
    public Entity m_Prefab2;
    public Entity m_Prefab3;
    public Entity m_Prefab4;

    public int CompareTo(DeliveryTruckSelectItem other) => this.m_Capacity - other.m_Capacity;
  }
}
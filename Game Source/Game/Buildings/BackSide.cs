﻿// Decompiled with JetBrains decompiler
// Type: Game.Buildings.BackSide
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct BackSide : IComponentData, IQueryTypeParameter
  {
    public Entity m_RoadEdge;
    public float m_CurvePosition;
  }
}
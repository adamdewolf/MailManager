﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.LabelExtents
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct LabelExtents : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Bounds2 m_Bounds;
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.TrainBogieFrame
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  [InternalBufferCapacity(4)]
  public struct TrainBogieFrame : IBufferElementData, IEmptySerializable
  {
    public Entity m_FrontLane;
    public Entity m_RearLane;
  }
}
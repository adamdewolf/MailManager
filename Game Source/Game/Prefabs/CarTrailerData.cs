﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CarTrailerData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct CarTrailerData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public CarTrailerType m_TrailerType;
    public TrailerMovementType m_MovementType;
    public float3 m_AttachPosition;
    public Entity m_FixedTractor;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_MovementType);
      writer.Write(this.m_AttachPosition);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      reader.Read(out this.m_AttachPosition);
      this.m_MovementType = (TrailerMovementType) num;
    }
  }
}
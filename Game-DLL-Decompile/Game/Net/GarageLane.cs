﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.GarageLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct GarageLane : IComponentData, IQueryTypeParameter, ISerializable
  {
    public ushort m_ParkingFee;
    public ushort m_ComfortFactor;
    public ushort m_VehicleCount;
    public ushort m_VehicleCapacity;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_ParkingFee);
      writer.Write(this.m_ComfortFactor);
      writer.Write(this.m_VehicleCount);
      writer.Write(this.m_VehicleCapacity);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_ParkingFee);
      reader.Read(out this.m_ComfortFactor);
      reader.Read(out this.m_VehicleCount);
      reader.Read(out this.m_VehicleCapacity);
    }
  }
}
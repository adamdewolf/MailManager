﻿// Decompiled with JetBrains decompiler
// Type: Game.Routes.WaitingPassengers
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Routes
{
  public struct WaitingPassengers : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_Count;
    public int m_OngoingAccumulation;
    public int m_ConcludedAccumulation;
    public ushort m_SuccessAccumulation;
    public ushort m_AverageWaitingTime;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Count);
      writer.Write(this.m_OngoingAccumulation);
      writer.Write(this.m_ConcludedAccumulation);
      writer.Write(this.m_SuccessAccumulation);
      writer.Write(this.m_AverageWaitingTime);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Count);
      if (reader.context.version >= Version.passengerWaitTimeCost2)
        reader.Read(out this.m_OngoingAccumulation);
      if (!(reader.context.version >= Version.passengerWaitTimeCost))
        return;
      reader.Read(out this.m_ConcludedAccumulation);
      reader.Read(out this.m_SuccessAccumulation);
      reader.Read(out this.m_AverageWaitingTime);
    }
  }
}
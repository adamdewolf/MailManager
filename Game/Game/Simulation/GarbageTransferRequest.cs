﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.GarbageTransferRequest
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct GarbageTransferRequest : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Facility;
    public GarbageTransferRequestFlags m_Flags;
    public float m_Priority;
    public int m_Amount;

    public GarbageTransferRequest(
      Entity facility,
      GarbageTransferRequestFlags flags,
      float priority,
      int amount)
    {
      this.m_Facility = facility;
      this.m_Flags = flags;
      this.m_Priority = priority;
      this.m_Amount = amount;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Facility);
      writer.Write((ushort) this.m_Flags);
      writer.Write(this.m_Priority);
      writer.Write(this.m_Amount);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Facility);
      ushort num;
      reader.Read(out num);
      reader.Read(out this.m_Priority);
      reader.Read(out this.m_Amount);
      this.m_Flags = (GarbageTransferRequestFlags) num;
    }
  }
}
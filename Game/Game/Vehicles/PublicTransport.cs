﻿// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.PublicTransport
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct PublicTransport : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_TargetRequest;
    public PublicTransportFlags m_State;
    public uint m_DepartureFrame;
    public int m_RequestCount;
    public float m_PathElementTime;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_TargetRequest);
      writer.Write((uint) this.m_State);
      writer.Write(this.m_DepartureFrame);
      writer.Write(this.m_RequestCount);
      writer.Write(this.m_PathElementTime);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.reverseServiceRequests)
        reader.Read(out this.m_TargetRequest);
      uint num;
      reader.Read(out num);
      reader.Read(out this.m_DepartureFrame);
      if (reader.context.version >= Version.evacuationTransport)
      {
        reader.Read(out this.m_RequestCount);
        reader.Read(out this.m_PathElementTime);
      }
      this.m_State = (PublicTransportFlags) num;
    }
  }
}
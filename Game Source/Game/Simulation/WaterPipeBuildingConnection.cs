﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.WaterPipeBuildingConnection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct WaterPipeBuildingConnection : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_ProducerEdge;
    public Entity m_ConsumerEdge;

    public Entity GetProducerNode(ref ComponentLookup<WaterPipeEdge> flowEdges)
    {
      return flowEdges[this.m_ProducerEdge].m_End;
    }

    public Entity GetConsumerNode(ref ComponentLookup<WaterPipeEdge> flowEdges)
    {
      return flowEdges[this.m_ConsumerEdge].m_Start;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_ProducerEdge);
      writer.Write(this.m_ConsumerEdge);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_ProducerEdge);
      reader.Read(out this.m_ConsumerEdge);
    }
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.Net.AggregateElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  [InternalBufferCapacity(0)]
  public struct AggregateElement : IBufferElementData, IEquatable<AggregateElement>, ISerializable
  {
    public Entity m_Edge;

    public AggregateElement(Entity edge) => this.m_Edge = edge;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Edge);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Edge);
    }

    public bool Equals(AggregateElement other) => this.m_Edge.Equals(other.m_Edge);

    public override int GetHashCode() => this.m_Edge.GetHashCode();
  }
}

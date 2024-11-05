// Decompiled with JetBrains decompiler
// Type: Game.Events.TargetElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Events
{
  [InternalBufferCapacity(0)]
  public struct TargetElement : IBufferElementData, IEquatable<TargetElement>, ISerializable
  {
    public Entity m_Entity;

    public TargetElement(Entity entity) => this.m_Entity = entity;

    public bool Equals(TargetElement other) => this.m_Entity.Equals(other.m_Entity);

    public override int GetHashCode() => this.m_Entity.GetHashCode();

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Entity);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Entity);
    }
  }
}

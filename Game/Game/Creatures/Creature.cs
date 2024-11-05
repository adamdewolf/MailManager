// Decompiled with JetBrains decompiler
// Type: Game.Creatures.Creature
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Creatures
{
  public struct Creature : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_QueueEntity;
    public Sphere3 m_QueueArea;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_QueueArea.radius);
      if ((double) this.m_QueueArea.radius <= 0.0)
        return;
      writer.Write(this.m_QueueEntity);
      writer.Write(this.m_QueueArea.position);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_QueueArea.radius);
      if ((double) this.m_QueueArea.radius <= 0.0)
        return;
      reader.Read(out this.m_QueueEntity);
      reader.Read(out this.m_QueueArea.position);
    }
  }
}

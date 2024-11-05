// Decompiled with JetBrains decompiler
// Type: Game.Buildings.GarbageProducer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct GarbageProducer : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_CollectionRequest;
    public int m_Garbage;
    public GarbageProducerFlags m_Flags;
    public byte m_DispatchIndex;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_CollectionRequest);
      writer.Write(this.m_Garbage);
      writer.Write((byte) this.m_Flags);
      writer.Write(this.m_DispatchIndex);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_CollectionRequest);
      reader.Read(out this.m_Garbage);
      if (reader.context.version >= Version.garbageProducerFlags)
      {
        byte num;
        reader.Read(out num);
        this.m_Flags = (GarbageProducerFlags) num;
      }
      if (!(reader.context.version >= Version.requestDispatchIndex))
        return;
      reader.Read(out this.m_DispatchIndex);
    }
  }
}

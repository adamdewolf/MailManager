// Decompiled with JetBrains decompiler
// Type: Game.Creatures.GroupMember
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Creatures
{
  public struct GroupMember : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Leader;

    public GroupMember(Entity leader) => this.m_Leader = leader;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Leader);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Leader);
    }
  }
}

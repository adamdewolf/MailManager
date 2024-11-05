// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PostVanData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct PostVanData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_MailCapacity;

    public PostVanData(int mailCapacity) => this.m_MailCapacity = mailCapacity;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_MailCapacity);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_MailCapacity);
    }
  }
}

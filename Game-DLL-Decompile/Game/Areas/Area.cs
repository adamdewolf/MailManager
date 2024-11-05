// Decompiled with JetBrains decompiler
// Type: Game.Areas.Area
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Areas
{
  public struct Area : IComponentData, IQueryTypeParameter, ISerializable
  {
    public AreaFlags m_Flags;

    public Area(AreaFlags flags) => this.m_Flags = flags;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_Flags);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      this.m_Flags = (AreaFlags) num;
      if (!(reader.context.version < Version.mapTileCompleteFix))
        return;
      this.m_Flags |= AreaFlags.Complete;
    }
  }
}

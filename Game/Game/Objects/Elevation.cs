// Decompiled with JetBrains decompiler
// Type: Game.Objects.Elevation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Objects
{
  public struct Elevation : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float m_Elevation;
    public ElevationFlags m_Flags;

    public Elevation(float elevation, ElevationFlags flags)
    {
      this.m_Elevation = elevation;
      this.m_Flags = flags;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Elevation);
      writer.Write((byte) this.m_Flags);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Elevation);
      if (!(reader.context.version >= Version.stackedObjects))
        return;
      byte num;
      reader.Read(out num);
      this.m_Flags = (ElevationFlags) num;
    }
  }
}

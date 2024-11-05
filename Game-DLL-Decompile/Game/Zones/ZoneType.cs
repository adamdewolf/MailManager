// Decompiled with JetBrains decompiler
// Type: Game.Zones.ZoneType
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;

#nullable disable
namespace Game.Zones
{
  public struct ZoneType : IEquatable<ZoneType>, IStrideSerializable, ISerializable
  {
    public ushort m_Index;

    public bool Equals(ZoneType other) => this.m_Index.Equals(other.m_Index);

    public static ZoneType None => new ZoneType();

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Index);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Game.Version.cornerBuildings)
      {
        reader.Read(out this.m_Index);
      }
      else
      {
        byte num;
        reader.Read(out num);
        this.m_Index = (ushort) num;
      }
    }

    public int GetStride(Context context) => 2;
  }
}

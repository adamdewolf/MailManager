// Decompiled with JetBrains decompiler
// Type: Game.Zones.ValidArea
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Zones
{
  public struct ValidArea : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int4 m_Area;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Area);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Area);
    }
  }
}

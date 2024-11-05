// Decompiled with JetBrains decompiler
// Type: Game.Objects.TripSource
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Objects
{
  public struct TripSource : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Source;
    public int m_Timer;

    public TripSource(Entity source)
    {
      this.m_Source = source;
      this.m_Timer = 0;
    }

    public TripSource(Entity source, uint delay)
    {
      this.m_Source = source;
      this.m_Timer = (int) delay;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Source);
      writer.Write(this.m_Timer);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Source);
      reader.Read(out this.m_Timer);
    }
  }
}

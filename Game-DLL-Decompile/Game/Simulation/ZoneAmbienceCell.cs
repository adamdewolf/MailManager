// Decompiled with JetBrains decompiler
// Type: Game.Simulation.ZoneAmbienceCell
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct ZoneAmbienceCell : IStrideSerializable, ISerializable
  {
    public ZoneAmbiences m_Accumulator;
    public ZoneAmbiences m_Value;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write<ZoneAmbiences>(this.m_Accumulator);
      writer.Write<ZoneAmbiences>(this.m_Value);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read<ZoneAmbiences>(out this.m_Accumulator);
      reader.Read<ZoneAmbiences>(out this.m_Value);
    }

    public int GetStride(Context context)
    {
      return this.m_Accumulator.GetStride(context) + this.m_Value.GetStride(context);
    }
  }
}

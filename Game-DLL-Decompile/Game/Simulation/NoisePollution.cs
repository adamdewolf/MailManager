// Decompiled with JetBrains decompiler
// Type: Game.Simulation.NoisePollution
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public struct NoisePollution : IPollution, IStrideSerializable, ISerializable
  {
    public short m_Pollution;
    public short m_PollutionTemp;

    public void Add(short amount)
    {
      this.m_PollutionTemp = (short) math.min((int) short.MaxValue, (int) this.m_PollutionTemp + (int) amount);
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Pollution);
      writer.Write(this.m_PollutionTemp);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Pollution);
      reader.Read(out this.m_PollutionTemp);
    }

    public int GetStride(Context context) => 4;
  }
}

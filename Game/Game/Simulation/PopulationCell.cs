﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.PopulationCell
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct PopulationCell : IPopulationCell, IStrideSerializable, ISerializable
  {
    public float m_Population;

    public float Get() => this.m_Population;

    public void Add(float amount) => this.m_Population += amount;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Population);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Population);
    }

    public int GetStride(Context context) => 4;
  }
}
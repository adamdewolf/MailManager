﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.SoilWater
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct SoilWater : IStrideSerializable, ISerializable
  {
    public float m_Surface;
    public short m_Amount;
    public short m_Max;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Surface);
      writer.Write(this.m_Amount);
      writer.Write(this.m_Max);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Surface);
      reader.Read(out this.m_Amount);
      reader.Read(out this.m_Max);
    }

    public int GetStride(Context context) => 8;
  }
}
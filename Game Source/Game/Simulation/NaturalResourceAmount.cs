﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.NaturalResourceAmount
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct NaturalResourceAmount : IStrideSerializable, ISerializable
  {
    public ushort m_Base;
    public ushort m_Used;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Base);
      writer.Write(this.m_Used);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Base);
      reader.Read(out this.m_Used);
    }

    public int GetStride(Context context) => 4;
  }
}
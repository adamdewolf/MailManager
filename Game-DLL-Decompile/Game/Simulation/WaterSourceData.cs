﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.WaterSourceData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct WaterSourceData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_ConstantDepth;
    public float m_Amount;
    public float m_Radius;
    public float m_Multiplier;
    public float m_Polluted;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_ConstantDepth);
      writer.Write(this.m_Amount);
      writer.Write(this.m_Radius);
      writer.Write(this.m_Multiplier);
      writer.Write(this.m_Polluted);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_ConstantDepth);
      reader.Read(out this.m_Amount);
      reader.Read(out this.m_Radius);
      reader.Read(out this.m_Multiplier);
      if (!(reader.context.version >= Version.waterPollution))
        return;
      reader.Read(out this.m_Polluted);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Buildings.Efficiency
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  [InternalBufferCapacity(8)]
  public struct Efficiency : IBufferElementData, ISerializable, IComparable<Efficiency>
  {
    public EfficiencyFactor m_Factor;
    public float m_Efficiency;

    public Efficiency(EfficiencyFactor factor, float efficiency)
    {
      this.m_Factor = factor;
      this.m_Efficiency = efficiency;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_Factor);
      writer.Write(this.m_Efficiency);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      this.m_Factor = (EfficiencyFactor) num;
      reader.Read(out this.m_Efficiency);
    }

    public int CompareTo(Efficiency other)
    {
      int num = other.m_Efficiency.CompareTo(this.m_Efficiency);
      return num != 0 ? num : this.m_Factor.CompareTo((object) other.m_Factor);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Areas.MapFeatureElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Areas
{
  [InternalBufferCapacity(8)]
  public struct MapFeatureElement : IBufferElementData, ISerializable
  {
    public float m_Amount;
    public float m_RenewalRate;

    public MapFeatureElement(float amount, float regenerationRate)
    {
      this.m_Amount = amount;
      this.m_RenewalRate = regenerationRate;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Amount);
      writer.Write(this.m_RenewalRate);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Amount);
      if (!(reader.context.version >= Version.naturalResourceRenewalRate))
        return;
      reader.Read(out this.m_RenewalRate);
    }
  }
}
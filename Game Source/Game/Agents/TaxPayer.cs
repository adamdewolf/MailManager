﻿// Decompiled with JetBrains decompiler
// Type: Game.Agents.TaxPayer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Agents
{
  public struct TaxPayer : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_UntaxedIncome;
    public int m_AverageTaxRate;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_UntaxedIncome);
      writer.Write(this.m_AverageTaxRate);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_UntaxedIncome);
      if (reader.context.version >= Version.averageTaxRate)
        reader.Read(out this.m_AverageTaxRate);
      else
        this.m_AverageTaxRate = 10;
    }
  }
}
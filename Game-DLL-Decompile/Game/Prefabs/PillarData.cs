﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PillarData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct PillarData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public PillarType m_Type;
    public Bounds1 m_OffsetRange;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((int) this.m_Type);
      writer.Write(this.m_OffsetRange.min);
      writer.Write(this.m_OffsetRange.max);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      int num;
      reader.Read(out num);
      reader.Read(out this.m_OffsetRange.min);
      reader.Read(out this.m_OffsetRange.max);
      this.m_Type = (PillarType) num;
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TaxiwayData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct TaxiwayData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float m_SpeedLimit;
    public TaxiwayFlags m_Flags;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_SpeedLimit);
      writer.Write((uint) this.m_Flags);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_SpeedLimit);
      uint num;
      reader.Read(out num);
      this.m_Flags = (TaxiwayFlags) num;
    }
  }
}
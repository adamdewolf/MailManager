﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.WaterPipeConnection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct WaterPipeConnection : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_FreshCapacity;
    public int m_SewageCapacity;
    public int m_StormCapacity;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_FreshCapacity);
      writer.Write(this.m_SewageCapacity);
      writer.Write(this.m_StormCapacity);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_FreshCapacity);
      reader.Read(out this.m_SewageCapacity);
      if (reader.context.version >= Version.stormWater)
        reader.Read(out this.m_StormCapacity);
      else
        this.m_StormCapacity = 5000;
    }
  }
}
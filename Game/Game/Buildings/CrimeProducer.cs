﻿// Decompiled with JetBrains decompiler
// Type: Game.Buildings.CrimeProducer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct CrimeProducer : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_PatrolRequest;
    public float m_Crime;
    public byte m_DispatchIndex;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_PatrolRequest);
      writer.Write(this.m_Crime);
      writer.Write(this.m_DispatchIndex);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_PatrolRequest);
      reader.Read(out this.m_Crime);
      if (!(reader.context.version >= Version.requestDispatchIndex))
        return;
      reader.Read(out this.m_DispatchIndex);
    }
  }
}
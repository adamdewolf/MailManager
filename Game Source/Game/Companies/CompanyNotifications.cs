﻿// Decompiled with JetBrains decompiler
// Type: Game.Companies.CompanyNotifications
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Companies
{
  public struct CompanyNotifications : IComponentData, IQueryTypeParameter, ISerializable
  {
    public short m_NoInputCounter;
    public short m_NoCustomersCounter;
    public Entity m_NoInputEntity;
    public Entity m_NoCustomersEntity;

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_NoInputCounter);
      reader.Read(out this.m_NoCustomersCounter);
      reader.Read(out this.m_NoInputEntity);
      reader.Read(out this.m_NoCustomersEntity);
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_NoInputCounter);
      writer.Write(this.m_NoCustomersCounter);
      writer.Write(this.m_NoInputEntity);
      writer.Write(this.m_NoCustomersEntity);
    }
  }
}
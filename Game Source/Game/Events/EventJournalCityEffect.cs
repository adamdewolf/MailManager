﻿// Decompiled with JetBrains decompiler
// Type: Game.Events.EventJournalCityEffect
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Events
{
  public struct EventJournalCityEffect : IBufferElementData, ISerializable
  {
    public EventCityEffectTrackingType m_Type;
    public int m_StartValue;
    public int m_Value;

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      int num;
      reader.Read(out num);
      this.m_Type = (EventCityEffectTrackingType) num;
      reader.Read(out this.m_StartValue);
      reader.Read(out this.m_Value);
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((int) this.m_Type);
      writer.Write(this.m_StartValue);
      writer.Write(this.m_Value);
    }
  }
}
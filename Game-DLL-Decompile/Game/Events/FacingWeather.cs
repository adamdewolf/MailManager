﻿// Decompiled with JetBrains decompiler
// Type: Game.Events.FacingWeather
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Events
{
  public struct FacingWeather : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Event;
    public float m_Severity;

    public FacingWeather(Entity _event, float severity)
    {
      this.m_Event = _event;
      this.m_Severity = severity;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Event);
      writer.Write(this.m_Severity);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Event);
      reader.Read(out this.m_Severity);
    }
  }
}
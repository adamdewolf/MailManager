﻿// Decompiled with JetBrains decompiler
// Type: Game.Triggers.LifePathEvent
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Triggers
{
  public struct LifePathEvent : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_EventPrefab;
    public Entity m_Target;
    public uint m_Date;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_EventPrefab);
      writer.Write(this.m_Target);
      writer.Write(this.m_Date);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_EventPrefab);
      reader.Read(out this.m_Target);
      reader.Read(out this.m_Date);
    }
  }
}
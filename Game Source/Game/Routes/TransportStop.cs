﻿// Decompiled with JetBrains decompiler
// Type: Game.Routes.TransportStop
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Routes
{
  public struct TransportStop : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_AccessRestriction;
    public float m_ComfortFactor;
    public float m_LoadingFactor;
    public StopFlags m_Flags;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_AccessRestriction);
      writer.Write(this.m_ComfortFactor);
      writer.Write(this.m_LoadingFactor);
      writer.Write((uint) this.m_Flags);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.pathfindAccessRestriction)
        reader.Read(out this.m_AccessRestriction);
      reader.Read(out this.m_ComfortFactor);
      if (reader.context.version >= Version.transportLoadingFactor)
        reader.Read(out this.m_LoadingFactor);
      uint num;
      reader.Read(out num);
      this.m_Flags = (StopFlags) num;
    }
  }
}
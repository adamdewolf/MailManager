﻿// Decompiled with JetBrains decompiler
// Type: Game.Objects.Tree
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Objects
{
  public struct Tree : IComponentData, IQueryTypeParameter, ISerializable
  {
    public TreeState m_State;
    public byte m_Growth;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_State);
      writer.Write(this.m_Growth);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      reader.Read(out this.m_Growth);
      this.m_State = (TreeState) num;
    }
  }
}
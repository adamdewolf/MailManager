﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.ConnectedNode
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  [InternalBufferCapacity(0)]
  public struct ConnectedNode : IBufferElementData, IEquatable<ConnectedNode>, ISerializable
  {
    public Entity m_Node;
    public float m_CurvePosition;

    public ConnectedNode(Entity node, float curvePosition)
    {
      this.m_Node = node;
      this.m_CurvePosition = curvePosition;
    }

    public bool Equals(ConnectedNode other) => this.m_Node.Equals(other.m_Node);

    public override int GetHashCode()
    {
      return (17 * 31 + this.m_Node.GetHashCode()) * 31 + this.m_CurvePosition.GetHashCode();
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Node);
      writer.Write(this.m_CurvePosition);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Node);
      reader.Read(out this.m_CurvePosition);
    }
  }
}
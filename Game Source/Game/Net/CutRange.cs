﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.CutRange
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  [InternalBufferCapacity(1)]
  public struct CutRange : IBufferElementData, ISerializable
  {
    public Bounds1 m_CurveDelta;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_CurveDelta.min);
      writer.Write(this.m_CurveDelta.max);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_CurveDelta.min);
      reader.Read(out this.m_CurveDelta.max);
    }
  }
}
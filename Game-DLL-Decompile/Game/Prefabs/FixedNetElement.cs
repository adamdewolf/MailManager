﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FixedNetElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct FixedNetElement : IBufferElementData, ISerializable
  {
    public Bounds1 m_LengthRange;
    public int2 m_CountRange;
    public CompositionFlags m_SetState;
    public CompositionFlags m_UnsetState;
    public FixedNetFlags m_Flags;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_LengthRange.min);
      writer.Write(this.m_LengthRange.max);
      writer.Write(this.m_CountRange);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_LengthRange.min);
      reader.Read(out this.m_LengthRange.max);
      reader.Read(out this.m_CountRange);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.Blocker
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Vehicles
{
  public struct Blocker : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Blocker;
    public BlockerType m_Type;
    public byte m_MaxSpeed;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Blocker);
      writer.Write((byte) this.m_Type);
      writer.Write(this.m_MaxSpeed);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Blocker);
      if (reader.context.version >= Version.trafficBottlenecks)
      {
        byte num;
        reader.Read(out num);
        reader.Read(out this.m_MaxSpeed);
        this.m_Type = (BlockerType) num;
      }
      else
      {
        float num;
        reader.Read(out num);
        this.m_MaxSpeed = (byte) math.clamp(num * 5f, 0.0f, (float) byte.MaxValue);
        this.m_Type = BlockerType.None;
      }
    }
  }
}
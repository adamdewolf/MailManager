﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AircraftData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Vehicles;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct AircraftData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public SizeClass m_SizeClass;
    public float m_GroundMaxSpeed;
    public float m_GroundAcceleration;
    public float m_GroundBraking;
    public float2 m_GroundTurning;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_SizeClass);
      writer.Write(this.m_GroundMaxSpeed);
      writer.Write(this.m_GroundAcceleration);
      writer.Write(this.m_GroundBraking);
      writer.Write(this.m_GroundTurning);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      reader.Read(out this.m_GroundMaxSpeed);
      reader.Read(out this.m_GroundAcceleration);
      reader.Read(out this.m_GroundBraking);
      reader.Read(out this.m_GroundTurning);
      this.m_SizeClass = (SizeClass) num;
    }
  }
}
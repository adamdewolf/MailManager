﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CarLaneData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Net;
using Game.Vehicles;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct CarLaneData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_NotTrackLanePrefab;
    public Entity m_NotBusLanePrefab;
    public RoadTypes m_RoadTypes;
    public SizeClass m_MaxSize;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_RoadTypes);
      writer.Write((byte) this.m_MaxSize);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num1;
      reader.Read(out num1);
      byte num2;
      reader.Read(out num2);
      this.m_RoadTypes = (RoadTypes) num1;
      this.m_MaxSize = (SizeClass) num2;
    }
  }
}
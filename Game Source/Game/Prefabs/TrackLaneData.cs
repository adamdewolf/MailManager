﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TrackLaneData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Net;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct TrackLaneData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_FallbackPrefab;
    public Entity m_EndObjectPrefab;
    public TrackTypes m_TrackTypes;
    public float m_MaxCurviness;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_TrackTypes);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      this.m_TrackTypes = (TrackTypes) num;
      this.m_MaxCurviness = float.MaxValue;
    }
  }
}
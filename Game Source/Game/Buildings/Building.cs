﻿// Decompiled with JetBrains decompiler
// Type: Game.Buildings.Building
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct Building : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_RoadEdge;
    public float m_CurvePosition;
    public uint m_OptionMask;
    public BuildingFlags m_Flags;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_RoadEdge);
      writer.Write(this.m_CurvePosition);
      writer.Write(this.m_OptionMask);
      writer.Write((byte) this.m_Flags);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_RoadEdge);
      reader.Read(out this.m_CurvePosition);
      if (reader.context.version >= Version.buildingOptions)
        reader.Read(out this.m_OptionMask);
      if (!(reader.context.version >= Version.companyNotifications))
        return;
      byte num;
      reader.Read(out num);
      this.m_Flags = (BuildingFlags) num;
    }
  }
}
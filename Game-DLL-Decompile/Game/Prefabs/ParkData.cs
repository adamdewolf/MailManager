﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ParkData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ParkData : IComponentData, IQueryTypeParameter, ICombineData<ParkData>, ISerializable
  {
    public short m_MaintenancePool;
    public bool m_AllowHomeless;

    public void Combine(ParkData otherData)
    {
      this.m_MaintenancePool += otherData.m_MaintenancePool;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_MaintenancePool);
      writer.Write(this.m_AllowHomeless);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_MaintenancePool);
      if (!(reader.context.version >= Version.homelessPark))
        return;
      reader.Read(out this.m_AllowHomeless);
    }
  }
}
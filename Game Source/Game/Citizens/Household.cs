﻿// Decompiled with JetBrains decompiler
// Type: Game.Citizens.Household
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  public struct Household : IComponentData, IQueryTypeParameter, ISerializable
  {
    public HouseholdFlags m_Flags;
    public int m_Resources;
    public short m_ConsumptionPerDay;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_Flags);
      writer.Write(this.m_Resources);
      writer.Write(this.m_ConsumptionPerDay);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      if (reader.context.version < Version.householdRandomSeedRemoved)
        reader.Read(out uint _);
      reader.Read(out this.m_Resources);
      reader.Read(out this.m_ConsumptionPerDay);
      this.m_Flags = (HouseholdFlags) num;
      if (this.m_Resources >= 0)
        return;
      this.m_Resources = 0;
    }
  }
}
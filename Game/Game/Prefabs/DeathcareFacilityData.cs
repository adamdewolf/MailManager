// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DeathcareFacilityData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct DeathcareFacilityData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<DeathcareFacilityData>,
    ISerializable
  {
    public int m_HearseCapacity;
    public int m_StorageCapacity;
    public float m_ProcessingRate;
    public bool m_LongTermStorage;

    public void Combine(DeathcareFacilityData otherData)
    {
      this.m_HearseCapacity += otherData.m_HearseCapacity;
      this.m_StorageCapacity += otherData.m_StorageCapacity;
      this.m_ProcessingRate += otherData.m_ProcessingRate;
      this.m_LongTermStorage |= otherData.m_LongTermStorage;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_HearseCapacity);
      writer.Write(this.m_StorageCapacity);
      writer.Write(this.m_ProcessingRate);
      writer.Write(this.m_LongTermStorage);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_HearseCapacity);
      reader.Read(out this.m_StorageCapacity);
      reader.Read(out this.m_ProcessingRate);
      reader.Read(out this.m_LongTermStorage);
    }
  }
}

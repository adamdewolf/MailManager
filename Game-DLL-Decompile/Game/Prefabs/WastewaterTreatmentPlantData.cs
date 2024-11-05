// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WastewaterTreatmentPlantData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct WastewaterTreatmentPlantData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<WastewaterTreatmentPlantData>,
    ISerializable
  {
    public int m_Capacity;
    public int m_WaterStorage;

    public void Combine(WastewaterTreatmentPlantData otherData)
    {
      this.m_Capacity += otherData.m_Capacity;
      this.m_WaterStorage += otherData.m_WaterStorage;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Capacity);
      writer.Write(this.m_WaterStorage);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Capacity);
      reader.Read(out this.m_WaterStorage);
    }
  }
}

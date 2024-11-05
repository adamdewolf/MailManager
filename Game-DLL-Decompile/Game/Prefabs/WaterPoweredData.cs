// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WaterPoweredData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct WaterPoweredData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<WaterPoweredData>,
    ISerializable
  {
    public float m_ProductionFactor;
    public float m_CapacityFactor;

    public void Combine(WaterPoweredData otherData)
    {
      this.m_ProductionFactor += otherData.m_ProductionFactor;
      this.m_CapacityFactor += otherData.m_CapacityFactor;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_ProductionFactor);
      writer.Write(this.m_CapacityFactor);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_ProductionFactor);
      reader.Read(out this.m_CapacityFactor);
    }
  }
}

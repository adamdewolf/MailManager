// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.GarbagePoweredData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct GarbagePoweredData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<GarbagePoweredData>,
    ISerializable
  {
    public int m_Capacity;
    public float m_ProductionPerUnit;

    public void Combine(GarbagePoweredData otherData)
    {
      this.m_Capacity += otherData.m_Capacity;
      this.m_ProductionPerUnit = math.max(this.m_ProductionPerUnit, otherData.m_ProductionPerUnit);
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Capacity);
      writer.Write(this.m_ProductionPerUnit);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Capacity);
      reader.Read(out this.m_ProductionPerUnit);
    }
  }
}

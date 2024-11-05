// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BatteryData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct BatteryData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<BatteryData>,
    ISerializable
  {
    public int m_Capacity;
    public int m_PowerOutput;

    public long capacityTicks => (long) (85 * this.m_Capacity);

    public void Combine(BatteryData otherData)
    {
      this.m_Capacity += otherData.m_Capacity;
      this.m_PowerOutput += otherData.m_PowerOutput;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Capacity);
      writer.Write(this.m_PowerOutput);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Capacity);
      reader.Read(out this.m_PowerOutput);
    }
  }
}

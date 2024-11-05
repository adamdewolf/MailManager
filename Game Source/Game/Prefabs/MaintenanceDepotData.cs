// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MaintenanceDepotData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Simulation;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct MaintenanceDepotData : 
    IComponentData,
    IQueryTypeParameter,
    ICombineData<MaintenanceDepotData>,
    ISerializable
  {
    public MaintenanceType m_MaintenanceType;
    public int m_VehicleCapacity;
    public float m_VehicleEfficiency;

    public void Combine(MaintenanceDepotData otherData)
    {
      this.m_MaintenanceType |= otherData.m_MaintenanceType;
      this.m_VehicleCapacity += otherData.m_VehicleCapacity;
      this.m_VehicleEfficiency += otherData.m_VehicleEfficiency;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_VehicleCapacity);
      writer.Write(this.m_VehicleEfficiency);
      writer.Write((byte) this.m_MaintenanceType);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_VehicleCapacity);
      reader.Read(out this.m_VehicleEfficiency);
      byte num;
      reader.Read(out num);
      this.m_MaintenanceType = (MaintenanceType) num;
    }
  }
}

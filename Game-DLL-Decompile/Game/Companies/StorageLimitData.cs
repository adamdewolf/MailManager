// Decompiled with JetBrains decompiler
// Type: Game.Companies.StorageLimitData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Prefabs;
using Unity.Entities;

#nullable disable
namespace Game.Companies
{
  public struct StorageLimitData : 
    IComponentData,
    IQueryTypeParameter,
    ISerializable,
    ICombineData<StorageLimitData>
  {
    public int m_Limit;

    public int GetAdjustedLimit(SpawnableBuildingData spawnable, BuildingData building)
    {
      return this.m_Limit * (int) spawnable.m_Level * building.m_LotSize.x * building.m_LotSize.y;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Limit);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Limit);
    }

    public void Combine(StorageLimitData otherData) => this.m_Limit += otherData.m_Limit;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Buildings.WaterTower
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct WaterTower : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_StoredWater;
    public int m_Polluted;
    public int m_LastStoredWater;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_StoredWater);
      writer.Write(this.m_Polluted);
      writer.Write(this.m_LastStoredWater);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_StoredWater);
      reader.Read(out this.m_Polluted);
      if (!(reader.context.version >= Version.waterSelectedInfoFix))
        return;
      reader.Read(out this.m_LastStoredWater);
    }
  }
}

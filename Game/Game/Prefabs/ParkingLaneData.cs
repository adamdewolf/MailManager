// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ParkingLaneData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct ParkingLaneData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float2 m_SlotSize;
    public float m_SlotAngle;
    public float m_SlotInterval;
    public float m_MaxCarLength;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_SlotSize);
      writer.Write(this.m_SlotAngle);
      writer.Write(this.m_SlotInterval);
      writer.Write(this.m_MaxCarLength);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_SlotSize);
      reader.Read(out this.m_SlotAngle);
      reader.Read(out this.m_SlotInterval);
      reader.Read(out this.m_MaxCarLength);
    }
  }
}

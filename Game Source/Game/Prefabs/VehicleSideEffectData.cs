// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.VehicleSideEffectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct VehicleSideEffectData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float3 m_Min;
    public float3 m_Max;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Min);
      writer.Write(this.m_Max);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Min);
      reader.Read(out this.m_Max);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.TrainNavigation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct TrainNavigation : IComponentData, IQueryTypeParameter, ISerializable
  {
    public TrainBogiePosition m_Front;
    public TrainBogiePosition m_Rear;
    public float m_Speed;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write<TrainBogiePosition>(this.m_Front);
      writer.Write<TrainBogiePosition>(this.m_Rear);
      writer.Write(this.m_Speed);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read<TrainBogiePosition>(out this.m_Front);
      reader.Read<TrainBogiePosition>(out this.m_Rear);
      reader.Read(out this.m_Speed);
    }
  }
}

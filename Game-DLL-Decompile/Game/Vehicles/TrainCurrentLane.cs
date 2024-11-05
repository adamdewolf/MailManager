// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.TrainCurrentLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Pathfind;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct TrainCurrentLane : IComponentData, IQueryTypeParameter, ISerializable
  {
    public TrainBogieLane m_Front;
    public TrainBogieLane m_Rear;
    public TrainBogieCache m_FrontCache;
    public TrainBogieCache m_RearCache;
    public float m_Duration;
    public float m_Distance;

    public TrainCurrentLane(PathElement pathElement)
    {
      this.m_Front = new TrainBogieLane(pathElement);
      this.m_Rear = new TrainBogieLane(pathElement);
      this.m_FrontCache = new TrainBogieCache(pathElement);
      this.m_RearCache = new TrainBogieCache(pathElement);
      this.m_Duration = 0.0f;
      this.m_Distance = 0.0f;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write<TrainBogieLane>(this.m_Front);
      writer.Write<TrainBogieLane>(this.m_Rear);
      writer.Write<TrainBogieCache>(this.m_FrontCache);
      writer.Write<TrainBogieCache>(this.m_RearCache);
      writer.Write(this.m_Duration);
      writer.Write(this.m_Distance);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read<TrainBogieLane>(out this.m_Front);
      reader.Read<TrainBogieLane>(out this.m_Rear);
      reader.Read<TrainBogieCache>(out this.m_FrontCache);
      reader.Read<TrainBogieCache>(out this.m_RearCache);
      if (!(reader.context.version >= Version.trafficFlowFixes))
        return;
      reader.Read(out this.m_Duration);
      reader.Read(out this.m_Distance);
    }
  }
}

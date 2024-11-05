// Decompiled with JetBrains decompiler
// Type: Game.Net.TrackLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct TrackLane : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_AccessRestriction;
    public TrackLaneFlags m_Flags;
    public float m_SpeedLimit;
    public float m_Curviness;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_AccessRestriction);
      writer.Write((uint) this.m_Flags);
      writer.Write(this.m_SpeedLimit);
      writer.Write(this.m_Curviness);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.pathfindRestrictions)
        reader.Read(out this.m_AccessRestriction);
      uint num;
      reader.Read(out num);
      reader.Read(out this.m_SpeedLimit);
      reader.Read(out this.m_Curviness);
      this.m_Flags = (TrackLaneFlags) num;
    }
  }
}

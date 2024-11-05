// Decompiled with JetBrains decompiler
// Type: Game.Net.LaneConnection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct LaneConnection : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_StartLane;
    public Entity m_EndLane;
    public float m_StartPosition;
    public float m_EndPosition;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_StartLane);
      writer.Write(this.m_EndLane);
      writer.Write(this.m_StartPosition);
      writer.Write(this.m_EndPosition);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_StartLane);
      reader.Read(out this.m_EndLane);
      reader.Read(out this.m_StartPosition);
      reader.Read(out this.m_EndPosition);
    }
  }
}

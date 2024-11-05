// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetLaneData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct NetLaneData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_PathfindPrefab;
    public LaneFlags m_Flags;
    public float m_Width;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_PathfindPrefab);
      writer.Write((uint) this.m_Flags);
      writer.Write(this.m_Width);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_PathfindPrefab);
      uint num;
      reader.Read(out num);
      reader.Read(out this.m_Width);
      this.m_Flags = (LaneFlags) num;
    }
  }
}

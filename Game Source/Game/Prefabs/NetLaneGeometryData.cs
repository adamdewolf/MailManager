// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetLaneGeometryData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct NetLaneGeometryData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float3 m_Size;
    public int m_MinLod;
    public MeshLayer m_GameLayers;
    public MeshLayer m_EditorLayers;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Size);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Size);
      this.m_MinLod = (int) byte.MaxValue;
      this.m_GameLayers = MeshLayer.Default;
      this.m_EditorLayers = MeshLayer.Default;
    }
  }
}

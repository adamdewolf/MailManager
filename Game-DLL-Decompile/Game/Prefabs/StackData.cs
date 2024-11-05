// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.StackData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct StackData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Bounds1 m_FirstBounds;
    public Bounds1 m_MiddleBounds;
    public Bounds1 m_LastBounds;
    public StackDirection m_Direction;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_Direction);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      this.m_MiddleBounds = new Bounds1(-1f, 1f);
      this.m_Direction = (StackDirection) num;
    }
  }
}

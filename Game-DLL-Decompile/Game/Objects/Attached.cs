// Decompiled with JetBrains decompiler
// Type: Game.Objects.Attached
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Objects
{
  public struct Attached : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Parent;
    public Entity m_OldParent;
    public float m_CurvePosition;

    public Attached(Entity parent, Entity oldParent, float curvePosition)
    {
      this.m_Parent = parent;
      this.m_OldParent = oldParent;
      this.m_CurvePosition = curvePosition;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Parent);
      writer.Write(this.m_CurvePosition);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Parent);
      reader.Read(out this.m_CurvePosition);
    }
  }
}

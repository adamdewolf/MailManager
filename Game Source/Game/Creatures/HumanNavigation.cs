// Decompiled with JetBrains decompiler
// Type: Game.Creatures.HumanNavigation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Objects;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Creatures
{
  public struct HumanNavigation : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float3 m_TargetPosition;
    public float2 m_TargetDirection;
    public float m_MaxSpeed;
    public TransformState m_TransformState;
    public byte m_LastActivity;
    public byte m_TargetActivity;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_TargetPosition);
      writer.Write(this.m_TargetDirection);
      writer.Write(this.m_TargetActivity);
      writer.Write((byte) this.m_TransformState);
      writer.Write(this.m_LastActivity);
      writer.Write(this.m_MaxSpeed);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_TargetPosition);
      if (reader.context.version >= Version.creatureTargetDirection)
      {
        reader.Read(out this.m_TargetDirection);
        reader.Read(out this.m_TargetActivity);
      }
      if (reader.context.version >= Version.animationStateFix)
      {
        byte num;
        reader.Read(out num);
        reader.Read(out this.m_LastActivity);
        this.m_TransformState = (TransformState) num;
      }
      reader.Read(out this.m_MaxSpeed);
    }
  }
}

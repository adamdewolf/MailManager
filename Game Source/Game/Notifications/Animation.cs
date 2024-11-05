// Decompiled with JetBrains decompiler
// Type: Game.Notifications.Animation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Notifications
{
  public struct Animation : IComponentData, IQueryTypeParameter, ISerializable
  {
    public float m_Timer;
    public float m_Duration;
    public AnimationType m_Type;

    public Animation(AnimationType type, float timer, float duration)
    {
      this.m_Timer = timer;
      this.m_Duration = duration;
      this.m_Type = type;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Timer);
      writer.Write(this.m_Duration);
      writer.Write((byte) this.m_Type);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Timer);
      reader.Read(out this.m_Duration);
      byte num;
      reader.Read(out num);
      this.m_Type = (AnimationType) num;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Citizens.HealthProblem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  public struct HealthProblem : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Event;
    public Entity m_HealthcareRequest;
    public HealthProblemFlags m_Flags;
    public byte m_Timer;

    public HealthProblem(Entity _event, HealthProblemFlags flags)
    {
      this.m_Event = _event;
      this.m_HealthcareRequest = Entity.Null;
      this.m_Flags = flags;
      this.m_Timer = (byte) 0;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Event);
      writer.Write(this.m_HealthcareRequest);
      writer.Write((byte) this.m_Flags);
      writer.Write(this.m_Timer);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Event);
      reader.Read(out this.m_HealthcareRequest);
      byte num;
      reader.Read(out num);
      if (reader.context.version >= Version.healthcareNotifications)
        reader.Read(out this.m_Timer);
      this.m_Flags = (HealthProblemFlags) num;
    }
  }
}

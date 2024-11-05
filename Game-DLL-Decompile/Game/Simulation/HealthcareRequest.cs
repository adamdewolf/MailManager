// Decompiled with JetBrains decompiler
// Type: Game.Simulation.HealthcareRequest
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct HealthcareRequest : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Citizen;
    public HealthcareRequestType m_Type;

    public HealthcareRequest(Entity citizen, HealthcareRequestType type)
    {
      this.m_Citizen = citizen;
      this.m_Type = type;
    }

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Citizen);
      writer.Write((byte) this.m_Type);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Citizen);
      byte num;
      reader.Read(out num);
      this.m_Type = (HealthcareRequestType) num;
    }
  }
}

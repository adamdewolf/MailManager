// Decompiled with JetBrains decompiler
// Type: Game.Buildings.DeathcareFacility
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct DeathcareFacility : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_TargetRequest;
    public DeathcareFacilityFlags m_Flags;
    public float m_ProcessingState;
    public int m_LongTermStoredCount;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_TargetRequest);
      writer.Write((byte) this.m_Flags);
      writer.Write(this.m_ProcessingState);
      writer.Write(this.m_LongTermStoredCount);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.reverseServiceRequests2)
        reader.Read(out this.m_TargetRequest);
      byte num;
      reader.Read(out num);
      reader.Read(out this.m_ProcessingState);
      reader.Read(out this.m_LongTermStoredCount);
      this.m_Flags = (DeathcareFacilityFlags) num;
    }
  }
}

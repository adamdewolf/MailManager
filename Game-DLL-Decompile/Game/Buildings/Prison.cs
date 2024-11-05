// Decompiled with JetBrains decompiler
// Type: Game.Buildings.Prison
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  public struct Prison : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_TargetRequest;
    public PrisonFlags m_Flags;
    public sbyte m_PrisonerWellbeing;
    public sbyte m_PrisonerHealth;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_TargetRequest);
      writer.Write((byte) this.m_Flags);
      writer.Write(this.m_PrisonerWellbeing);
      writer.Write(this.m_PrisonerHealth);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      if (reader.context.version >= Version.reverseServiceRequests)
        reader.Read(out this.m_TargetRequest);
      byte num;
      reader.Read(out num);
      this.m_Flags = (PrisonFlags) num;
      if (!(reader.context.version >= Version.happinessAdjustRefactoring))
        return;
      reader.Read(out this.m_PrisonerWellbeing);
      reader.Read(out this.m_PrisonerHealth);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Citizens.Worker
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Companies;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  public struct Worker : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Workplace;
    public float m_LastCommuteTime;
    public byte m_Level;
    public Workshift m_Shift;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Workplace);
      writer.Write(this.m_LastCommuteTime);
      writer.Write(this.m_Level);
      writer.Write((byte) this.m_Shift);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Workplace);
      reader.Read(out this.m_LastCommuteTime);
      reader.Read(out this.m_Level);
      byte num;
      reader.Read(out num);
      this.m_Shift = (Workshift) num;
    }
  }
}

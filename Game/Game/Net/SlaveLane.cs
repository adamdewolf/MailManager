// Decompiled with JetBrains decompiler
// Type: Game.Net.SlaveLane
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct SlaveLane : IComponentData, IQueryTypeParameter, ISerializable
  {
    public SlaveLaneFlags m_Flags;
    public uint m_Group;
    public ushort m_MinIndex;
    public ushort m_MaxIndex;
    public ushort m_SubIndex;
    public ushort m_MasterIndex;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((uint) this.m_Flags);
      writer.Write(this.m_Group);
      writer.Write(this.m_SubIndex);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      uint num1;
      reader.Read(out num1);
      reader.Read(out this.m_Group);
      if (reader.context.version >= Version.laneCountOverflowFix)
      {
        reader.Read(out this.m_SubIndex);
      }
      else
      {
        byte num2;
        reader.Read(out num2);
        reader.Read(out byte _);
        this.m_SubIndex = (ushort) num2;
      }
      this.m_Flags = (SlaveLaneFlags) num1;
    }
  }
}

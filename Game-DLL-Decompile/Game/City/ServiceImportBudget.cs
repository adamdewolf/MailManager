// Decompiled with JetBrains decompiler
// Type: Game.City.ServiceImportBudget
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.City
{
  public struct ServiceImportBudget : IBufferElementData, ISerializable
  {
    public PlayerResource m_Resource;
    public int m_MaximumBudget;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((int) this.m_Resource);
      writer.Write(this.m_MaximumBudget);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      int num;
      reader.Read(out num);
      this.m_Resource = (PlayerResource) num;
      reader.Read(out this.m_MaximumBudget);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Areas.Storage
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Areas
{
  public struct Storage : IComponentData, IQueryTypeParameter, ISerializable
  {
    public int m_Amount;
    public float m_WorkAmount;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Amount);
      writer.Write(this.m_WorkAmount);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Amount);
      if (!(reader.context.version >= Version.garbageFacilityRefactor))
        return;
      reader.Read(out this.m_WorkAmount);
    }
  }
}

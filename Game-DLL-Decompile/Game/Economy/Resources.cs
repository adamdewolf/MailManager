// Decompiled with JetBrains decompiler
// Type: Game.Economy.Resources
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Economy
{
  public struct Resources : IBufferElementData, ISerializable
  {
    public Resource m_Resource;
    public int m_Amount;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((sbyte) EconomyUtils.GetResourceIndex(this.m_Resource));
      writer.Write(this.m_Amount);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      sbyte index;
      reader.Read(out index);
      reader.Read(out this.m_Amount);
      this.m_Resource = EconomyUtils.GetResource((int) index);
      if (!(reader.context.version < Version.resetNegativeResource) || this.m_Resource == Resource.Money)
        return;
      if (this.m_Amount > 1000000)
      {
        this.m_Amount = 1000000;
      }
      else
      {
        if (this.m_Amount >= 0)
          return;
        this.m_Amount = 0;
      }
    }
  }
}

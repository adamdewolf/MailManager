// Decompiled with JetBrains decompiler
// Type: Game.Citizens.HouseholdNeed
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Economy;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  public struct HouseholdNeed : IComponentData, IQueryTypeParameter, ISerializable
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
      if (this.m_Amount <= 0 || this.m_Resource != Resource.Money)
        return;
      this.m_Amount = 0;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Companies.BuyingCompany
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Companies
{
  public struct BuyingCompany : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_LastTradePartner;
    public float m_MeanInputTripLength;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_LastTradePartner);
      writer.Write(this.m_MeanInputTripLength);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_LastTradePartner);
      reader.Read(out this.m_MeanInputTripLength);
    }
  }
}

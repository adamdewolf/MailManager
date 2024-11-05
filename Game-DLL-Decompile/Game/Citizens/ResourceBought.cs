// Decompiled with JetBrains decompiler
// Type: Game.Citizens.ResourceBought
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Economy;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  public struct ResourceBought : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Seller;
    public Entity m_Payer;
    public Resource m_Resource;
    public int m_Amount;
    public float m_Distance;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Seller);
      writer.Write(this.m_Payer);
      writer.Write((sbyte) EconomyUtils.GetResourceIndex(this.m_Resource));
      writer.Write(this.m_Amount);
      writer.Write(this.m_Distance);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Seller);
      reader.Read(out this.m_Payer);
      sbyte index;
      reader.Read(out index);
      reader.Read(out this.m_Amount);
      reader.Read(out this.m_Distance);
      this.m_Resource = EconomyUtils.GetResource((int) index);
    }
  }
}

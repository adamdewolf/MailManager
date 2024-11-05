// Decompiled with JetBrains decompiler
// Type: Game.Companies.ResourceBuyer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Economy;
using Game.Pathfind;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Companies
{
  public struct ResourceBuyer : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Entity m_Payer;
    public SetupTargetFlags m_Flags;
    public Resource m_ResourceNeeded;
    public int m_AmountNeeded;
    public float3 m_Location;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_Payer);
      writer.Write((byte) this.m_Flags);
      writer.Write((sbyte) EconomyUtils.GetResourceIndex(this.m_ResourceNeeded));
      writer.Write(this.m_AmountNeeded);
      writer.Write(this.m_Location);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_Payer);
      byte num;
      reader.Read(out num);
      sbyte index;
      reader.Read(out index);
      reader.Read(out this.m_AmountNeeded);
      reader.Read(out this.m_Location);
      this.m_Flags = (SetupTargetFlags) num;
      this.m_ResourceNeeded = EconomyUtils.GetResource((int) index);
    }
  }
}

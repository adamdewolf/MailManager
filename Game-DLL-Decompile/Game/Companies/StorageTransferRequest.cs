// Decompiled with JetBrains decompiler
// Type: Game.Companies.StorageTransferRequest
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Game.Economy;
using Unity.Entities;

#nullable disable
namespace Game.Companies
{
  public struct StorageTransferRequest : IBufferElementData, ISerializable
  {
    public StorageTransferFlags m_Flags;
    public Resource m_Resource;
    public int m_Amount;
    public Entity m_Target;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write((byte) this.m_Flags);
      writer.Write((sbyte) EconomyUtils.GetResourceIndex(this.m_Resource));
      writer.Write(this.m_Amount);
      writer.Write(this.m_Target);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      byte num;
      reader.Read(out num);
      sbyte index;
      reader.Read(out index);
      reader.Read(out this.m_Amount);
      reader.Read(out this.m_Target);
      this.m_Flags = (StorageTransferFlags) num;
      this.m_Resource = EconomyUtils.GetResource((int) index);
    }
  }
}

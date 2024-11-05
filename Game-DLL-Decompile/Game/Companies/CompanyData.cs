// Decompiled with JetBrains decompiler
// Type: Game.Companies.CompanyData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Companies
{
  public struct CompanyData : IComponentData, IQueryTypeParameter, ISerializable
  {
    public Random m_RandomSeed;
    public Entity m_Brand;

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_RandomSeed.state);
      writer.Write(this.m_Brand);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_RandomSeed.state);
      reader.Read(out this.m_Brand);
    }
  }
}

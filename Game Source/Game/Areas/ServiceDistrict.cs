// Decompiled with JetBrains decompiler
// Type: Game.Areas.ServiceDistrict
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Areas
{
  [InternalBufferCapacity(0)]
  public struct ServiceDistrict : IBufferElementData, IEquatable<ServiceDistrict>, ISerializable
  {
    public Entity m_District;

    public ServiceDistrict(Entity district) => this.m_District = district;

    public bool Equals(ServiceDistrict other) => this.m_District.Equals(other.m_District);

    public override int GetHashCode() => this.m_District.GetHashCode();

    public void Serialize<TWriter>(TWriter writer) where TWriter : IWriter
    {
      writer.Write(this.m_District);
    }

    public void Deserialize<TReader>(TReader reader) where TReader : IReader
    {
      reader.Read(out this.m_District);
    }
  }
}

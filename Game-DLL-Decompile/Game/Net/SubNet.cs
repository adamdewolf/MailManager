// Decompiled with JetBrains decompiler
// Type: Game.Net.SubNet
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  [InternalBufferCapacity(0)]
  public struct SubNet : IBufferElementData, IEquatable<SubNet>, IEmptySerializable
  {
    public Entity m_SubNet;

    public SubNet(Entity subNet) => this.m_SubNet = subNet;

    public bool Equals(SubNet other) => this.m_SubNet.Equals(other.m_SubNet);

    public override int GetHashCode() => this.m_SubNet.GetHashCode();
  }
}

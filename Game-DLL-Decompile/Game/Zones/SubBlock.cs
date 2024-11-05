// Decompiled with JetBrains decompiler
// Type: Game.Zones.SubBlock
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Zones
{
  [InternalBufferCapacity(4)]
  public struct SubBlock : IBufferElementData, IEquatable<SubBlock>, IEmptySerializable
  {
    public Entity m_SubBlock;

    public SubBlock(Entity block) => this.m_SubBlock = block;

    public bool Equals(SubBlock other) => this.m_SubBlock.Equals(other.m_SubBlock);

    public override int GetHashCode() => this.m_SubBlock.GetHashCode();
  }
}

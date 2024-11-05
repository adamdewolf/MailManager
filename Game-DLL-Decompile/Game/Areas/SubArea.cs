// Decompiled with JetBrains decompiler
// Type: Game.Areas.SubArea
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
  public struct SubArea : IBufferElementData, IEquatable<SubArea>, IEmptySerializable
  {
    public Entity m_Area;

    public SubArea(Entity area) => this.m_Area = area;

    public bool Equals(SubArea other) => this.m_Area.Equals(other.m_Area);

    public override int GetHashCode() => this.m_Area.GetHashCode();
  }
}

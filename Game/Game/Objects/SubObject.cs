// Decompiled with JetBrains decompiler
// Type: Game.Objects.SubObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Objects
{
  [InternalBufferCapacity(0)]
  public struct SubObject : IBufferElementData, IEquatable<SubObject>, IEmptySerializable
  {
    public Entity m_SubObject;

    public SubObject(Entity subObject) => this.m_SubObject = subObject;

    public bool Equals(SubObject other) => this.m_SubObject.Equals(other.m_SubObject);

    public override int GetHashCode() => this.m_SubObject.GetHashCode();
  }
}

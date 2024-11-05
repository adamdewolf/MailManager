// Decompiled with JetBrains decompiler
// Type: Game.Buildings.ConnectedBuilding
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  [InternalBufferCapacity(0)]
  public struct ConnectedBuilding : 
    IBufferElementData,
    IEquatable<ConnectedBuilding>,
    IEmptySerializable
  {
    public Entity m_Building;

    public ConnectedBuilding(Entity building) => this.m_Building = building;

    public bool Equals(ConnectedBuilding other) => this.m_Building.Equals(other.m_Building);

    public override int GetHashCode() => this.m_Building.GetHashCode();
  }
}

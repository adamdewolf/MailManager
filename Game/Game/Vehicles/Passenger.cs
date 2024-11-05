// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.Passenger
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  [InternalBufferCapacity(0)]
  public struct Passenger : IBufferElementData, IEquatable<Passenger>, IEmptySerializable
  {
    public Entity m_Passenger;

    public Passenger(Entity passenger) => this.m_Passenger = passenger;

    public bool Equals(Passenger other) => this.m_Passenger.Equals(other.m_Passenger);

    public override int GetHashCode() => this.m_Passenger.GetHashCode();
  }
}

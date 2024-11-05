// Decompiled with JetBrains decompiler
// Type: Game.Routes.RouteVehicle
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Routes
{
  [InternalBufferCapacity(0)]
  public struct RouteVehicle : IBufferElementData, IEquatable<RouteVehicle>, IEmptySerializable
  {
    public Entity m_Vehicle;

    public RouteVehicle(Entity vehicle) => this.m_Vehicle = vehicle;

    public bool Equals(RouteVehicle other) => this.m_Vehicle.Equals(other.m_Vehicle);

    public override int GetHashCode() => this.m_Vehicle.GetHashCode();
  }
}

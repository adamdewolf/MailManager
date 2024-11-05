// Decompiled with JetBrains decompiler
// Type: Game.Routes.ConnectedRoute
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
  public struct ConnectedRoute : IBufferElementData, IEquatable<ConnectedRoute>, IEmptySerializable
  {
    public Entity m_Waypoint;

    public ConnectedRoute(Entity waypoint) => this.m_Waypoint = waypoint;

    public bool Equals(ConnectedRoute other) => this.m_Waypoint.Equals(other.m_Waypoint);

    public override int GetHashCode() => this.m_Waypoint.GetHashCode();
  }
}

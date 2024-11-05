// Decompiled with JetBrains decompiler
// Type: Game.Buildings.SpawnLocationElement
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
  public struct SpawnLocationElement : 
    IBufferElementData,
    IEquatable<SpawnLocationElement>,
    IEmptySerializable
  {
    public Entity m_SpawnLocation;

    public SpawnLocationElement(Entity spawnLocation) => this.m_SpawnLocation = spawnLocation;

    public bool Equals(SpawnLocationElement other)
    {
      return this.m_SpawnLocation.Equals(other.m_SpawnLocation);
    }

    public override int GetHashCode() => this.m_SpawnLocation.GetHashCode();
  }
}

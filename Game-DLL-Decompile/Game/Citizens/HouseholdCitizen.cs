// Decompiled with JetBrains decompiler
// Type: Game.Citizens.HouseholdCitizen
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Citizens
{
  [InternalBufferCapacity(5)]
  public struct HouseholdCitizen : 
    IBufferElementData,
    IEquatable<HouseholdCitizen>,
    IEmptySerializable
  {
    public Entity m_Citizen;

    public HouseholdCitizen(Entity citizen) => this.m_Citizen = citizen;

    public bool Equals(HouseholdCitizen other) => this.m_Citizen.Equals(other.m_Citizen);

    public override int GetHashCode() => this.m_Citizen.GetHashCode();

    public static implicit operator Entity(HouseholdCitizen citizen) => citizen.m_Citizen;
  }
}

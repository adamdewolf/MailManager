// Decompiled with JetBrains decompiler
// Type: Game.Tools.OwnerDefinition
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Tools
{
  public struct OwnerDefinition : IComponentData, IQueryTypeParameter, IEquatable<OwnerDefinition>
  {
    public Entity m_Prefab;
    public float3 m_Position;
    public quaternion m_Rotation;

    public bool Equals(OwnerDefinition other)
    {
      return this.m_Prefab.Equals(other.m_Prefab) && this.m_Position.Equals(other.m_Position) && this.m_Rotation.Equals(other.m_Rotation);
    }

    public override int GetHashCode()
    {
      return ((17 * 31 + this.m_Prefab.GetHashCode()) * 31 + this.m_Position.GetHashCode()) * 31 + this.m_Rotation.GetHashCode();
    }
  }
}

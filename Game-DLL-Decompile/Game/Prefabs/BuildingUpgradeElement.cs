// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BuildingUpgradeElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct BuildingUpgradeElement : IBufferElementData, IEquatable<BuildingUpgradeElement>
  {
    public Entity m_Upgrade;

    public BuildingUpgradeElement(Entity upgrade) => this.m_Upgrade = upgrade;

    public bool Equals(BuildingUpgradeElement other) => this.m_Upgrade.Equals(other.m_Upgrade);

    public override int GetHashCode() => this.m_Upgrade.GetHashCode();
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ZoneBuiltDataKey
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ZoneBuiltDataKey : IEquatable<ZoneBuiltDataKey>
  {
    public Entity m_Zone;
    public int m_Level;

    public bool Equals(ZoneBuiltDataKey other)
    {
      return this.m_Zone.Equals(other.m_Zone) && this.m_Level.Equals(other.m_Level);
    }

    public override int GetHashCode()
    {
      return (17 * 31 + this.m_Zone.GetHashCode()) * 31 + this.m_Level.GetHashCode();
    }
  }
}

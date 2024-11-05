// Decompiled with JetBrains decompiler
// Type: Game.Areas.AreaSearchItem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Areas
{
  public struct AreaSearchItem : IEquatable<AreaSearchItem>
  {
    public Entity m_Area;
    public int m_Triangle;

    public AreaSearchItem(Entity area, int triangle)
    {
      this.m_Area = area;
      this.m_Triangle = triangle;
    }

    public bool Equals(AreaSearchItem other)
    {
      return this.m_Area.Equals(other.m_Area) & this.m_Triangle.Equals(other.m_Triangle);
    }

    public override int GetHashCode()
    {
      return (17 * 31 + this.m_Area.GetHashCode()) * 31 + this.m_Triangle.GetHashCode();
    }
  }
}

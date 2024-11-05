// Decompiled with JetBrains decompiler
// Type: Game.Routes.RouteSearchItem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Routes
{
  public struct RouteSearchItem : IEquatable<RouteSearchItem>
  {
    public Entity m_Entity;
    public int m_Element;

    public RouteSearchItem(Entity entity, int element)
    {
      this.m_Entity = entity;
      this.m_Element = element;
    }

    public bool Equals(RouteSearchItem other)
    {
      return this.m_Entity.Equals(other.m_Entity) & this.m_Element.Equals(other.m_Element);
    }

    public override int GetHashCode()
    {
      return (17 * 31 + this.m_Entity.GetHashCode()) * 31 + this.m_Element.GetHashCode();
    }
  }
}

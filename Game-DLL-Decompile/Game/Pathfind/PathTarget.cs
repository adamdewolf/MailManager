﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathTarget
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Pathfind
{
  public struct PathTarget
  {
    public Entity m_Target;
    public Entity m_Entity;
    public float m_Delta;
    public float m_Cost;
    public EdgeFlags m_Flags;

    public PathTarget(Entity target, Entity entity, float delta, float cost)
    {
      this.m_Target = target;
      this.m_Entity = entity;
      this.m_Delta = delta;
      this.m_Cost = cost;
      this.m_Flags = EdgeFlags.DefaultMask;
    }

    public PathTarget(Entity target, Entity entity, float delta, float cost, EdgeFlags flags)
    {
      this.m_Target = target;
      this.m_Entity = entity;
      this.m_Delta = delta;
      this.m_Cost = cost;
      this.m_Flags = flags;
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.NotificationInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.UI.InGame
{
  public class NotificationInfo : IComparable<NotificationInfo>
  {
    private readonly List<Entity> m_Targets;

    public Entity entity { get; }

    public Entity target { get; }

    public int priority { get; }

    public int count
    {
      get
      {
        List<Entity> targets = this.m_Targets;
        return targets == null ? 0 : __nonvirtual (targets.Count);
      }
    }

    public NotificationInfo(Notification notification)
    {
      this.entity = notification.entity;
      this.target = notification.target;
      this.priority = (int) notification.priority;
      this.m_Targets = new List<Entity>(10)
      {
        notification.target
      };
    }

    public void AddTarget(Entity otherTarget)
    {
      if (this.m_Targets.Contains(otherTarget))
        return;
      this.m_Targets.Add(otherTarget);
    }

    public int CompareTo(NotificationInfo other) => this.priority - other.priority;
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Effects.SourceUpdateData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Objects;
using Unity.Collections;
using Unity.Entities;

#nullable disable
namespace Game.Effects
{
  public struct SourceUpdateData
  {
    private NativeQueue<SourceUpdateInfo>.ParallelWriter m_SourceUpdateQueue;

    public SourceUpdateData(
      NativeQueue<SourceUpdateInfo>.ParallelWriter sourceUpdateQueue)
    {
      this.m_SourceUpdateQueue = sourceUpdateQueue;
    }

    public void Add(Entity entity, Transform transform)
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_SourceInfo = new SourceInfo(entity, -1),
        m_Type = SourceUpdateType.Add,
        m_Transform = transform
      });
    }

    public void Add(SourceInfo sourceInfo)
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_SourceInfo = sourceInfo,
        m_Type = SourceUpdateType.Add
      });
    }

    public void AddTemp(Entity prefab, Transform transform)
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_SourceInfo = new SourceInfo(prefab, -1),
        m_Type = SourceUpdateType.Temp,
        m_Transform = transform
      });
    }

    public void AddSnap()
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_Type = SourceUpdateType.Snap
      });
    }

    public void Remove(Entity entity)
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_SourceInfo = new SourceInfo(entity, -1),
        m_Type = SourceUpdateType.Remove
      });
    }

    public void Remove(SourceInfo sourceInfo)
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_SourceInfo = sourceInfo,
        m_Type = SourceUpdateType.Remove
      });
    }

    public void WrongPrefab(SourceInfo sourceInfo)
    {
      this.m_SourceUpdateQueue.Enqueue(new SourceUpdateInfo()
      {
        m_SourceInfo = sourceInfo,
        m_Type = SourceUpdateType.WrongPrefab
      });
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UnlockRequirement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct UnlockRequirement : IBufferElementData, IEquatable<UnlockRequirement>
  {
    public Entity m_Prefab;
    public UnlockFlags m_Flags;

    public UnlockRequirement(Entity prefab, UnlockFlags flags)
    {
      this.m_Prefab = prefab;
      this.m_Flags = flags;
    }

    public bool Equals(UnlockRequirement other)
    {
      return this.m_Prefab.Equals(other.m_Prefab) && this.m_Flags == other.m_Flags;
    }

    public override bool Equals(object obj) => obj is UnlockRequirement other && this.Equals(other);

    public override int GetHashCode()
    {
      return (int) ((UnlockFlags) (this.m_Prefab.GetHashCode() * 397) ^ this.m_Flags);
    }
  }
}
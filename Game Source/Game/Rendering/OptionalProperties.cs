﻿// Decompiled with JetBrains decompiler
// Type: Game.Rendering.OptionalProperties
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Rendering;
using Game.Prefabs;
using System;

#nullable disable
namespace Game.Rendering
{
  public struct OptionalProperties : 
    IOptionalProperties<OptionalProperties>,
    IEquatable<OptionalProperties>
  {
    private BatchFlags m_Flags;
    private MeshType m_MeshTypes;

    public OptionalProperties(BatchFlags flags, MeshType meshTypes)
    {
      this.m_Flags = flags;
      this.m_MeshTypes = meshTypes;
    }

    public bool EnableProperty(OptionalProperties required)
    {
      if ((this.m_Flags & required.m_Flags) != required.m_Flags)
        return false;
      return (this.m_MeshTypes & required.m_MeshTypes) != (MeshType) 0 || required.m_MeshTypes == (MeshType) 0;
    }

    public bool MergeRequirements(OptionalProperties other)
    {
      this.m_MeshTypes |= other.m_MeshTypes;
      return this.m_Flags == other.m_Flags;
    }

    public bool Equals(OptionalProperties other)
    {
      return this.m_Flags == other.m_Flags && this.m_MeshTypes == other.m_MeshTypes;
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DistrictModifierData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Areas;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct DistrictModifierData : IBufferElementData
  {
    public DistrictModifierType m_Type;
    public ModifierValueMode m_Mode;
    public Bounds1 m_Range;

    public DistrictModifierData(DistrictModifierType type, ModifierValueMode mode, Bounds1 range)
    {
      this.m_Type = type;
      this.m_Mode = mode;
      this.m_Range = range;
    }
  }
}
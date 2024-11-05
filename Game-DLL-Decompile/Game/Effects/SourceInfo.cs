// Decompiled with JetBrains decompiler
// Type: Game.Effects.SourceInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Effects
{
  public struct SourceInfo : IEquatable<SourceInfo>
  {
    public Entity m_Entity;
    public int m_EffectIndex;

    public SourceInfo(Entity entity, int effectIndex)
    {
      this.m_Entity = entity;
      this.m_EffectIndex = effectIndex;
    }

    public bool Equals(SourceInfo other)
    {
      return this.m_Entity == other.m_Entity && this.m_EffectIndex == other.m_EffectIndex;
    }

    public override int GetHashCode() => this.m_Entity.GetHashCode() ^ this.m_EffectIndex;
  }
}

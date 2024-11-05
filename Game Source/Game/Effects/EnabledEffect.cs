// Decompiled with JetBrains decompiler
// Type: Game.Effects.EnabledEffect
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Effects
{
  [FormerlySerializedAs("Game.Effects.EffectOwner, Game")]
  [InternalBufferCapacity(2)]
  public struct EnabledEffect : IBufferElementData, IEmptySerializable
  {
    public int m_EffectIndex;
    public int m_EnabledIndex;
  }
}

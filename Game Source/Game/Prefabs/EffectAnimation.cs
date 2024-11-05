// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.EffectAnimation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct EffectAnimation : IBufferElementData
  {
    public uint m_DurationFrames;
    public AnimationCurve1 m_AnimationCurve;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LightAnimation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using System.Runtime.InteropServices;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  [StructLayout(LayoutKind.Explicit)]
  public struct LightAnimation : IBufferElementData
  {
    [FieldOffset(0)]
    public uint m_DurationFrames;
    [FieldOffset(4)]
    public AnimationCurve1 m_AnimationCurve;
    [FieldOffset(4)]
    public SignalAnimation m_SignalAnimation;
  }
}

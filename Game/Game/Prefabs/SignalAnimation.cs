﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SignalAnimation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct SignalAnimation
  {
    private FixedList128Bytes<SignalGroupMask> m_Buffer;
    private float m_LengthFactor;

    public SignalAnimation(SignalGroupMask[] masks)
    {
      this.m_Buffer = new FixedList128Bytes<SignalGroupMask>();
      this.m_Buffer.Length = masks.Length;
      for (int index = 0; index < masks.Length; ++index)
        this.m_Buffer[index] = masks[index];
      this.m_LengthFactor = (float) this.m_Buffer.Length;
    }

    public float Evaluate(SignalGroupMask signalGroupMask, float time)
    {
      return math.select(0.0f, 1f, (this.m_Buffer[math.clamp((int) math.floor(time * this.m_LengthFactor), 0, this.m_Buffer.Length - 1)] & signalGroupMask) != 0);
    }
  }
}
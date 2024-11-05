// Decompiled with JetBrains decompiler
// Type: Game.Triggers.RadioTag
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Entities;

#nullable disable
namespace Game.Triggers
{
  public struct RadioTag : IEquatable<RadioTag>
  {
    public Entity m_Event;
    public Entity m_Target;
    public Game.Audio.Radio.Radio.SegmentType m_SegmentType;
    public int m_EmergencyFrameDelay;

    public bool Equals(RadioTag other)
    {
      return this.m_Event == other.m_Event && this.m_Target == other.m_Target && this.m_SegmentType == other.m_SegmentType;
    }
  }
}

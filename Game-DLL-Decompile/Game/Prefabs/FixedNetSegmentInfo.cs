// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FixedNetSegmentInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class FixedNetSegmentInfo
  {
    public int2 m_CountRange;
    public float m_Length;
    public bool m_CanCurve;
    public NetPieceRequirements[] m_SetState;
    public NetPieceRequirements[] m_UnsetState;
  }
}

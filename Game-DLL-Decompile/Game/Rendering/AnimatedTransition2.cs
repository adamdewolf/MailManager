﻿// Decompiled with JetBrains decompiler
// Type: Game.Rendering.AnimatedTransition2
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Mathematics;

#nullable disable
namespace Game.Rendering
{
  public struct AnimatedTransition2
  {
    public int2 m_TransitionIndex;
    public float2 m_TransitionFrame;
    public float2 m_TransitionWeight;
    public int m_MetaIndex;
    public int m_CurrentIndex;
    public float m_CurrentFrame;
  }
}
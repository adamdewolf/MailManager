﻿// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.TutorialPhaseData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Tutorials
{
  public struct TutorialPhaseData : IComponentData, IQueryTypeParameter
  {
    public TutorialPhaseType m_Type;
    public float m_OverrideCompletionDelay;
  }
}
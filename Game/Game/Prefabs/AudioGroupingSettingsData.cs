﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AudioGroupingSettingsData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Simulation;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct AudioGroupingSettingsData : IBufferElementData
  {
    public GroupAmbienceType m_Type;
    public float2 m_Height;
    public float m_FadeSpeed;
    public float m_Scale;
    public Entity m_GroupSoundNear;
    public Entity m_GroupSoundFar;
    public float2 m_NearHeight;
    public float m_NearWeight;
  }
}
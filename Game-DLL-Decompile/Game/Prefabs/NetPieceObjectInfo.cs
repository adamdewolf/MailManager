﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetPieceObjectInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class NetPieceObjectInfo
  {
    public ObjectPrefab m_Object;
    public float3 m_Position;
    public float3 m_Offset;
    public quaternion m_Rotation = quaternion.identity;
    public NetPieceRequirements[] m_RequireAll;
    public NetPieceRequirements[] m_RequireAny;
    public NetPieceRequirements[] m_RequireNone;
    [Range(0.0f, 100f)]
    public int m_Probability = 100;
    public float m_MinLength;
    public float2 m_CurveOffsetRange;
    public float3 m_Spacing;
    public float2 m_UseCurveRotation = new float2(0.0f, 1f);
    public bool m_FlipWhenInverted;
    public bool m_EvenSpacing;
    public bool m_SpacingOverride;
  }
}
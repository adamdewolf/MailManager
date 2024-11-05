// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AuxiliaryLaneInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class AuxiliaryLaneInfo
  {
    public NetLanePrefab m_Lane;
    public float3 m_Position;
    public NetPieceRequirements[] m_RequireAll;
    public NetPieceRequirements[] m_RequireAny;
    public NetPieceRequirements[] m_RequireNone;
    public float3 m_Spacing;
    public bool m_EvenSpacing;
    public bool m_FindAnchor;
  }
}

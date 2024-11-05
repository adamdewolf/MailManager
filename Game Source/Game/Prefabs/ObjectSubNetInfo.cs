// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ObjectSubNetInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using System;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class ObjectSubNetInfo
  {
    public NetPrefab m_NetPrefab;
    public Bezier4x3 m_BezierCurve;
    public int2 m_NodeIndex = new int2(-1, -1);
    public int2 m_ParentMesh = new int2(-1, -1);
    public NetPieceRequirements[] m_Upgrades;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetSubObjectInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class NetSubObjectInfo
  {
    public ObjectPrefab m_Object;
    public float3 m_Position;
    public quaternion m_Rotation;
    public NetObjectPlacement m_Placement;
    public int m_FixedIndex;
    public bool m_AnchorTop;
    public bool m_AnchorCenter;
    public bool m_RequireElevated;
    public bool m_RequireOutsideConnection;
    public bool m_RequireDeadEnd;
    public bool m_RequireOrphan;
  }
}

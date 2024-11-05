// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetLaneMeshInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class NetLaneMeshInfo
  {
    public RenderPrefab m_Mesh;
    public bool m_RequireSafe;
    public bool m_RequireLevelCrossing;
    public bool m_RequireEditor;
    public bool m_RequireTrackCrossing;
    public bool m_RequireClear;
    public bool m_RequireLeftHandTraffic;
    public bool m_RequireRightHandTraffic;
  }
}

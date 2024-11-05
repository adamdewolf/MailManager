// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SecondaryLaneInfo2
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public class SecondaryLaneInfo2
  {
    public NetLanePrefab m_Lane;
    public bool m_RequireStop;
    public bool m_RequireYield;
    public bool m_RequirePavement;

    public SecondaryNetLaneFlags GetFlags()
    {
      SecondaryNetLaneFlags flags = (SecondaryNetLaneFlags) 0;
      if (this.m_RequireStop)
        flags |= SecondaryNetLaneFlags.RequireStop;
      if (this.m_RequireYield)
        flags |= SecondaryNetLaneFlags.RequireYield;
      if (this.m_RequirePavement)
        flags |= SecondaryNetLaneFlags.RequirePavement;
      return flags;
    }
  }
}

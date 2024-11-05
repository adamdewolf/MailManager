// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PathfindCostInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Pathfind;
using System;

#nullable disable
namespace Game.Prefabs
{
  [Serializable]
  public struct PathfindCostInfo
  {
    public float m_Time;
    public float m_Behaviour;
    public float m_Money;
    public float m_Comfort;

    public PathfindCostInfo(float time, float behaviour, float money, float comfort)
    {
      this.m_Time = time;
      this.m_Behaviour = behaviour;
      this.m_Money = money;
      this.m_Comfort = comfort;
    }

    public PathfindCosts ToPathfindCosts()
    {
      return new PathfindCosts(this.m_Time, this.m_Behaviour, this.m_Money, this.m_Comfort);
    }
  }
}

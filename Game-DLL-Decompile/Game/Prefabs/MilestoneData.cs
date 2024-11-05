// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MilestoneData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct MilestoneData : IComponentData, IQueryTypeParameter
  {
    public int m_Index;
    public int m_Reward;
    public int m_DevTreePoints;
    public int m_MapTiles;
    public int m_LoanLimit;
    public int m_XpRequried;
    public bool m_Major;
  }
}

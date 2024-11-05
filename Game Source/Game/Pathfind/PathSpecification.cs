// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathSpecification
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Pathfind
{
  public struct PathSpecification
  {
    public PathfindCosts m_Costs;
    public EdgeFlags m_Flags;
    public PathMethod m_Methods;
    public int m_AccessRequirement;
    public float m_Length;
    public float m_MaxSpeed;
    public float m_Density;
    public RuleFlags m_Rules;
    public byte m_BlockageStart;
    public byte m_BlockageEnd;
    public byte m_FlowOffset;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.Edge
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Pathfind
{
  public struct Edge
  {
    public Entity m_Owner;
    public NodeID m_StartID;
    public NodeID m_MiddleID;
    public NodeID m_EndID;
    public float m_StartCurvePos;
    public float m_EndCurvePos;
    public PathSpecification m_Specification;
    public LocationSpecification m_Location;
  }
}

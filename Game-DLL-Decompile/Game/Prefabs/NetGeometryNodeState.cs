// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetGeometryNodeState
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct NetGeometryNodeState : IBufferElementData
  {
    public CompositionFlags m_CompositionAll;
    public CompositionFlags m_CompositionAny;
    public CompositionFlags m_CompositionNone;
    public CompositionFlags m_State;
    public NetEdgeMatchType m_MatchType;
  }
}

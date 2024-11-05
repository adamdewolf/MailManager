// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SubNet
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct SubNet : IBufferElementData
  {
    public Entity m_Prefab;
    public Bezier4x3 m_Curve;
    public int2 m_NodeIndex;
    public int2 m_ParentMesh;
    public NetInvertMode m_InvertMode;
    public CompositionFlags m_Upgrades;
    public bool2 m_Snapping;
  }
}

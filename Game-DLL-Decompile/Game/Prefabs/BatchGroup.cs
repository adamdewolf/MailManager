// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.BatchGroup
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(4)]
  public struct BatchGroup : IBufferElementData
  {
    public int m_GroupIndex;
    public int m_MergeIndex;
    public MeshLayer m_Layer;
    public MeshType m_Type;
    public ushort m_Partition;
  }
}

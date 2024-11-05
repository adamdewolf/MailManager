// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MeshMaterial
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct MeshMaterial : IBufferElementData
  {
    public int m_StartIndex;
    public int m_IndexCount;
    public int m_StartVertex;
    public int m_VertexCount;
    public int m_MaterialIndex;

    public MeshMaterial(
      int startIndex,
      int indexCount,
      int startVertex,
      int vertexCount,
      int materialIndex)
    {
      this.m_StartIndex = startIndex;
      this.m_IndexCount = indexCount;
      this.m_StartVertex = startVertex;
      this.m_VertexCount = vertexCount;
      this.m_MaterialIndex = materialIndex;
    }
  }
}

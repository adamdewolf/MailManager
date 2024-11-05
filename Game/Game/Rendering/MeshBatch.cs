// Decompiled with JetBrains decompiler
// Type: Game.Rendering.MeshBatch
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Rendering
{
  [InternalBufferCapacity(1)]
  public struct MeshBatch : IBufferElementData, IEmptySerializable
  {
    public int m_GroupIndex;
    public int m_InstanceIndex;
    public byte m_MeshGroup;
    public byte m_MeshIndex;
    public byte m_TileIndex;
  }
}

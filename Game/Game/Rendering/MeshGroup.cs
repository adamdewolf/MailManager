// Decompiled with JetBrains decompiler
// Type: Game.Rendering.MeshGroup
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Rendering
{
  [InternalBufferCapacity(1)]
  public struct MeshGroup : IBufferElementData, IEmptySerializable
  {
    public ushort m_SubMeshGroup;
    public byte m_MeshOffset;
    public byte m_ColorOffset;
  }
}

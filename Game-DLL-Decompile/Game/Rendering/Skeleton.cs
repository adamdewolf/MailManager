// Decompiled with JetBrains decompiler
// Type: Game.Rendering.Skeleton
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Rendering
{
  [InternalBufferCapacity(1)]
  public struct Skeleton : IBufferElementData, IEmptySerializable
  {
    public NativeHeapBlock m_BufferAllocation;
    public int m_BoneOffset;
    public bool m_CurrentUpdated;
    public bool m_HistoryUpdated;
    public bool m_RequireHistory;
  }
}

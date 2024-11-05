// Decompiled with JetBrains decompiler
// Type: Game.Areas.Batch
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Areas
{
  public struct Batch : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public NativeHeapBlock m_BatchAllocation;
    public int m_AllocatedSize;
    public int m_BatchIndex;
    public int m_VisibleCount;
    public int m_MetaIndex;
  }
}

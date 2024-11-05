// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MeshIndex
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;
using Unity.Entities;
using UnityEngine.Rendering;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct MeshIndex : IBufferElementData
  {
    public int m_Index;

    public MeshIndex(int index) => this.m_Index = index;

    public static void Unpack(
      NativeArray<byte> src,
      DynamicBuffer<MeshIndex> dst,
      int count,
      IndexFormat format)
    {
      dst.ResizeUninitialized(count);
      MeshIndex.Unpack(src, dst.AsNativeArray(), count, format, 0);
    }

    public static void Unpack(
      NativeArray<byte> src,
      NativeArray<MeshIndex> dst,
      int count,
      IndexFormat format,
      int vertexOffset)
    {
      if (format == IndexFormat.UInt32)
      {
        NativeArray<int> nativeArray = src.Reinterpret<int>(1);
        for (int index = 0; index < nativeArray.Length; ++index)
          dst[index] = new MeshIndex(nativeArray[index] + vertexOffset);
      }
      else
      {
        NativeArray<ushort> nativeArray = src.Reinterpret<ushort>(1);
        for (int index = 0; index < nativeArray.Length; ++index)
          dst[index] = new MeshIndex((int) nativeArray[index] + vertexOffset);
      }
    }
  }
}

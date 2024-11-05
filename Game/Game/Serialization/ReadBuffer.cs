// Decompiled with JetBrains decompiler
// Type: Game.Serialization.ReadBuffer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Collections;
using Unity.Jobs;

#nullable disable
namespace Game.Serialization
{
  public class ReadBuffer : IReadBuffer
  {
    public NativeArray<byte> buffer { get; private set; }

    public NativeReference<int> position { get; private set; }

    public ReadBuffer(int size)
    {
      this.buffer = new NativeArray<byte>(size, Allocator.TempJob);
      this.position = new NativeReference<int>(0, (AllocatorManager.AllocatorHandle) Allocator.TempJob);
    }

    public void Done(JobHandle handle)
    {
      this.buffer.Dispose(handle);
      this.position.Dispose(handle);
    }

    public void Done()
    {
      this.buffer.Dispose();
      this.position.Dispose();
    }
  }
}

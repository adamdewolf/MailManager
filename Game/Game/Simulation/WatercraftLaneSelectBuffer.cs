// Decompiled with JetBrains decompiler
// Type: Game.Simulation.WatercraftLaneSelectBuffer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Collections;

#nullable disable
namespace Game.Simulation
{
  public struct WatercraftLaneSelectBuffer
  {
    private NativeArray<float> m_Buffer;

    public NativeArray<float> Ensure()
    {
      if (!this.m_Buffer.IsCreated)
        this.m_Buffer = new NativeArray<float>(64, Allocator.Temp, NativeArrayOptions.UninitializedMemory);
      return this.m_Buffer;
    }

    public void Dispose()
    {
    }
  }
}

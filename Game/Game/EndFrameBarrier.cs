// Decompiled with JetBrains decompiler
// Type: Game.EndFrameBarrier
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Diagnostics;
using System.Runtime.CompilerServices;
using Unity.Jobs;
using UnityEngine.Scripting;

#nullable disable
namespace Game
{
  public class EndFrameBarrier : SafeCommandBufferSystem
  {
    private Stopwatch m_Stopwatch;

    public JobHandle producerHandle { get; private set; }

    public float lastElapsedTime { get; private set; }

    public float currentElapsedTime
    {
      get => (float) this.m_Stopwatch.ElapsedTicks / (float) Stopwatch.Frequency;
    }

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_Stopwatch = new Stopwatch();
    }

    [Preserve]
    protected override void OnDestroy()
    {
      this.m_Stopwatch.Stop();
      base.OnDestroy();
    }

    [Preserve]
    [MethodImpl(MethodImplOptions.NoInlining)]
    protected override void OnUpdate()
    {
      this.m_Stopwatch.Stop();
      this.lastElapsedTime = (float) this.m_Stopwatch.ElapsedTicks / (float) Stopwatch.Frequency;
      this.m_Stopwatch.Reset();
      this.producerHandle.Complete();
      this.producerHandle = new JobHandle();
      this.m_Stopwatch.Start();
      base.OnUpdate();
    }

    public new void AddJobHandleForProducer(JobHandle producerJob)
    {
      this.producerHandle = JobHandle.CombineDependencies(this.producerHandle, producerJob);
    }

    [Preserve]
    public EndFrameBarrier()
    {
    }
  }
}

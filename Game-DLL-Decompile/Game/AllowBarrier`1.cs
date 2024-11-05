// Decompiled with JetBrains decompiler
// Type: Game.AllowBarrier`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.Scripting;

#nullable disable
namespace Game
{
  public class AllowBarrier<T> : GameSystemBase where T : SafeCommandBufferSystem
  {
    private T m_Barrier;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_Barrier = this.World.GetOrCreateSystemManaged<T>();
    }

    [Preserve]
    protected override void OnUpdate() => this.m_Barrier.AllowUsage();

    [Preserve]
    public AllowBarrier()
    {
    }
  }
}

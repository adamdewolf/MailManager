// Decompiled with JetBrains decompiler
// Type: Game.Common.AllowAudioEndBarrier
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.Scripting;

#nullable disable
namespace Game.Common
{
  public class AllowAudioEndBarrier : GameSystemBase
  {
    private AudioEndBarrier m_AudioEndBarrier;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_AudioEndBarrier = this.World.GetOrCreateSystemManaged<AudioEndBarrier>();
    }

    [Preserve]
    protected override void OnUpdate() => this.m_AudioEndBarrier.AllowUsage();

    [Preserve]
    public AllowAudioEndBarrier()
    {
    }
  }
}

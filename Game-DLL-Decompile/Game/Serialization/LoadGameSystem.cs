// Decompiled with JetBrains decompiler
// Type: Game.Serialization.LoadGameSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.IO.AssetDatabase;
using Colossal.Serialization.Entities;
using System.Threading.Tasks;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Serialization
{
  public class LoadGameSystem : GameSystemBase
  {
    public LoadGameSystem.EventGameLoaded onOnSaveGameLoaded;
    private TaskCompletionSource<bool> m_TaskCompletionSource;
    private UpdateSystem m_UpdateSystem;

    public AsyncReadDescriptor dataDescriptor { get; set; }

    public Context context { get; set; }

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_UpdateSystem = this.World.GetOrCreateSystemManaged<UpdateSystem>();
      this.Enabled = false;
    }

    public async Task RunOnce()
    {
      LoadGameSystem loadGameSystem = this;
      loadGameSystem.m_TaskCompletionSource = new TaskCompletionSource<bool>();
      loadGameSystem.Enabled = true;
      int num = await loadGameSystem.m_TaskCompletionSource.Task ? 1 : 0;
    }

    [Preserve]
    protected override void OnUpdate()
    {
      this.m_UpdateSystem.Update(SystemUpdatePhase.Deserialize);
      this.Enabled = false;
      LoadGameSystem.EventGameLoaded onSaveGameLoaded = this.onOnSaveGameLoaded;
      if (onSaveGameLoaded != null)
        onSaveGameLoaded(this.context);
      this.m_TaskCompletionSource?.SetResult(true);
    }

    [Preserve]
    protected override void OnDestroy()
    {
      this.onOnSaveGameLoaded = (LoadGameSystem.EventGameLoaded) null;
      base.OnDestroy();
    }

    [Preserve]
    public LoadGameSystem()
    {
    }

    public delegate void EventGameLoaded(Context serializationContext);
  }
}

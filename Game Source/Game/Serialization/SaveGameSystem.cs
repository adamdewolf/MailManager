// Decompiled with JetBrains decompiler
// Type: Game.Serialization.SaveGameSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using System.IO;
using System.Threading.Tasks;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Serialization
{
  public class SaveGameSystem : GameSystemBase
  {
    private TaskCompletionSource<bool> m_TaskCompletionSource;
    private UpdateSystem m_UpdateSystem;
    private WriteSystem m_WriteSystem;
    private bool m_Writing;

    public Stream stream { get; set; }

    public Context context { get; set; }

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_UpdateSystem = this.World.GetOrCreateSystemManaged<UpdateSystem>();
      this.m_WriteSystem = this.World.GetOrCreateSystemManaged<WriteSystem>();
      this.Enabled = false;
    }

    public async Task RunOnce()
    {
      SaveGameSystem saveGameSystem = this;
      saveGameSystem.m_TaskCompletionSource = new TaskCompletionSource<bool>();
      saveGameSystem.Enabled = true;
      int num = await saveGameSystem.m_TaskCompletionSource.Task ? 1 : 0;
    }

    [Preserve]
    protected override void OnUpdate()
    {
      if (this.m_Writing)
      {
        if (!this.m_WriteSystem.writeDependency.IsCompleted)
          return;
        this.m_WriteSystem.writeDependency.Complete();
        this.m_Writing = false;
        this.Enabled = false;
        this.m_TaskCompletionSource?.SetResult(true);
      }
      else
      {
        this.m_Writing = true;
        this.m_UpdateSystem.Update(SystemUpdatePhase.Serialize);
      }
    }

    [Preserve]
    public SaveGameSystem()
    {
    }
  }
}

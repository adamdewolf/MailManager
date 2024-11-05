// Decompiled with JetBrains decompiler
// Type: Game.Rendering.PreRenderSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.Scripting;

#nullable disable
namespace Game.Rendering
{
  public class PreRenderSystem : GameSystemBase
  {
    private RenderingSystem m_RenderingSystem;
    private UpdateSystem m_UpdateSystem;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_RenderingSystem = this.World.GetOrCreateSystemManaged<RenderingSystem>();
      this.m_UpdateSystem = this.World.GetOrCreateSystemManaged<UpdateSystem>();
    }

    [Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated method
      this.m_RenderingSystem.PrepareRendering();
      this.m_UpdateSystem.Update(SystemUpdatePhase.PreCulling);
    }

    [Preserve]
    public PreRenderSystem()
    {
    }
  }
}

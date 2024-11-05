// Decompiled with JetBrains decompiler
// Type: Game.UI.UIUpdateSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.Scripting;

#nullable disable
namespace Game.UI
{
  public class UIUpdateSystem : GameSystemBase
  {
    private UpdateSystem m_UpdateSystem;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_UpdateSystem = this.World.GetOrCreateSystemManaged<UpdateSystem>();
    }

    [Preserve]
    protected override void OnUpdate() => this.m_UpdateSystem.Update(SystemUpdatePhase.UIUpdate);

    [Preserve]
    public UIUpdateSystem()
    {
    }
  }
}

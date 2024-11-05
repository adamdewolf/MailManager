// Decompiled with JetBrains decompiler
// Type: Game.Common.ModificationSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine.Scripting;

#nullable disable
namespace Game.Common
{
  public class ModificationSystem : GameSystemBase
  {
    private UpdateSystem m_UpdateSystem;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_UpdateSystem = this.World.GetOrCreateSystemManaged<UpdateSystem>();
    }

    [Preserve]
    protected override void OnUpdate()
    {
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification1);
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification2);
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification2B);
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification3);
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification4);
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification4B);
      this.m_UpdateSystem.Update(SystemUpdatePhase.Modification5);
      this.m_UpdateSystem.Update(SystemUpdatePhase.ModificationEnd);
    }

    [Preserve]
    public ModificationSystem()
    {
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.TutorialDeactivationSystemBase
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;
using Unity.Entities;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Tutorials
{
  public abstract class TutorialDeactivationSystemBase : GameSystemBase
  {
    private EntityQuery m_ActivePhaseQuery;
    protected EntityCommandBufferSystem m_BarrierSystem;

    protected bool phaseCanDeactivate => !this.m_ActivePhaseQuery.IsEmptyIgnoreFilter;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_BarrierSystem = (EntityCommandBufferSystem) this.World.GetOrCreateSystemManaged<ModificationBarrier3>();
      this.m_ActivePhaseQuery = this.GetEntityQuery(ComponentType.ReadOnly<TutorialPhaseData>(), ComponentType.ReadOnly<TutorialPhaseActive>(), ComponentType.ReadOnly<TutorialPhaseCanDeactivate>());
    }

    [Preserve]
    protected TutorialDeactivationSystemBase()
    {
    }
  }
}

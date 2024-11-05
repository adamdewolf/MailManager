// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.TutorialInputTriggerSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using Game.Prefabs;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

#nullable disable
namespace Game.Tutorials
{
  public class TutorialInputTriggerSystem : TutorialTriggerSystemBase
  {
    private EntityArchetype m_UnlockEventArchetype;
    private PrefabSystem m_PrefabSystem;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_ActiveTriggerQuery = this.GetEntityQuery(ComponentType.ReadOnly<InputTriggerData>(), ComponentType.ReadOnly<TriggerActive>(), ComponentType.Exclude<TriggerCompleted>());
      this.m_UnlockEventArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<Game.Common.Event>(), ComponentType.ReadWrite<Unlock>());
      this.m_PrefabSystem = this.World.GetOrCreateSystemManaged<PrefabSystem>();
      this.RequireForUpdate(this.m_ActiveTriggerQuery);
    }

    [Preserve]
    protected override void OnUpdate()
    {
      base.OnUpdate();
      NativeArray<InputTriggerData> componentDataArray = this.m_ActiveTriggerQuery.ToComponentDataArray<InputTriggerData>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      NativeArray<Entity> entityArray = this.m_ActiveTriggerQuery.ToEntityArray((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      EntityCommandBuffer commandBuffer = this.m_BarrierSystem.CreateCommandBuffer();
      for (int index = 0; index < componentDataArray.Length; ++index)
      {
        // ISSUE: reference to a compiler-generated method
        if (this.Performed(this.m_PrefabSystem.GetPrefab<TutorialInputTriggerPrefab>(entityArray[index])))
        {
          commandBuffer.AddComponent<TriggerCompleted>(entityArray[index]);
          // ISSUE: reference to a compiler-generated method
          TutorialSystem.ManualUnlock(entityArray[index], this.m_UnlockEventArchetype, this.EntityManager, commandBuffer);
        }
      }
      componentDataArray.Dispose();
      entityArray.Dispose();
    }

    private bool Performed(TutorialInputTriggerPrefab prefab)
    {
      for (int index = 0; index < prefab.m_Actions.Length; ++index)
      {
        if (InputManager.instance.FindAction(prefab.m_Actions[index].m_Map, prefab.m_Actions[index].m_Action).WasPerformedThisFrame())
          return true;
      }
      return false;
    }

    [Preserve]
    public TutorialInputTriggerSystem()
    {
    }
  }
}

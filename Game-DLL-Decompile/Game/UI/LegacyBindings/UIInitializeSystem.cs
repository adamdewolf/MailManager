// Decompiled with JetBrains decompiler
// Type: Game.UI.LegacyBindings.UIInitializeSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Entities;
using Game.Prefabs;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using Unity.Entities;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.LegacyBindings
{
  [CompilerGenerated]
  public class UIInitializeSystem : GameSystemBase
  {
    private PrefabSystem m_PrefabSystem;
    private EntityQuery m_AssetQuery;
    private EntityQuery m_PolicyQuery;
    private UIInitializeSystem.TypeHandle __TypeHandle;

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_AssetQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[2]
        {
          ComponentType.ReadOnly<PrefabData>(),
          ComponentType.ReadOnly<ServiceObjectData>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.m_PolicyQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[2]
        {
          ComponentType.ReadOnly<PrefabData>(),
          ComponentType.ReadOnly<PolicyData>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.m_PrefabSystem = World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<PrefabSystem>();
    }

    [Preserve]
    protected override void OnUpdate()
    {
    }

    public IEnumerable<UIInitializeSystem.AssetInfo> assets
    {
      get
      {
        UIInitializeSystem initializeSystem = this;
        if (!initializeSystem.m_AssetQuery.IsEmptyIgnoreFilter)
        {
          initializeSystem.__TypeHandle.__Game_Prefabs_Locked_RO_ComponentLookup.Update(ref initializeSystem.CheckedStateRef);
          ComponentLookup<Locked> locked = initializeSystem.__TypeHandle.__Game_Prefabs_Locked_RO_ComponentLookup;
          NativeArray<PrefabData> prefabs = initializeSystem.m_AssetQuery.ToComponentDataArray<PrefabData>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
          NativeArray<Entity> entities = initializeSystem.m_AssetQuery.ToEntityArray((AllocatorManager.AllocatorHandle) Allocator.TempJob);
          for (int i = 0; i < entities.Length; ++i)
            yield return new UIInitializeSystem.AssetInfo(initializeSystem.m_PrefabSystem.GetPrefab<PrefabBase>(prefabs[i]), locked.HasEnabledComponent<Locked>(entities[i]));
          prefabs.Dispose();
          entities.Dispose();
          locked = new ComponentLookup<Locked>();
          prefabs = new NativeArray<PrefabData>();
          entities = new NativeArray<Entity>();
        }
      }
    }

    public IEnumerable<PolicyPrefab> policies
    {
      get
      {
        if (!this.m_PolicyQuery.IsEmptyIgnoreFilter)
        {
          NativeArray<PrefabData> prefabs = this.m_PolicyQuery.ToComponentDataArray<PrefabData>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
          for (int i = 0; i < prefabs.Length; ++i)
            yield return this.m_PrefabSystem.GetPrefab<PolicyPrefab>(prefabs[i]);
          prefabs.Dispose();
          prefabs = new NativeArray<PrefabData>();
        }
      }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private void __AssignQueries(ref SystemState state)
    {
    }

    protected override void OnCreateForCompiler()
    {
      base.OnCreateForCompiler();
      // ISSUE: reference to a compiler-generated method
      this.__AssignQueries(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.__TypeHandle.__AssignHandles(ref this.CheckedStateRef);
    }

    [Preserve]
    public UIInitializeSystem()
    {
    }

    public readonly struct AssetInfo
    {
      public readonly PrefabBase asset;
      public readonly bool locked;

      public AssetInfo(PrefabBase asset, bool locked)
      {
        // ISSUE: reference to a compiler-generated field
        this.asset = asset;
        // ISSUE: reference to a compiler-generated field
        this.locked = locked;
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public ComponentLookup<Locked> __Game_Prefabs_Locked_RO_ComponentLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_Locked_RO_ComponentLookup = state.GetComponentLookup<Locked>(true);
      }
    }
  }
}

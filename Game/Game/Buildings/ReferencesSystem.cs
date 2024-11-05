// Decompiled with JetBrains decompiler
// Type: Game.Buildings.ReferencesSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Game.Areas;
using Game.Common;
using Game.Objects;
using Game.Tools;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;

#nullable disable
namespace Game.Buildings
{
  [CompilerGenerated]
  public class ReferencesSystem : GameSystemBase
  {
    private EntityQuery m_SpawnLocationQuery;
    private ReferencesSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_SpawnLocationQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[2]
        {
          ComponentType.ReadOnly<SpawnLocation>(),
          ComponentType.ReadOnly<Owner>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Created>(),
          ComponentType.ReadOnly<Deleted>()
        },
        None = new ComponentType[0]
      }, new EntityQueryDesc()
      {
        All = new ComponentType[2]
        {
          ComponentType.ReadOnly<HangaroundLocation>(),
          ComponentType.ReadOnly<Owner>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Created>(),
          ComponentType.ReadOnly<Deleted>()
        },
        None = new ComponentType[0]
      });
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_SpawnLocationQuery);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_SpawnLocationElement_RW_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Tools_Temp_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Tools_Temp_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Created_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      ReferencesSystem.UpdateBuildingReferencesJob jobData = new ReferencesSystem.UpdateBuildingReferencesJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_OwnerType = this.__TypeHandle.__Game_Common_Owner_RO_ComponentTypeHandle,
        m_CreatedType = this.__TypeHandle.__Game_Common_Created_RO_ComponentTypeHandle,
        m_TempType = this.__TypeHandle.__Game_Tools_Temp_RO_ComponentTypeHandle,
        m_TempData = this.__TypeHandle.__Game_Tools_Temp_RO_ComponentLookup,
        m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
        m_SpawnLocations = this.__TypeHandle.__Game_Buildings_SpawnLocationElement_RW_BufferLookup
      };
      // ISSUE: reference to a compiler-generated field
      this.Dependency = jobData.Schedule<ReferencesSystem.UpdateBuildingReferencesJob>(this.m_SpawnLocationQuery, this.Dependency);
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

    [UnityEngine.Scripting.Preserve]
    public ReferencesSystem()
    {
    }

    [BurstCompile]
    private struct UpdateBuildingReferencesJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<Owner> m_OwnerType;
      [ReadOnly]
      public ComponentTypeHandle<Created> m_CreatedType;
      [ReadOnly]
      public ComponentTypeHandle<Temp> m_TempType;
      [ReadOnly]
      public ComponentLookup<Temp> m_TempData;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      public BufferLookup<SpawnLocationElement> m_SpawnLocations;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Owner> nativeArray2 = chunk.GetNativeArray<Owner>(ref this.m_OwnerType);
        // ISSUE: reference to a compiler-generated field
        if (chunk.Has<Created>(ref this.m_CreatedType))
        {
          // ISSUE: reference to a compiler-generated field
          if (chunk.Has<Temp>(ref this.m_TempType))
          {
            for (int index = 0; index < nativeArray2.Length; ++index)
            {
              Entity spawnLocation = nativeArray1[index];
              Owner owner = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              if (!this.m_TempData.HasComponent(owner.m_Owner))
              {
                // ISSUE: reference to a compiler-generated field
                if (this.m_SpawnLocations.HasBuffer(owner.m_Owner))
                {
                  // ISSUE: reference to a compiler-generated field
                  CollectionUtils.TryAddUniqueValue<SpawnLocationElement>(this.m_SpawnLocations[owner.m_Owner], new SpawnLocationElement(spawnLocation));
                }
                // ISSUE: reference to a compiler-generated field
                while (this.m_OwnerData.HasComponent(owner.m_Owner))
                {
                  // ISSUE: reference to a compiler-generated field
                  owner = this.m_OwnerData[owner.m_Owner];
                  // ISSUE: reference to a compiler-generated field
                  if (!this.m_TempData.HasComponent(owner.m_Owner))
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (this.m_SpawnLocations.HasBuffer(owner.m_Owner))
                    {
                      // ISSUE: reference to a compiler-generated field
                      CollectionUtils.TryAddUniqueValue<SpawnLocationElement>(this.m_SpawnLocations[owner.m_Owner], new SpawnLocationElement(spawnLocation));
                    }
                  }
                  else
                    break;
                }
              }
            }
          }
          else
          {
            for (int index = 0; index < nativeArray2.Length; ++index)
            {
              Entity spawnLocation = nativeArray1[index];
              Owner owner = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              if (this.m_SpawnLocations.HasBuffer(owner.m_Owner))
              {
                // ISSUE: reference to a compiler-generated field
                CollectionUtils.TryAddUniqueValue<SpawnLocationElement>(this.m_SpawnLocations[owner.m_Owner], new SpawnLocationElement(spawnLocation));
              }
              // ISSUE: reference to a compiler-generated field
              while (this.m_OwnerData.HasComponent(owner.m_Owner))
              {
                // ISSUE: reference to a compiler-generated field
                owner = this.m_OwnerData[owner.m_Owner];
                // ISSUE: reference to a compiler-generated field
                if (this.m_SpawnLocations.HasBuffer(owner.m_Owner))
                {
                  // ISSUE: reference to a compiler-generated field
                  CollectionUtils.TryAddUniqueValue<SpawnLocationElement>(this.m_SpawnLocations[owner.m_Owner], new SpawnLocationElement(spawnLocation));
                }
              }
            }
          }
        }
        else
        {
          for (int index = 0; index < nativeArray2.Length; ++index)
          {
            Entity spawnLocation = nativeArray1[index];
            Owner owner = nativeArray2[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_SpawnLocations.HasBuffer(owner.m_Owner))
            {
              // ISSUE: reference to a compiler-generated field
              CollectionUtils.RemoveValue<SpawnLocationElement>(this.m_SpawnLocations[owner.m_Owner], new SpawnLocationElement(spawnLocation));
            }
            // ISSUE: reference to a compiler-generated field
            while (this.m_OwnerData.HasComponent(owner.m_Owner))
            {
              // ISSUE: reference to a compiler-generated field
              owner = this.m_OwnerData[owner.m_Owner];
              // ISSUE: reference to a compiler-generated field
              if (this.m_SpawnLocations.HasBuffer(owner.m_Owner))
              {
                // ISSUE: reference to a compiler-generated field
                CollectionUtils.RemoveValue<SpawnLocationElement>(this.m_SpawnLocations[owner.m_Owner], new SpawnLocationElement(spawnLocation));
              }
            }
          }
        }
      }

      void IJobChunk.Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated method
        this.Execute(in chunk, unfilteredChunkIndex, useEnabledMask, in chunkEnabledMask);
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Owner> __Game_Common_Owner_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Created> __Game_Common_Created_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Temp> __Game_Tools_Temp_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentLookup<Temp> __Game_Tools_Temp_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Owner> __Game_Common_Owner_RO_ComponentLookup;
      public BufferLookup<SpawnLocationElement> __Game_Buildings_SpawnLocationElement_RW_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Created_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Created>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Tools_Temp_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Temp>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Tools_Temp_RO_ComponentLookup = state.GetComponentLookup<Temp>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentLookup = state.GetComponentLookup<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_SpawnLocationElement_RW_BufferLookup = state.GetBufferLookup<SpawnLocationElement>();
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Simulation.VehicleSpawnSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;
using Game.Objects;
using Game.Tools;
using Game.Vehicles;
using System;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  [CompilerGenerated]
  public class VehicleSpawnSystem : GameSystemBase
  {
    private EndFrameBarrier m_EndFrameBarrier;
    private EntityQuery m_VehicleQuery;
    private VehicleSpawnSystem.TypeHandle __TypeHandle;

    public override int GetUpdateInterval(SystemUpdatePhase phase) => 16;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier = this.World.GetOrCreateSystemManaged<EndFrameBarrier>();
      // ISSUE: reference to a compiler-generated field
      this.m_VehicleQuery = this.GetEntityQuery(ComponentType.ReadWrite<TripSource>(), ComponentType.ReadOnly<Vehicle>(), ComponentType.Exclude<Deleted>(), ComponentType.Exclude<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_VehicleQuery);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      NativeList<VehicleSpawnSystem.SpawnData> nativeList1 = new NativeList<VehicleSpawnSystem.SpawnData>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      NativeList<VehicleSpawnSystem.SpawnRange> nativeList2 = new NativeList<VehicleSpawnSystem.SpawnRange>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      JobHandle outJobHandle;
      // ISSUE: reference to a compiler-generated field
      NativeList<ArchetypeChunk> archetypeChunkListAsync = this.m_VehicleQuery.ToArchetypeChunkListAsync((AllocatorManager.AllocatorHandle) Allocator.TempJob, out outJobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_TripSource_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_Controller_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleSpawnSystem.GroupSpawnSourcesJob jobData1 = new VehicleSpawnSystem.GroupSpawnSourcesJob()
      {
        m_Chunks = archetypeChunkListAsync,
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_ControllerType = this.__TypeHandle.__Game_Vehicles_Controller_RO_ComponentTypeHandle,
        m_SpawnSourceType = this.__TypeHandle.__Game_Objects_TripSource_RW_ComponentTypeHandle,
        m_SpawnData = nativeList1,
        m_SpawnGroups = nativeList2
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_LayoutElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      VehicleSpawnSystem.TrySpawnVehiclesJob jobData2 = new VehicleSpawnSystem.TrySpawnVehiclesJob()
      {
        m_SpawnData = nativeList1.AsDeferredJobArray(),
        m_SpawnGroups = nativeList2.AsDeferredJobArray(),
        m_Layouts = this.__TypeHandle.__Game_Vehicles_LayoutElement_RO_BufferLookup,
        m_CommandBuffer = this.m_EndFrameBarrier.CreateCommandBuffer().AsParallelWriter()
      };
      JobHandle jobHandle1 = jobData1.Schedule<VehicleSpawnSystem.GroupSpawnSourcesJob>(JobHandle.CombineDependencies(this.Dependency, outJobHandle));
      NativeList<VehicleSpawnSystem.SpawnRange> list = nativeList2;
      JobHandle dependsOn = jobHandle1;
      JobHandle jobHandle2 = jobData2.Schedule<VehicleSpawnSystem.TrySpawnVehiclesJob, VehicleSpawnSystem.SpawnRange>(list, 1, dependsOn);
      nativeList1.Dispose(jobHandle2);
      nativeList2.Dispose(jobHandle2);
      archetypeChunkListAsync.Dispose(jobHandle2);
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier.AddJobHandleForProducer(jobHandle2);
      this.Dependency = jobHandle2;
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
    public VehicleSpawnSystem()
    {
    }

    private struct SpawnData : IComparable<VehicleSpawnSystem.SpawnData>
    {
      public Entity m_Source;
      public Entity m_Vehicle;
      public int m_Priority;

      public int CompareTo(VehicleSpawnSystem.SpawnData other)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        return math.select(this.m_Priority - other.m_Priority, this.m_Source.Index - other.m_Source.Index, this.m_Source.Index != other.m_Source.Index);
      }
    }

    private struct SpawnRange
    {
      public int m_Start;
      public int m_End;
    }

    [BurstCompile]
    private struct GroupSpawnSourcesJob : IJob
    {
      [ReadOnly]
      public NativeList<ArchetypeChunk> m_Chunks;
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<Controller> m_ControllerType;
      public ComponentTypeHandle<TripSource> m_SpawnSourceType;
      public NativeList<VehicleSpawnSystem.SpawnData> m_SpawnData;
      public NativeList<VehicleSpawnSystem.SpawnRange> m_SpawnGroups;

      public void Execute()
      {
        // ISSUE: reference to a compiler-generated field
        for (int index1 = 0; index1 < this.m_Chunks.Length; ++index1)
        {
          // ISSUE: reference to a compiler-generated field
          ArchetypeChunk chunk = this.m_Chunks[index1];
          // ISSUE: reference to a compiler-generated field
          NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<TripSource> nativeArray2 = chunk.GetNativeArray<TripSource>(ref this.m_SpawnSourceType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<Controller> nativeArray3 = chunk.GetNativeArray<Controller>(ref this.m_ControllerType);
          if (nativeArray3.Length != 0)
          {
            for (int index2 = 0; index2 < nativeArray1.Length; ++index2)
            {
              // ISSUE: variable of a compiler-generated type
              VehicleSpawnSystem.SpawnData spawnData;
              // ISSUE: reference to a compiler-generated field
              spawnData.m_Vehicle = nativeArray1[index2];
              Controller controller = nativeArray3[index2];
              // ISSUE: reference to a compiler-generated field
              if (!(controller.m_Controller != Entity.Null) || !(controller.m_Controller != spawnData.m_Vehicle))
              {
                TripSource tripSource = nativeArray2[index2];
                if (tripSource.m_Timer <= 0)
                {
                  // ISSUE: reference to a compiler-generated field
                  spawnData.m_Source = nativeArray2[index2].m_Source;
                  // ISSUE: reference to a compiler-generated field
                  spawnData.m_Priority = tripSource.m_Timer;
                  // ISSUE: reference to a compiler-generated field
                  this.m_SpawnData.Add(in spawnData);
                }
                tripSource.m_Timer -= 16;
                nativeArray2[index2] = tripSource;
              }
            }
          }
          else
          {
            for (int index3 = 0; index3 < nativeArray1.Length; ++index3)
            {
              TripSource tripSource = nativeArray2[index3];
              if (tripSource.m_Timer <= 0)
              {
                // ISSUE: variable of a compiler-generated type
                VehicleSpawnSystem.SpawnData spawnData;
                // ISSUE: reference to a compiler-generated field
                spawnData.m_Source = nativeArray2[index3].m_Source;
                // ISSUE: reference to a compiler-generated field
                spawnData.m_Vehicle = nativeArray1[index3];
                // ISSUE: reference to a compiler-generated field
                spawnData.m_Priority = tripSource.m_Timer;
                // ISSUE: reference to a compiler-generated field
                this.m_SpawnData.Add(in spawnData);
              }
              tripSource.m_Timer -= 16;
              nativeArray2[index3] = tripSource;
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        this.m_SpawnData.Sort<VehicleSpawnSystem.SpawnData>();
        // ISSUE: variable of a compiler-generated type
        VehicleSpawnSystem.SpawnRange spawnRange;
        // ISSUE: reference to a compiler-generated field
        spawnRange.m_Start = -1;
        Entity entity = Entity.Null;
        // ISSUE: reference to a compiler-generated field
        for (int index = 0; index < this.m_SpawnData.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity source = this.m_SpawnData[index].m_Source;
          if (source != entity)
          {
            // ISSUE: reference to a compiler-generated field
            if (spawnRange.m_Start != -1)
            {
              // ISSUE: reference to a compiler-generated field
              spawnRange.m_End = index;
              // ISSUE: reference to a compiler-generated field
              this.m_SpawnGroups.Add(in spawnRange);
            }
            // ISSUE: reference to a compiler-generated field
            spawnRange.m_Start = index;
            entity = source;
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (spawnRange.m_Start == -1)
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        spawnRange.m_End = this.m_SpawnData.Length;
        // ISSUE: reference to a compiler-generated field
        this.m_SpawnGroups.Add(in spawnRange);
      }
    }

    private struct LaneBufferItem
    {
      public Entity m_Lane;
      public float2 m_Delta;

      public LaneBufferItem(Entity lane, float2 delta)
      {
        // ISSUE: reference to a compiler-generated field
        this.m_Lane = lane;
        // ISSUE: reference to a compiler-generated field
        this.m_Delta = delta;
      }
    }

    [BurstCompile]
    private struct TrySpawnVehiclesJob : IJobParallelForDefer
    {
      [ReadOnly]
      public NativeArray<VehicleSpawnSystem.SpawnData> m_SpawnData;
      [ReadOnly]
      public NativeArray<VehicleSpawnSystem.SpawnRange> m_SpawnGroups;
      [ReadOnly]
      public BufferLookup<LayoutElement> m_Layouts;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;

      public void Execute(int index)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: variable of a compiler-generated type
        VehicleSpawnSystem.SpawnRange spawnGroup = this.m_SpawnGroups[index];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: variable of a compiler-generated type
        VehicleSpawnSystem.SpawnData spawnData = this.m_SpawnData[spawnGroup.m_Start];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        for (int start = spawnGroup.m_Start; start < spawnGroup.m_End; ++start)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity vehicle1 = this.m_SpawnData[start].m_Vehicle;
          // ISSUE: reference to a compiler-generated field
          if (this.m_Layouts.HasBuffer(vehicle1))
          {
            // ISSUE: reference to a compiler-generated field
            DynamicBuffer<LayoutElement> layout = this.m_Layouts[vehicle1];
            if (layout.Length != 0)
            {
              for (int index1 = 0; index1 < layout.Length; ++index1)
              {
                Entity vehicle2 = layout[index1].m_Vehicle;
                // ISSUE: reference to a compiler-generated field
                this.m_CommandBuffer.RemoveComponent<TripSource>(index, vehicle2);
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.RemoveComponent<TripSource>(index, vehicle1);
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            this.m_CommandBuffer.RemoveComponent<TripSource>(index, vehicle1);
          }
        }
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Controller> __Game_Vehicles_Controller_RO_ComponentTypeHandle;
      public ComponentTypeHandle<TripSource> __Game_Objects_TripSource_RW_ComponentTypeHandle;
      [ReadOnly]
      public BufferLookup<LayoutElement> __Game_Vehicles_LayoutElement_RO_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Controller_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Controller>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_TripSource_RW_ComponentTypeHandle = state.GetComponentTypeHandle<TripSource>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_LayoutElement_RO_BufferLookup = state.GetBufferLookup<LayoutElement>(true);
      }
    }
  }
}

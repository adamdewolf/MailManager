// Decompiled with JetBrains decompiler
// Type: Game.Simulation.RemovedSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Buildings;
using Game.Citizens;
using Game.Common;
using Game.Companies;
using Game.Notifications;
using Game.Prefabs;
using Game.Tools;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

#nullable disable
namespace Game.Simulation
{
  [CompilerGenerated]
  public class RemovedSystem : GameSystemBase
  {
    private EntityQuery m_DeletedBuildings;
    private EntityQuery m_DeletedWorkplaces;
    private EntityQuery m_DeletedCompanies;
    private EntityQuery m_NeedUpdateRenterQuery;
    private EntityQuery m_BuildingParameterQuery;
    private EntityQuery m_CompanyNotificationParameterQuery;
    private IconCommandSystem m_IconCommandSystem;
    private ModificationBarrier5 m_ModificationBarrier;
    private RemovedSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_ModificationBarrier = this.World.GetOrCreateSystemManaged<ModificationBarrier5>();
      // ISSUE: reference to a compiler-generated field
      this.m_IconCommandSystem = this.World.GetOrCreateSystemManaged<IconCommandSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_DeletedBuildings = this.GetEntityQuery(ComponentType.ReadOnly<Renter>(), ComponentType.ReadOnly<Deleted>(), ComponentType.Exclude<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.m_DeletedWorkplaces = this.GetEntityQuery(ComponentType.ReadOnly<Employee>(), ComponentType.ReadOnly<Deleted>(), ComponentType.Exclude<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.m_DeletedCompanies = this.GetEntityQuery(ComponentType.ReadOnly<CompanyNotifications>(), ComponentType.ReadOnly<Deleted>(), ComponentType.Exclude<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.m_NeedUpdateRenterQuery = this.GetEntityQuery(ComponentType.ReadOnly<Game.Common.Event>(), ComponentType.ReadOnly<RentersUpdated>());
      // ISSUE: reference to a compiler-generated field
      this.m_BuildingParameterQuery = this.GetEntityQuery(ComponentType.ReadOnly<BuildingConfigurationData>());
      // ISSUE: reference to a compiler-generated field
      this.m_CompanyNotificationParameterQuery = this.GetEntityQuery(ComponentType.ReadOnly<CompanyNotificationParameterData>());
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      JobHandle jobHandle1 = new JobHandle();
      EntityCommandBuffer commandBuffer;
      // ISSUE: reference to a compiler-generated field
      if (!this.m_DeletedBuildings.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_Renter_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        RemovedSystem.RemovedPropertyJob jobData = new RemovedSystem.RemovedPropertyJob();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_RenterType = this.__TypeHandle.__Game_Buildings_Renter_RO_BufferTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_PropertyRenters = this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentLookup;
        ref RemovedSystem.RemovedPropertyJob local = ref jobData;
        // ISSUE: reference to a compiler-generated field
        commandBuffer = this.m_ModificationBarrier.CreateCommandBuffer();
        EntityCommandBuffer.ParallelWriter parallelWriter = commandBuffer.AsParallelWriter();
        // ISSUE: reference to a compiler-generated field
        local.m_CommandBuffer = parallelWriter;
        // ISSUE: reference to a compiler-generated field
        jobHandle1 = jobData.ScheduleParallel<RemovedSystem.RemovedPropertyJob>(this.m_DeletedBuildings, this.Dependency);
        // ISSUE: reference to a compiler-generated field
        this.m_ModificationBarrier.AddJobHandleForProducer(jobHandle1);
      }
      JobHandle jobHandle2 = new JobHandle();
      // ISSUE: reference to a compiler-generated field
      if (!this.m_DeletedWorkplaces.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Citizens_Worker_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Citizens_TravelPurpose_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Companies_Employee_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        RemovedSystem.RemovedWorkplaceJob jobData = new RemovedSystem.RemovedWorkplaceJob();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_EmployeeType = this.__TypeHandle.__Game_Companies_Employee_RO_BufferTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_Purposes = this.__TypeHandle.__Game_Citizens_TravelPurpose_RO_ComponentLookup;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        jobData.m_Workers = this.__TypeHandle.__Game_Citizens_Worker_RO_ComponentLookup;
        ref RemovedSystem.RemovedWorkplaceJob local = ref jobData;
        // ISSUE: reference to a compiler-generated field
        commandBuffer = this.m_ModificationBarrier.CreateCommandBuffer();
        EntityCommandBuffer.ParallelWriter parallelWriter = commandBuffer.AsParallelWriter();
        // ISSUE: reference to a compiler-generated field
        local.m_CommandBuffer = parallelWriter;
        // ISSUE: reference to a compiler-generated field
        jobHandle2 = jobData.ScheduleParallel<RemovedSystem.RemovedWorkplaceJob>(this.m_DeletedWorkplaces, this.Dependency);
        // ISSUE: reference to a compiler-generated field
        this.m_ModificationBarrier.AddJobHandleForProducer(jobHandle2);
      }
      JobHandle jobHandle3 = new JobHandle();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (!this.m_DeletedCompanies.IsEmptyIgnoreFilter && !this.m_CompanyNotificationParameterQuery.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Companies_CompanyNotifications_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated field
        jobHandle3 = new RemovedSystem.RemovedCompanyJob()
        {
          m_NotificationsType = this.__TypeHandle.__Game_Companies_CompanyNotifications_RO_ComponentTypeHandle,
          m_CompanyNotificationParameters = this.m_CompanyNotificationParameterQuery.GetSingleton<CompanyNotificationParameterData>(),
          m_IconCommandBuffer = this.m_IconCommandSystem.CreateCommandBuffer()
        }.ScheduleParallel<RemovedSystem.RemovedCompanyJob>(this.m_DeletedCompanies, this.Dependency);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_IconCommandSystem.AddCommandBufferWriter(jobHandle3);
      }
      JobHandle jobHandle4 = new JobHandle();
      // ISSUE: reference to a compiler-generated field
      if (!this.m_NeedUpdateRenterQuery.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_Building_RW_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_Renter_RW_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_RentersUpdated_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
        // ISSUE: reference to a compiler-generated method
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated field
        jobHandle4 = new RemovedSystem.RentersUpdateJob()
        {
          m_RentersUpdatedType = this.__TypeHandle.__Game_Buildings_RentersUpdated_RW_ComponentTypeHandle,
          m_Renters = this.__TypeHandle.__Game_Buildings_Renter_RW_BufferLookup,
          m_PropertyRenters = this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentLookup,
          m_Buildings = this.__TypeHandle.__Game_Buildings_Building_RW_ComponentLookup,
          m_BuildingConfigurationData = this.m_BuildingParameterQuery.GetSingleton<BuildingConfigurationData>(),
          m_IconCommandBuffer = this.m_IconCommandSystem.CreateCommandBuffer()
        }.Schedule<RemovedSystem.RentersUpdateJob>(this.m_NeedUpdateRenterQuery, JobHandle.CombineDependencies(this.Dependency, jobHandle1));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_IconCommandSystem.AddCommandBufferWriter(jobHandle4);
      }
      this.Dependency = JobHandle.CombineDependencies(jobHandle1, jobHandle2, JobHandle.CombineDependencies(jobHandle3, jobHandle4));
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
    public RemovedSystem()
    {
    }

    [BurstCompile]
    private struct RemovedPropertyJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public BufferTypeHandle<Renter> m_RenterType;
      [ReadOnly]
      public ComponentLookup<PropertyRenter> m_PropertyRenters;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Renter> bufferAccessor = chunk.GetBufferAccessor<Renter>(ref this.m_RenterType);
        for (int index1 = 0; index1 < bufferAccessor.Length; ++index1)
        {
          DynamicBuffer<Renter> dynamicBuffer = bufferAccessor[index1];
          for (int index2 = 0; index2 < dynamicBuffer.Length; ++index2)
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_PropertyRenters.HasComponent(dynamicBuffer[index2].m_Renter))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.RemoveComponent<PropertyRenter>(unfilteredChunkIndex, dynamicBuffer[index2].m_Renter);
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

    [BurstCompile]
    private struct RemovedWorkplaceJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public BufferTypeHandle<Employee> m_EmployeeType;
      [ReadOnly]
      public ComponentLookup<TravelPurpose> m_Purposes;
      [ReadOnly]
      public ComponentLookup<Worker> m_Workers;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray = chunk.GetNativeArray(this.m_EntityType);
        for (int index = 0; index < nativeArray.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.RemoveComponent<FreeWorkplaces>(unfilteredChunkIndex, nativeArray[index]);
        }
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Employee> bufferAccessor = chunk.GetBufferAccessor<Employee>(ref this.m_EmployeeType);
        for (int index1 = 0; index1 < bufferAccessor.Length; ++index1)
        {
          DynamicBuffer<Employee> dynamicBuffer = bufferAccessor[index1];
          for (int index2 = 0; index2 < dynamicBuffer.Length; ++index2)
          {
            Entity worker = dynamicBuffer[index2].m_Worker;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_Purposes.HasComponent(worker) && (this.m_Purposes[worker].m_Purpose == Game.Citizens.Purpose.GoingToWork || this.m_Purposes[worker].m_Purpose == Game.Citizens.Purpose.Working))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.RemoveComponent<TravelPurpose>(unfilteredChunkIndex, worker);
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_Workers.HasComponent(worker))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.RemoveComponent<Worker>(unfilteredChunkIndex, worker);
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

    [BurstCompile]
    private struct RemovedCompanyJob : IJobChunk
    {
      [ReadOnly]
      public ComponentTypeHandle<CompanyNotifications> m_NotificationsType;
      public IconCommandBuffer m_IconCommandBuffer;
      public CompanyNotificationParameterData m_CompanyNotificationParameters;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<CompanyNotifications> nativeArray = chunk.GetNativeArray<CompanyNotifications>(ref this.m_NotificationsType);
        for (int index = 0; index < nativeArray.Length; ++index)
        {
          CompanyNotifications companyNotifications = nativeArray[index];
          if (companyNotifications.m_NoCustomersEntity != new Entity())
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_IconCommandBuffer.Remove(companyNotifications.m_NoCustomersEntity, this.m_CompanyNotificationParameters.m_NoCustomersNotificationPrefab);
          }
          if (companyNotifications.m_NoInputEntity != new Entity())
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_IconCommandBuffer.Remove(companyNotifications.m_NoInputEntity, this.m_CompanyNotificationParameters.m_NoInputsNotificationPrefab);
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

    [BurstCompile]
    private struct RentersUpdateJob : IJobChunk
    {
      [ReadOnly]
      public ComponentTypeHandle<RentersUpdated> m_RentersUpdatedType;
      public BufferLookup<Renter> m_Renters;
      [ReadOnly]
      public ComponentLookup<PropertyRenter> m_PropertyRenters;
      public ComponentLookup<Building> m_Buildings;
      [ReadOnly]
      public BuildingConfigurationData m_BuildingConfigurationData;
      public IconCommandBuffer m_IconCommandBuffer;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<RentersUpdated> nativeArray = chunk.GetNativeArray<RentersUpdated>(ref this.m_RentersUpdatedType);
        for (int index1 = 0; index1 < chunk.Count; ++index1)
        {
          RentersUpdated rentersUpdated = nativeArray[index1];
          Building componentData;
          DynamicBuffer<Renter> bufferData;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_Buildings.TryGetComponent(rentersUpdated.m_Property, out componentData) && this.m_Renters.TryGetBuffer(rentersUpdated.m_Property, out bufferData))
          {
            for (int index2 = bufferData.Length - 1; index2 >= 0; --index2)
            {
              // ISSUE: reference to a compiler-generated field
              if (!this.m_PropertyRenters.HasComponent(bufferData[index2].m_Renter))
                bufferData.RemoveAt(index2);
            }
            if ((componentData.m_Flags & Game.Buildings.BuildingFlags.HighRentWarning) != Game.Buildings.BuildingFlags.None && bufferData.Length == 0)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_IconCommandBuffer.Remove(rentersUpdated.m_Property, this.m_BuildingConfigurationData.m_HighRentNotification);
              componentData.m_Flags &= ~Game.Buildings.BuildingFlags.HighRentWarning;
              // ISSUE: reference to a compiler-generated field
              this.m_Buildings[rentersUpdated.m_Property] = componentData;
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
      public BufferTypeHandle<Renter> __Game_Buildings_Renter_RO_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<PropertyRenter> __Game_Buildings_PropertyRenter_RO_ComponentLookup;
      [ReadOnly]
      public BufferTypeHandle<Employee> __Game_Companies_Employee_RO_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<TravelPurpose> __Game_Citizens_TravelPurpose_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Worker> __Game_Citizens_Worker_RO_ComponentLookup;
      [ReadOnly]
      public ComponentTypeHandle<CompanyNotifications> __Game_Companies_CompanyNotifications_RO_ComponentTypeHandle;
      public ComponentTypeHandle<RentersUpdated> __Game_Buildings_RentersUpdated_RW_ComponentTypeHandle;
      public BufferLookup<Renter> __Game_Buildings_Renter_RW_BufferLookup;
      public ComponentLookup<Building> __Game_Buildings_Building_RW_ComponentLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Renter_RO_BufferTypeHandle = state.GetBufferTypeHandle<Renter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_PropertyRenter_RO_ComponentLookup = state.GetComponentLookup<PropertyRenter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Companies_Employee_RO_BufferTypeHandle = state.GetBufferTypeHandle<Employee>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_TravelPurpose_RO_ComponentLookup = state.GetComponentLookup<TravelPurpose>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Worker_RO_ComponentLookup = state.GetComponentLookup<Worker>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Companies_CompanyNotifications_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CompanyNotifications>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_RentersUpdated_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RentersUpdated>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Renter_RW_BufferLookup = state.GetBufferLookup<Renter>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Building_RW_ComponentLookup = state.GetComponentLookup<Building>();
      }
    }
  }
}

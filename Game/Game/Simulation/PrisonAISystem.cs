﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.PrisonAISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Buildings;
using Game.City;
using Game.Common;
using Game.Economy;
using Game.Objects;
using Game.Pathfind;
using Game.Prefabs;
using Game.Tools;
using Game.Vehicles;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine.Assertions;

#nullable disable
namespace Game.Simulation
{
  [CompilerGenerated]
  public class PrisonAISystem : GameSystemBase
  {
    private EntityQuery m_BuildingQuery;
    private EntityQuery m_VehiclePrefabQuery;
    private EntityArchetype m_PrisonerTransportRequestArchetype;
    private EntityArchetype m_HandleRequestArchetype;
    private EndFrameBarrier m_EndFrameBarrier;
    private CityConfigurationSystem m_CityConfigurationSystem;
    private TransportVehicleSelectData m_TransportVehicleSelectData;
    private PrisonAISystem.TypeHandle __TypeHandle;

    public override int GetUpdateInterval(SystemUpdatePhase phase) => 256;

    public override int GetUpdateOffset(SystemUpdatePhase phase) => 48;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier = this.World.GetOrCreateSystemManaged<EndFrameBarrier>();
      // ISSUE: reference to a compiler-generated field
      this.m_CityConfigurationSystem = this.World.GetOrCreateSystemManaged<CityConfigurationSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_TransportVehicleSelectData = new TransportVehicleSelectData((SystemBase) this);
      // ISSUE: reference to a compiler-generated field
      this.m_BuildingQuery = this.GetEntityQuery(ComponentType.ReadOnly<Game.Buildings.Prison>(), ComponentType.ReadOnly<ServiceDispatch>(), ComponentType.ReadOnly<PrefabRef>(), ComponentType.Exclude<Temp>(), ComponentType.Exclude<Deleted>());
      // ISSUE: reference to a compiler-generated field
      this.m_VehiclePrefabQuery = this.GetEntityQuery(TransportVehicleSelectData.GetEntityQueryDesc());
      // ISSUE: reference to a compiler-generated field
      this.m_PrisonerTransportRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<ServiceRequest>(), ComponentType.ReadWrite<PrisonerTransportRequest>(), ComponentType.ReadWrite<RequestGroup>());
      // ISSUE: reference to a compiler-generated field
      this.m_HandleRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<HandleRequest>(), ComponentType.ReadWrite<Game.Common.Event>());
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_BuildingQuery);
      Assert.IsTrue(true);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      JobHandle jobHandle1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.m_TransportVehicleSelectData.PreUpdate((SystemBase) this, this.m_CityConfigurationSystem, this.m_VehiclePrefabQuery, Allocator.TempJob, out jobHandle1);
      NativeQueue<PrisonAISystem.PrisonAction> nativeQueue = new NativeQueue<PrisonAISystem.PrisonAction>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ResourceProductionData_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrisonData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PublicTransport_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathInformation_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ServiceRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_PrisonerTransportRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Economy_Resources_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Occupant_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Prison_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Efficiency_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
      PrisonAISystem.PrisonTickJob jobData1 = new PrisonAISystem.PrisonTickJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_TransformType = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle,
        m_PrefabRefType = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle,
        m_EfficiencyType = this.__TypeHandle.__Game_Buildings_Efficiency_RO_BufferTypeHandle,
        m_InstalledUpgradeType = this.__TypeHandle.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle,
        m_OwnedVehicleType = this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle,
        m_PrisonType = this.__TypeHandle.__Game_Buildings_Prison_RW_ComponentTypeHandle,
        m_ServiceDispatchType = this.__TypeHandle.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle,
        m_OccupantType = this.__TypeHandle.__Game_Buildings_Occupant_RW_BufferTypeHandle,
        m_ResourcesType = this.__TypeHandle.__Game_Economy_Resources_RW_BufferTypeHandle,
        m_PrisonerTransportRequestData = this.__TypeHandle.__Game_Simulation_PrisonerTransportRequest_RO_ComponentLookup,
        m_ServiceRequestData = this.__TypeHandle.__Game_Simulation_ServiceRequest_RO_ComponentLookup,
        m_PathInformationData = this.__TypeHandle.__Game_Pathfind_PathInformation_RO_ComponentLookup,
        m_PublicTransportData = this.__TypeHandle.__Game_Vehicles_PublicTransport_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_PrisonData = this.__TypeHandle.__Game_Prefabs_PrisonData_RO_ComponentLookup,
        m_PrefabPublicTransportVehicleData = this.__TypeHandle.__Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup,
        m_PathElements = this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup,
        m_ResourceProductionDatas = this.__TypeHandle.__Game_Prefabs_ResourceProductionData_RO_BufferLookup,
        m_RandomSeed = RandomSeed.Next(),
        m_PrisonerTransportRequestArchetype = this.m_PrisonerTransportRequestArchetype,
        m_HandleRequestArchetype = this.m_HandleRequestArchetype,
        m_TransportVehicleSelectData = this.m_TransportVehicleSelectData,
        m_CommandBuffer = this.m_EndFrameBarrier.CreateCommandBuffer().AsParallelWriter(),
        m_ActionQueue = nativeQueue.AsParallelWriter()
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PublicTransport_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      PrisonAISystem.PrisonActionJob jobData2 = new PrisonAISystem.PrisonActionJob()
      {
        m_PublicTransportData = this.__TypeHandle.__Game_Vehicles_PublicTransport_RW_ComponentLookup,
        m_ActionQueue = nativeQueue
      };
      // ISSUE: reference to a compiler-generated field
      JobHandle jobHandle2 = jobData1.ScheduleParallel<PrisonAISystem.PrisonTickJob>(this.m_BuildingQuery, JobHandle.CombineDependencies(this.Dependency, jobHandle1));
      JobHandle dependsOn = jobHandle2;
      JobHandle inputDeps = jobData2.Schedule<PrisonAISystem.PrisonActionJob>(dependsOn);
      nativeQueue.Dispose(inputDeps);
      // ISSUE: reference to a compiler-generated field
      this.m_TransportVehicleSelectData.PostUpdate(jobHandle2);
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier.AddJobHandleForProducer(jobHandle2);
      this.Dependency = inputDeps;
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
    public PrisonAISystem()
    {
    }

    private struct PrisonAction
    {
      public Entity m_Entity;
      public bool m_Disabled;

      public static PrisonAISystem.PrisonAction SetDisabled(Entity vehicle, bool disabled)
      {
        // ISSUE: object of a compiler-generated type is created
        return new PrisonAISystem.PrisonAction()
        {
          m_Entity = vehicle,
          m_Disabled = disabled
        };
      }
    }

    [BurstCompile]
    private struct PrisonTickJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<Transform> m_TransformType;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> m_PrefabRefType;
      [ReadOnly]
      public BufferTypeHandle<Efficiency> m_EfficiencyType;
      [ReadOnly]
      public BufferTypeHandle<InstalledUpgrade> m_InstalledUpgradeType;
      [ReadOnly]
      public BufferTypeHandle<OwnedVehicle> m_OwnedVehicleType;
      public ComponentTypeHandle<Game.Buildings.Prison> m_PrisonType;
      public BufferTypeHandle<ServiceDispatch> m_ServiceDispatchType;
      public BufferTypeHandle<Occupant> m_OccupantType;
      public BufferTypeHandle<Resources> m_ResourcesType;
      [ReadOnly]
      public ComponentLookup<PrisonerTransportRequest> m_PrisonerTransportRequestData;
      [ReadOnly]
      public ComponentLookup<PathInformation> m_PathInformationData;
      [ReadOnly]
      public ComponentLookup<ServiceRequest> m_ServiceRequestData;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.PublicTransport> m_PublicTransportData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public ComponentLookup<PrisonData> m_PrisonData;
      [ReadOnly]
      public ComponentLookup<PublicTransportVehicleData> m_PrefabPublicTransportVehicleData;
      [ReadOnly]
      public BufferLookup<PathElement> m_PathElements;
      [ReadOnly]
      public BufferLookup<ResourceProductionData> m_ResourceProductionDatas;
      [ReadOnly]
      public RandomSeed m_RandomSeed;
      [ReadOnly]
      public EntityArchetype m_PrisonerTransportRequestArchetype;
      [ReadOnly]
      public EntityArchetype m_HandleRequestArchetype;
      [ReadOnly]
      public TransportVehicleSelectData m_TransportVehicleSelectData;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;
      public NativeQueue<PrisonAISystem.PrisonAction>.ParallelWriter m_ActionQueue;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Transform> nativeArray2 = chunk.GetNativeArray<Transform>(ref this.m_TransformType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<PrefabRef> nativeArray3 = chunk.GetNativeArray<PrefabRef>(ref this.m_PrefabRefType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Game.Buildings.Prison> nativeArray4 = chunk.GetNativeArray<Game.Buildings.Prison>(ref this.m_PrisonType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Efficiency> bufferAccessor1 = chunk.GetBufferAccessor<Efficiency>(ref this.m_EfficiencyType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<InstalledUpgrade> bufferAccessor2 = chunk.GetBufferAccessor<InstalledUpgrade>(ref this.m_InstalledUpgradeType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<OwnedVehicle> bufferAccessor3 = chunk.GetBufferAccessor<OwnedVehicle>(ref this.m_OwnedVehicleType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<ServiceDispatch> bufferAccessor4 = chunk.GetBufferAccessor<ServiceDispatch>(ref this.m_ServiceDispatchType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Occupant> bufferAccessor5 = chunk.GetBufferAccessor<Occupant>(ref this.m_OccupantType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Resources> bufferAccessor6 = chunk.GetBufferAccessor<Resources>(ref this.m_ResourcesType);
        NativeList<ResourceProductionData> resourceProductionBuffer = new NativeList<ResourceProductionData>();
        for (int index = 0; index < nativeArray1.Length; ++index)
        {
          Entity entity = nativeArray1[index];
          Transform transform = nativeArray2[index];
          PrefabRef prefabRef = nativeArray3[index];
          Game.Buildings.Prison prison = nativeArray4[index];
          DynamicBuffer<OwnedVehicle> vehicles = bufferAccessor3[index];
          DynamicBuffer<ServiceDispatch> dispatches = bufferAccessor4[index];
          DynamicBuffer<Occupant> occupants = bufferAccessor5[index];
          PrisonData result = new PrisonData();
          // ISSUE: reference to a compiler-generated field
          if (this.m_PrisonData.HasComponent(prefabRef.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            result = this.m_PrisonData[prefabRef.m_Prefab];
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_ResourceProductionDatas.HasBuffer(prefabRef.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated method
            this.AddResourceProductionData(this.m_ResourceProductionDatas[prefabRef.m_Prefab], ref resourceProductionBuffer);
          }
          if (bufferAccessor2.Length != 0)
          {
            DynamicBuffer<InstalledUpgrade> upgrades = bufferAccessor2[index];
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            UpgradeUtils.CombineStats<PrisonData>(ref result, upgrades, ref this.m_PrefabRefData, ref this.m_PrisonData);
            // ISSUE: reference to a compiler-generated method
            this.CombineResourceProductionData(upgrades, ref resourceProductionBuffer);
          }
          float efficiency = BuildingUtils.GetEfficiency(bufferAccessor1, index);
          float immediateEfficiency = BuildingUtils.GetImmediateEfficiency(bufferAccessor1, index);
          DynamicBuffer<Resources> resources = new DynamicBuffer<Resources>();
          if (bufferAccessor6.Length != 0)
            resources = bufferAccessor6[index];
          // ISSUE: reference to a compiler-generated method
          this.Tick(unfilteredChunkIndex, entity, transform, ref prison, result, vehicles, dispatches, occupants, resources, resourceProductionBuffer, efficiency, immediateEfficiency);
          nativeArray4[index] = prison;
          if (resourceProductionBuffer.IsCreated)
            resourceProductionBuffer.Clear();
        }
        if (!resourceProductionBuffer.IsCreated)
          return;
        resourceProductionBuffer.Dispose();
      }

      private void AddResourceProductionData(
        DynamicBuffer<ResourceProductionData> resourceProductionDatas,
        ref NativeList<ResourceProductionData> resourceProductionBuffer)
      {
        if (!resourceProductionBuffer.IsCreated)
          resourceProductionBuffer = new NativeList<ResourceProductionData>(resourceProductionDatas.Length, (AllocatorManager.AllocatorHandle) Allocator.Temp);
        ResourceProductionData.Combine(resourceProductionBuffer, resourceProductionDatas);
      }

      private void CombineResourceProductionData(
        DynamicBuffer<InstalledUpgrade> upgrades,
        ref NativeList<ResourceProductionData> resourceProductionBuffer)
      {
        for (int index = 0; index < upgrades.Length; ++index)
        {
          InstalledUpgrade upgrade = upgrades[index];
          DynamicBuffer<ResourceProductionData> bufferData;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!BuildingUtils.CheckOption(upgrade, BuildingOption.Inactive) && this.m_ResourceProductionDatas.TryGetBuffer(this.m_PrefabRefData[upgrade.m_Upgrade].m_Prefab, out bufferData))
          {
            // ISSUE: reference to a compiler-generated method
            this.AddResourceProductionData(bufferData, ref resourceProductionBuffer);
          }
        }
      }

      private void Tick(
        int jobIndex,
        Entity entity,
        Transform transform,
        ref Game.Buildings.Prison prison,
        PrisonData prefabPrisonData,
        DynamicBuffer<OwnedVehicle> vehicles,
        DynamicBuffer<ServiceDispatch> dispatches,
        DynamicBuffer<Occupant> occupants,
        DynamicBuffer<Resources> resources,
        NativeList<ResourceProductionData> resourceProductionBuffer,
        float efficiency,
        float immediateEfficiency)
      {
        // ISSUE: reference to a compiler-generated field
        Random random = this.m_RandomSeed.GetRandom(entity.Index);
        int index1 = 0;
        while (index1 < occupants.Length)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.m_PrefabRefData.HasComponent(occupants[index1].m_Occupant))
            ++index1;
          else
            occupants.RemoveAt(index1);
        }
        int vehicleCapacity1 = BuildingUtils.GetVehicleCapacity(efficiency, prefabPrisonData.m_PrisonVanCapacity);
        int vehicleCapacity2 = BuildingUtils.GetVehicleCapacity(immediateEfficiency, prefabPrisonData.m_PrisonVanCapacity);
        int availableSpace = prefabPrisonData.m_PrisonerCapacity - occupants.Length;
        if (resourceProductionBuffer.IsCreated)
        {
          float num = 0.0009765625f * (efficiency * (float) occupants.Length / (float) math.max(1, prefabPrisonData.m_PrisonerCapacity));
          for (int index2 = 0; index2 < resourceProductionBuffer.Length; ++index2)
          {
            ResourceProductionData resourceProductionData = resourceProductionBuffer[index2];
            int resources1 = EconomyUtils.GetResources(resourceProductionData.m_Type, resources);
            int amount = math.max(0, math.min(MathUtils.RoundToIntRandom(ref random, (float) resourceProductionData.m_ProductionRate * num), resourceProductionData.m_StorageCapacity - resources1));
            EconomyUtils.AddResources(resourceProductionData.m_Type, amount, resources);
          }
        }
        for (int index3 = 0; index3 < vehicles.Length; ++index3)
        {
          Entity vehicle = vehicles[index3].m_Vehicle;
          Game.Vehicles.PublicTransport componentData;
          // ISSUE: reference to a compiler-generated field
          if (this.m_PublicTransportData.TryGetComponent(vehicle, out componentData))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            PublicTransportVehicleData transportVehicleData = this.m_PrefabPublicTransportVehicleData[this.m_PrefabRefData[vehicle].m_Prefab];
            --vehicleCapacity1;
            availableSpace -= transportVehicleData.m_PassengerCapacity;
            bool disabled = --vehicleCapacity2 < 0;
            if ((componentData.m_State & PublicTransportFlags.Disabled) > (PublicTransportFlags) 0 != disabled)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.m_ActionQueue.Enqueue(PrisonAISystem.PrisonAction.SetDisabled(vehicle, disabled));
            }
          }
        }
        int index4 = 0;
        while (index4 < dispatches.Length)
        {
          Entity request = dispatches[index4].m_Request;
          // ISSUE: reference to a compiler-generated field
          if (this.m_PrisonerTransportRequestData.HasComponent(request))
          {
            // ISSUE: reference to a compiler-generated method
            this.SpawnVehicle(jobIndex, ref random, entity, request, transform, ref prison, ref vehicleCapacity1, ref availableSpace);
            dispatches.RemoveAt(index4);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (!this.m_ServiceRequestData.HasComponent(request))
              dispatches.RemoveAt(index4);
            else
              ++index4;
          }
        }
        if (vehicleCapacity1 > 0)
        {
          prison.m_Flags |= PrisonFlags.HasAvailablePrisonVans;
          // ISSUE: reference to a compiler-generated method
          this.RequestTargetIfNeeded(jobIndex, entity, ref prison, vehicleCapacity1);
        }
        else
          prison.m_Flags &= ~PrisonFlags.HasAvailablePrisonVans;
        if (availableSpace > 0)
          prison.m_Flags |= PrisonFlags.HasPrisonerSpace;
        else
          prison.m_Flags &= ~PrisonFlags.HasPrisonerSpace;
        prison.m_PrisonerWellbeing = (sbyte) math.clamp((int) math.round(efficiency * (float) prefabPrisonData.m_PrisonerWellbeing), -100, 100);
        prison.m_PrisonerHealth = (sbyte) math.clamp((int) math.round(efficiency * (float) prefabPrisonData.m_PrisonerHealth), -100, 100);
      }

      private void RequestTargetIfNeeded(
        int jobIndex,
        Entity entity,
        ref Game.Buildings.Prison prison,
        int availableVehicles)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_ServiceRequestData.HasComponent(prison.m_TargetRequest))
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity entity1 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_PrisonerTransportRequestArchetype);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<ServiceRequest>(jobIndex, entity1, new ServiceRequest(true));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<PrisonerTransportRequest>(jobIndex, entity1, new PrisonerTransportRequest(entity, availableVehicles));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<RequestGroup>(jobIndex, entity1, new RequestGroup(16U));
      }

      private void SpawnVehicle(
        int jobIndex,
        ref Random random,
        Entity entity,
        Entity request,
        Transform transform,
        ref Game.Buildings.Prison prison,
        ref int availableVehicles,
        ref int availableSpace)
      {
        // ISSUE: reference to a compiler-generated field
        if (!this.m_PrisonerTransportRequestData.HasComponent(request))
          return;
        // ISSUE: reference to a compiler-generated field
        PrisonerTransportRequest transportRequest = this.m_PrisonerTransportRequestData[request];
        // ISSUE: reference to a compiler-generated field
        if (!this.m_PrefabRefData.HasComponent(transportRequest.m_Target) || availableVehicles <= 0 || availableSpace <= 0)
          return;
        int2 passengerCapacity = new int2(1, availableSpace);
        int2 cargoCapacity = (int2) 0;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity vehicle = this.m_TransportVehicleSelectData.CreateVehicle(this.m_CommandBuffer, jobIndex, ref random, transform, entity, Entity.Null, Entity.Null, TransportType.Bus, EnergyTypes.FuelAndElectricity, PublicTransportPurpose.PrisonerTransport, Resource.NoResource, ref passengerCapacity, ref cargoCapacity);
        if (vehicle == Entity.Null)
          return;
        --availableVehicles;
        availableSpace -= passengerCapacity.y;
        Game.Vehicles.PublicTransport component = new Game.Vehicles.PublicTransport();
        component.m_State |= PublicTransportFlags.PrisonerTransport;
        component.m_RequestCount = 1;
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<Game.Vehicles.PublicTransport>(jobIndex, vehicle, component);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<Target>(jobIndex, vehicle, new Target(transportRequest.m_Target));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.AddComponent<Owner>(jobIndex, vehicle, new Owner(entity));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetBuffer<ServiceDispatch>(jobIndex, vehicle).Add(new ServiceDispatch(request));
        // ISSUE: reference to a compiler-generated field
        if (this.m_PathElements.HasBuffer(request))
        {
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<PathElement> pathElement = this.m_PathElements[request];
          if (pathElement.Length != 0)
          {
            // ISSUE: reference to a compiler-generated field
            DynamicBuffer<PathElement> targetElements = this.m_CommandBuffer.SetBuffer<PathElement>(jobIndex, vehicle);
            PathUtils.CopyPath(pathElement, new PathOwner(), 0, targetElements);
            // ISSUE: reference to a compiler-generated field
            this.m_CommandBuffer.SetComponent<PathOwner>(jobIndex, vehicle, new PathOwner(PathFlags.Updated));
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_CommandBuffer.SetComponent<PathInformation>(jobIndex, vehicle, this.m_PathInformationData[request]);
          }
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity entity1 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_HandleRequestArchetype);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<HandleRequest>(jobIndex, entity1, new HandleRequest(request, vehicle, false));
        // ISSUE: reference to a compiler-generated field
        if (!this.m_ServiceRequestData.HasComponent(prison.m_TargetRequest))
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity entity2 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_HandleRequestArchetype);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<HandleRequest>(jobIndex, entity2, new HandleRequest(prison.m_TargetRequest, Entity.Null, true));
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
    private struct PrisonActionJob : IJob
    {
      public ComponentLookup<Game.Vehicles.PublicTransport> m_PublicTransportData;
      public NativeQueue<PrisonAISystem.PrisonAction> m_ActionQueue;

      public void Execute()
      {
        // ISSUE: variable of a compiler-generated type
        PrisonAISystem.PrisonAction prisonAction;
        // ISSUE: reference to a compiler-generated field
        while (this.m_ActionQueue.TryDequeue(out prisonAction))
        {
          Game.Vehicles.PublicTransport componentData;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_PublicTransportData.TryGetComponent(prisonAction.m_Entity, out componentData))
          {
            // ISSUE: reference to a compiler-generated field
            if (prisonAction.m_Disabled)
              componentData.m_State |= PublicTransportFlags.AbandonRoute | PublicTransportFlags.Disabled;
            else
              componentData.m_State &= ~PublicTransportFlags.Disabled;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_PublicTransportData[prisonAction.m_Entity] = componentData;
          }
        }
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Transform> __Game_Objects_Transform_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<Efficiency> __Game_Buildings_Efficiency_RO_BufferTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<InstalledUpgrade> __Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<OwnedVehicle> __Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle;
      public ComponentTypeHandle<Game.Buildings.Prison> __Game_Buildings_Prison_RW_ComponentTypeHandle;
      public BufferTypeHandle<ServiceDispatch> __Game_Simulation_ServiceDispatch_RW_BufferTypeHandle;
      public BufferTypeHandle<Occupant> __Game_Buildings_Occupant_RW_BufferTypeHandle;
      public BufferTypeHandle<Resources> __Game_Economy_Resources_RW_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<PrisonerTransportRequest> __Game_Simulation_PrisonerTransportRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ServiceRequest> __Game_Simulation_ServiceRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PathInformation> __Game_Pathfind_PathInformation_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.PublicTransport> __Game_Vehicles_PublicTransport_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrisonData> __Game_Prefabs_PrisonData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PublicTransportVehicleData> __Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<PathElement> __Game_Pathfind_PathElement_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<ResourceProductionData> __Game_Prefabs_ResourceProductionData_RO_BufferLookup;
      public ComponentLookup<Game.Vehicles.PublicTransport> __Game_Vehicles_PublicTransport_RW_ComponentLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Transform>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Efficiency_RO_BufferTypeHandle = state.GetBufferTypeHandle<Efficiency>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle = state.GetBufferTypeHandle<InstalledUpgrade>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle = state.GetBufferTypeHandle<OwnedVehicle>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Prison_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Buildings.Prison>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle = state.GetBufferTypeHandle<ServiceDispatch>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Occupant_RW_BufferTypeHandle = state.GetBufferTypeHandle<Occupant>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Economy_Resources_RW_BufferTypeHandle = state.GetBufferTypeHandle<Resources>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_PrisonerTransportRequest_RO_ComponentLookup = state.GetComponentLookup<PrisonerTransportRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ServiceRequest_RO_ComponentLookup = state.GetComponentLookup<ServiceRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathInformation_RO_ComponentLookup = state.GetComponentLookup<PathInformation>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PublicTransport_RO_ComponentLookup = state.GetComponentLookup<Game.Vehicles.PublicTransport>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrisonData_RO_ComponentLookup = state.GetComponentLookup<PrisonData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup = state.GetComponentLookup<PublicTransportVehicleData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathElement_RO_BufferLookup = state.GetBufferLookup<PathElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ResourceProductionData_RO_BufferLookup = state.GetBufferLookup<ResourceProductionData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PublicTransport_RW_ComponentLookup = state.GetComponentLookup<Game.Vehicles.PublicTransport>();
      }
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.PoliceStationAISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Buildings;
using Game.Citizens;
using Game.City;
using Game.Common;
using Game.Net;
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
  public class PoliceStationAISystem : GameSystemBase
  {
    private EntityQuery m_BuildingQuery;
    private EntityQuery m_VehiclePrefabQuery;
    private EndFrameBarrier m_EndFrameBarrier;
    private SimulationSystem m_SimulationSystem;
    private CityConfigurationSystem m_CityConfigurationSystem;
    private PoliceCarSelectData m_PoliceCarSelectData;
    private EntityArchetype m_PrisonerTransportRequestArchetype;
    private EntityArchetype m_PolicePatrolRequestArchetype;
    private EntityArchetype m_PoliceEmergencyRequestArchetype;
    private EntityArchetype m_HandleRequestArchetype;
    private PoliceStationAISystem.TypeHandle __TypeHandle;

    public override int GetUpdateInterval(SystemUpdatePhase phase) => 256;

    public override int GetUpdateOffset(SystemUpdatePhase phase) => 128;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier = this.World.GetOrCreateSystemManaged<EndFrameBarrier>();
      // ISSUE: reference to a compiler-generated field
      this.m_SimulationSystem = this.World.GetOrCreateSystemManaged<SimulationSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_CityConfigurationSystem = this.World.GetOrCreateSystemManaged<CityConfigurationSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_PoliceCarSelectData = new PoliceCarSelectData((SystemBase) this);
      // ISSUE: reference to a compiler-generated field
      this.m_BuildingQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[3]
        {
          ComponentType.ReadOnly<Game.Buildings.PoliceStation>(),
          ComponentType.ReadOnly<ServiceDispatch>(),
          ComponentType.ReadOnly<PrefabRef>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Building>(),
          ComponentType.ReadOnly<Game.Objects.OutsideConnection>()
        },
        None = new ComponentType[2]
        {
          ComponentType.ReadOnly<Temp>(),
          ComponentType.ReadOnly<Deleted>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.m_VehiclePrefabQuery = this.GetEntityQuery(PoliceCarSelectData.GetEntityQueryDesc());
      // ISSUE: reference to a compiler-generated field
      this.m_PrisonerTransportRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<ServiceRequest>(), ComponentType.ReadWrite<PrisonerTransportRequest>(), ComponentType.ReadWrite<RequestGroup>());
      // ISSUE: reference to a compiler-generated field
      this.m_PolicePatrolRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<ServiceRequest>(), ComponentType.ReadWrite<PolicePatrolRequest>(), ComponentType.ReadWrite<RequestGroup>());
      // ISSUE: reference to a compiler-generated field
      this.m_PoliceEmergencyRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<ServiceRequest>(), ComponentType.ReadWrite<PoliceEmergencyRequest>(), ComponentType.ReadWrite<RequestGroup>());
      // ISSUE: reference to a compiler-generated field
      this.m_HandleRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<HandleRequest>(), ComponentType.ReadWrite<Game.Common.Event>());
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_BuildingQuery);
      Assert.IsTrue(true);
      Assert.IsTrue(true);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      JobHandle jobHandle1;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.m_PoliceCarSelectData.PreUpdate((SystemBase) this, this.m_CityConfigurationSystem, this.m_VehiclePrefabQuery, Allocator.TempJob, out jobHandle1);
      NativeQueue<PoliceStationAISystem.PoliceStationAction> nativeQueue = new NativeQueue<PoliceStationAISystem.PoliceStationAction>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_SpawnLocationData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PoliceStationData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_Helicopter_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PoliceCar_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Criminal_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Transform_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathInformation_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ServiceRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_PoliceEmergencyRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_PolicePatrolRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Occupant_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_PoliceStation_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_OutsideConnection_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Efficiency_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      PoliceStationAISystem.PoliceStationTickJob jobData1 = new PoliceStationAISystem.PoliceStationTickJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_PrefabRefType = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle,
        m_EfficiencyType = this.__TypeHandle.__Game_Buildings_Efficiency_RO_BufferTypeHandle,
        m_OutsideConnectionType = this.__TypeHandle.__Game_Objects_OutsideConnection_RO_ComponentTypeHandle,
        m_InstalledUpgradeType = this.__TypeHandle.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle,
        m_OwnedVehicleType = this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle,
        m_PoliceStationType = this.__TypeHandle.__Game_Buildings_PoliceStation_RW_ComponentTypeHandle,
        m_ServiceDispatchType = this.__TypeHandle.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle,
        m_OccupantType = this.__TypeHandle.__Game_Buildings_Occupant_RW_BufferTypeHandle,
        m_PolicePatrolRequestData = this.__TypeHandle.__Game_Simulation_PolicePatrolRequest_RO_ComponentLookup,
        m_PoliceEmergencyRequestData = this.__TypeHandle.__Game_Simulation_PoliceEmergencyRequest_RO_ComponentLookup,
        m_ServiceRequestData = this.__TypeHandle.__Game_Simulation_ServiceRequest_RO_ComponentLookup,
        m_PathInformationData = this.__TypeHandle.__Game_Pathfind_PathInformation_RO_ComponentLookup,
        m_TransformData = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentLookup,
        m_CriminalData = this.__TypeHandle.__Game_Citizens_Criminal_RO_ComponentLookup,
        m_PoliceCarData = this.__TypeHandle.__Game_Vehicles_PoliceCar_RO_ComponentLookup,
        m_HelicopterData = this.__TypeHandle.__Game_Vehicles_Helicopter_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_PrefabPoliceStationData = this.__TypeHandle.__Game_Prefabs_PoliceStationData_RO_ComponentLookup,
        m_PrefabSpawnLocationData = this.__TypeHandle.__Game_Prefabs_SpawnLocationData_RO_ComponentLookup,
        m_PathElements = this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup,
        m_SimulationFrameIndex = this.m_SimulationSystem.frameIndex,
        m_RandomSeed = RandomSeed.Next(),
        m_PrisonerTransportRequestArchetype = this.m_PrisonerTransportRequestArchetype,
        m_PolicePatrolRequestArchetype = this.m_PolicePatrolRequestArchetype,
        m_PoliceEmergencyRequestArchetype = this.m_PoliceEmergencyRequestArchetype,
        m_HandleRequestArchetype = this.m_HandleRequestArchetype,
        m_PoliceCarSelectData = this.m_PoliceCarSelectData,
        m_CommandBuffer = this.m_EndFrameBarrier.CreateCommandBuffer().AsParallelWriter(),
        m_ActionQueue = nativeQueue.AsParallelWriter()
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PoliceCar_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      PoliceStationAISystem.PoliceStationActionJob jobData2 = new PoliceStationAISystem.PoliceStationActionJob()
      {
        m_PoliceCarData = this.__TypeHandle.__Game_Vehicles_PoliceCar_RW_ComponentLookup,
        m_ActionQueue = nativeQueue
      };
      // ISSUE: reference to a compiler-generated field
      JobHandle jobHandle2 = jobData1.ScheduleParallel<PoliceStationAISystem.PoliceStationTickJob>(this.m_BuildingQuery, JobHandle.CombineDependencies(this.Dependency, jobHandle1));
      JobHandle dependsOn = jobHandle2;
      JobHandle inputDeps = jobData2.Schedule<PoliceStationAISystem.PoliceStationActionJob>(dependsOn);
      nativeQueue.Dispose(inputDeps);
      // ISSUE: reference to a compiler-generated field
      this.m_PoliceCarSelectData.PostUpdate(jobHandle2);
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
    public PoliceStationAISystem()
    {
    }

    private struct PoliceStationAction
    {
      public Entity m_Entity;
      public bool m_Disabled;

      public static PoliceStationAISystem.PoliceStationAction SetDisabled(
        Entity vehicle,
        bool disabled)
      {
        // ISSUE: object of a compiler-generated type is created
        return new PoliceStationAISystem.PoliceStationAction()
        {
          m_Entity = vehicle,
          m_Disabled = disabled
        };
      }
    }

    [BurstCompile]
    private struct PoliceStationTickJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> m_PrefabRefType;
      [ReadOnly]
      public BufferTypeHandle<Efficiency> m_EfficiencyType;
      [ReadOnly]
      public ComponentTypeHandle<Game.Objects.OutsideConnection> m_OutsideConnectionType;
      [ReadOnly]
      public BufferTypeHandle<InstalledUpgrade> m_InstalledUpgradeType;
      [ReadOnly]
      public BufferTypeHandle<OwnedVehicle> m_OwnedVehicleType;
      public ComponentTypeHandle<Game.Buildings.PoliceStation> m_PoliceStationType;
      public BufferTypeHandle<ServiceDispatch> m_ServiceDispatchType;
      public BufferTypeHandle<Occupant> m_OccupantType;
      [ReadOnly]
      public ComponentLookup<PolicePatrolRequest> m_PolicePatrolRequestData;
      [ReadOnly]
      public ComponentLookup<PoliceEmergencyRequest> m_PoliceEmergencyRequestData;
      [ReadOnly]
      public ComponentLookup<ServiceRequest> m_ServiceRequestData;
      [ReadOnly]
      public ComponentLookup<PathInformation> m_PathInformationData;
      [ReadOnly]
      public ComponentLookup<Transform> m_TransformData;
      [ReadOnly]
      public ComponentLookup<Criminal> m_CriminalData;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.PoliceCar> m_PoliceCarData;
      [ReadOnly]
      public ComponentLookup<Helicopter> m_HelicopterData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public ComponentLookup<PoliceStationData> m_PrefabPoliceStationData;
      [ReadOnly]
      public ComponentLookup<Game.Prefabs.SpawnLocationData> m_PrefabSpawnLocationData;
      [ReadOnly]
      public BufferLookup<PathElement> m_PathElements;
      [ReadOnly]
      public uint m_SimulationFrameIndex;
      [ReadOnly]
      public RandomSeed m_RandomSeed;
      [ReadOnly]
      public EntityArchetype m_PrisonerTransportRequestArchetype;
      [ReadOnly]
      public EntityArchetype m_PolicePatrolRequestArchetype;
      [ReadOnly]
      public EntityArchetype m_PoliceEmergencyRequestArchetype;
      [ReadOnly]
      public EntityArchetype m_HandleRequestArchetype;
      [ReadOnly]
      public PoliceCarSelectData m_PoliceCarSelectData;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;
      public NativeQueue<PoliceStationAISystem.PoliceStationAction>.ParallelWriter m_ActionQueue;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<PrefabRef> nativeArray2 = chunk.GetNativeArray<PrefabRef>(ref this.m_PrefabRefType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Game.Buildings.PoliceStation> nativeArray3 = chunk.GetNativeArray<Game.Buildings.PoliceStation>(ref this.m_PoliceStationType);
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
        bool outside = chunk.Has<Game.Objects.OutsideConnection>(ref this.m_OutsideConnectionType);
        for (int index = 0; index < nativeArray1.Length; ++index)
        {
          Entity entity = nativeArray1[index];
          PrefabRef prefabRef = nativeArray2[index];
          Game.Buildings.PoliceStation policeStation = nativeArray3[index];
          DynamicBuffer<OwnedVehicle> vehicles = bufferAccessor3[index];
          DynamicBuffer<ServiceDispatch> dispatches = bufferAccessor4[index];
          DynamicBuffer<Occupant> occupants = new DynamicBuffer<Occupant>();
          if (bufferAccessor5.Length != 0)
            occupants = bufferAccessor5[index];
          PoliceStationData result = new PoliceStationData();
          // ISSUE: reference to a compiler-generated field
          if (this.m_PrefabPoliceStationData.HasComponent(prefabRef.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            result = this.m_PrefabPoliceStationData[prefabRef.m_Prefab];
          }
          if (bufferAccessor2.Length != 0)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            UpgradeUtils.CombineStats<PoliceStationData>(ref result, bufferAccessor2[index], ref this.m_PrefabRefData, ref this.m_PrefabPoliceStationData);
          }
          float efficiency = BuildingUtils.GetEfficiency(bufferAccessor1, index);
          float immediateEfficiency = BuildingUtils.GetImmediateEfficiency(bufferAccessor1, index);
          // ISSUE: reference to a compiler-generated method
          this.Tick(unfilteredChunkIndex, entity, ref policeStation, result, vehicles, dispatches, occupants, efficiency, immediateEfficiency, outside);
          nativeArray3[index] = policeStation;
        }
      }

      private void Tick(
        int jobIndex,
        Entity entity,
        ref Game.Buildings.PoliceStation policeStation,
        PoliceStationData prefabPoliceStationData,
        DynamicBuffer<OwnedVehicle> vehicles,
        DynamicBuffer<ServiceDispatch> dispatches,
        DynamicBuffer<Occupant> occupants,
        float efficiency,
        float immediateEfficiency,
        bool outside)
      {
        // ISSUE: reference to a compiler-generated field
        Random random = this.m_RandomSeed.GetRandom(entity.Index);
        int vehicleCapacity1 = BuildingUtils.GetVehicleCapacity(efficiency, prefabPoliceStationData.m_PatrolCarCapacity);
        int vehicleCapacity2 = BuildingUtils.GetVehicleCapacity(efficiency, prefabPoliceStationData.m_PoliceHelicopterCapacity);
        int vehicleCapacity3 = BuildingUtils.GetVehicleCapacity(immediateEfficiency, prefabPoliceStationData.m_PatrolCarCapacity);
        int vehicleCapacity4 = BuildingUtils.GetVehicleCapacity(immediateEfficiency, prefabPoliceStationData.m_PoliceHelicopterCapacity);
        policeStation.m_PurposeMask = prefabPoliceStationData.m_PurposeMask;
        for (int index = 0; index < vehicles.Length; ++index)
        {
          Entity vehicle = vehicles[index].m_Vehicle;
          Game.Vehicles.PoliceCar componentData;
          // ISSUE: reference to a compiler-generated field
          if (this.m_PoliceCarData.TryGetComponent(vehicle, out componentData))
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_HelicopterData.HasComponent(vehicle))
            {
              --vehicleCapacity2;
              bool disabled = --vehicleCapacity4 < 0;
              if ((componentData.m_State & PoliceCarFlags.Disabled) > (PoliceCarFlags) 0 != disabled)
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated method
                this.m_ActionQueue.Enqueue(PoliceStationAISystem.PoliceStationAction.SetDisabled(vehicle, disabled));
              }
            }
            else
            {
              --vehicleCapacity1;
              bool disabled = --vehicleCapacity3 < 0;
              if ((componentData.m_State & PoliceCarFlags.Disabled) > (PoliceCarFlags) 0 != disabled)
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated method
                this.m_ActionQueue.Enqueue(PoliceStationAISystem.PoliceStationAction.SetDisabled(vehicle, disabled));
              }
            }
          }
        }
        int index1 = 0;
        while (index1 < dispatches.Length)
        {
          Entity request = dispatches[index1].m_Request;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_PolicePatrolRequestData.HasComponent(request) || this.m_PoliceEmergencyRequestData.HasComponent(request))
          {
            // ISSUE: reference to a compiler-generated method
            RoadTypes roadType = this.CheckPathType(request);
            switch (roadType)
            {
              case RoadTypes.Car:
                // ISSUE: reference to a compiler-generated method
                this.SpawnVehicle(jobIndex, ref random, entity, request, roadType, ref policeStation, ref vehicleCapacity1, outside);
                break;
              case RoadTypes.Helicopter:
                // ISSUE: reference to a compiler-generated method
                this.SpawnVehicle(jobIndex, ref random, entity, request, roadType, ref policeStation, ref vehicleCapacity2, outside);
                break;
            }
            dispatches.RemoveAt(index1);
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (!this.m_ServiceRequestData.HasComponent(request))
              dispatches.RemoveAt(index1);
            else
              ++index1;
          }
        }
        if (vehicleCapacity1 > 0)
          policeStation.m_Flags |= PoliceStationFlags.HasAvailablePatrolCars;
        else
          policeStation.m_Flags &= ~PoliceStationFlags.HasAvailablePatrolCars;
        if (vehicleCapacity2 > 0)
          policeStation.m_Flags |= PoliceStationFlags.HasAvailablePoliceHelicopters;
        else
          policeStation.m_Flags &= ~PoliceStationFlags.HasAvailablePoliceHelicopters;
        int priority = 0;
        if (occupants.IsCreated)
        {
          int index2 = 0;
          while (index2 < occupants.Length)
          {
            Entity occupant = occupants[index2].m_Occupant;
            // ISSUE: reference to a compiler-generated field
            if (!this.m_CriminalData.HasComponent(occupant))
            {
              occupants.RemoveAt(index2);
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              Criminal criminal = this.m_CriminalData[occupant];
              if ((criminal.m_Flags & CriminalFlags.Arrested) == (CriminalFlags) 0)
              {
                occupants.RemoveAt(index2);
              }
              else
              {
                if ((criminal.m_Flags & CriminalFlags.Sentenced) != (CriminalFlags) 0)
                  ++priority;
                ++index2;
              }
            }
          }
        }
        if (priority > 0)
        {
          policeStation.m_Flags |= PoliceStationFlags.NeedPrisonerTransport;
          // ISSUE: reference to a compiler-generated method
          this.RequestPrisonerTransport(jobIndex, entity, ref policeStation, priority);
        }
        else
          policeStation.m_Flags &= ~PoliceStationFlags.NeedPrisonerTransport;
        if (vehicleCapacity1 <= 0 && vehicleCapacity2 <= 0)
          return;
        // ISSUE: reference to a compiler-generated method
        this.RequestTargetIfNeeded(jobIndex, entity, ref policeStation, vehicleCapacity1, vehicleCapacity2);
      }

      private void RequestPrisonerTransport(
        int jobIndex,
        Entity entity,
        ref Game.Buildings.PoliceStation policeStation,
        int priority)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_ServiceRequestData.HasComponent(policeStation.m_PrisonerTransportRequest))
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity entity1 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_PrisonerTransportRequestArchetype);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<PrisonerTransportRequest>(jobIndex, entity1, new PrisonerTransportRequest(entity, priority));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<RequestGroup>(jobIndex, entity1, new RequestGroup(16U));
      }

      private void RequestTargetIfNeeded(
        int jobIndex,
        Entity entity,
        ref Game.Buildings.PoliceStation policeStation,
        int availablePatrolCars,
        int availablePoliceHelicopters)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_ServiceRequestData.HasComponent(policeStation.m_TargetRequest))
          return;
        if ((policeStation.m_PurposeMask & PolicePurpose.Patrol) != (PolicePurpose) 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (((int) this.m_SimulationFrameIndex & (int) math.max(512U, 256U) - 1) != 128)
            return;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity entity1 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_PolicePatrolRequestArchetype);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<ServiceRequest>(jobIndex, entity1, new ServiceRequest(true));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<PolicePatrolRequest>(jobIndex, entity1, new PolicePatrolRequest(entity, (float) (availablePatrolCars + availablePoliceHelicopters)));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<RequestGroup>(jobIndex, entity1, new RequestGroup(32U));
        }
        else
        {
          if ((policeStation.m_PurposeMask & (PolicePurpose.Emergency | PolicePurpose.Intelligence)) == (PolicePurpose) 0 || availablePatrolCars <= 0)
            return;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity entity2 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_PoliceEmergencyRequestArchetype);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<ServiceRequest>(jobIndex, entity2, new ServiceRequest(true));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<PoliceEmergencyRequest>(jobIndex, entity2, new PoliceEmergencyRequest(entity, Entity.Null, (float) availablePatrolCars, policeStation.m_PurposeMask & (PolicePurpose.Emergency | PolicePurpose.Intelligence)));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<RequestGroup>(jobIndex, entity2, new RequestGroup(4U));
        }
      }

      private void SpawnVehicle(
        int jobIndex,
        ref Random random,
        Entity entity,
        Entity request,
        RoadTypes roadType,
        ref Game.Buildings.PoliceStation policeStation,
        ref int availableVehicles,
        bool outside)
      {
        if (availableVehicles <= 0)
          return;
        Entity entity1;
        PolicePurpose purposeMask;
        PoliceCarFlags flags;
        // ISSUE: reference to a compiler-generated field
        if (this.m_PolicePatrolRequestData.HasComponent(request))
        {
          // ISSUE: reference to a compiler-generated field
          entity1 = this.m_PolicePatrolRequestData[request].m_Target;
          purposeMask = policeStation.m_PurposeMask & PolicePurpose.Patrol;
          flags = (PoliceCarFlags) 0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          if (!this.m_PoliceEmergencyRequestData.HasComponent(request))
            return;
          // ISSUE: reference to a compiler-generated field
          PoliceEmergencyRequest emergencyRequest = this.m_PoliceEmergencyRequestData[request];
          // ISSUE: reference to a compiler-generated field
          entity1 = this.m_PoliceEmergencyRequestData[request].m_Site;
          purposeMask = policeStation.m_PurposeMask & emergencyRequest.m_Purpose;
          flags = PoliceCarFlags.AccidentTarget;
        }
        // ISSUE: reference to a compiler-generated field
        if (!this.m_PrefabRefData.HasComponent(entity1))
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity vehicle = this.m_PoliceCarSelectData.CreateVehicle(this.m_CommandBuffer, jobIndex, ref random, this.m_TransformData[entity], entity, ref purposeMask, roadType);
        if (vehicle == Entity.Null)
          return;
        --availableVehicles;
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<Game.Vehicles.PoliceCar>(jobIndex, vehicle, new Game.Vehicles.PoliceCar(flags, 1, policeStation.m_PurposeMask & purposeMask));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<Target>(jobIndex, vehicle, new Target(entity1));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.AddComponent<Owner>(jobIndex, vehicle, new Owner(entity));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetBuffer<ServiceDispatch>(jobIndex, vehicle).Add(new ServiceDispatch(request));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity entity2 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_HandleRequestArchetype);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<HandleRequest>(jobIndex, entity2, new HandleRequest(request, vehicle, false));
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
        if (!this.m_ServiceRequestData.HasComponent(policeStation.m_TargetRequest))
          return;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity entity3 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_HandleRequestArchetype);
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<HandleRequest>(jobIndex, entity3, new HandleRequest(policeStation.m_TargetRequest, Entity.Null, true));
      }

      private RoadTypes CheckPathType(Entity request)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_PathElements.HasBuffer(request))
        {
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<PathElement> pathElement1 = this.m_PathElements[request];
          if (pathElement1.Length >= 1)
          {
            PathElement pathElement2 = pathElement1[0];
            // ISSUE: reference to a compiler-generated field
            if (this.m_PrefabRefData.HasComponent(pathElement2.m_Target))
            {
              // ISSUE: reference to a compiler-generated field
              PrefabRef prefabRef = this.m_PrefabRefData[pathElement2.m_Target];
              // ISSUE: reference to a compiler-generated field
              if (this.m_PrefabSpawnLocationData.HasComponent(prefabRef.m_Prefab))
              {
                // ISSUE: reference to a compiler-generated field
                return this.m_PrefabSpawnLocationData[prefabRef.m_Prefab].m_RoadTypes;
              }
            }
          }
        }
        return RoadTypes.Car;
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
    private struct PoliceStationActionJob : IJob
    {
      public ComponentLookup<Game.Vehicles.PoliceCar> m_PoliceCarData;
      public NativeQueue<PoliceStationAISystem.PoliceStationAction> m_ActionQueue;

      public void Execute()
      {
        // ISSUE: variable of a compiler-generated type
        PoliceStationAISystem.PoliceStationAction policeStationAction;
        // ISSUE: reference to a compiler-generated field
        while (this.m_ActionQueue.TryDequeue(out policeStationAction))
        {
          Game.Vehicles.PoliceCar componentData;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_PoliceCarData.TryGetComponent(policeStationAction.m_Entity, out componentData))
          {
            // ISSUE: reference to a compiler-generated field
            if (policeStationAction.m_Disabled)
              componentData.m_State |= PoliceCarFlags.Disabled;
            else
              componentData.m_State &= ~PoliceCarFlags.Disabled;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_PoliceCarData[policeStationAction.m_Entity] = componentData;
          }
        }
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<Efficiency> __Game_Buildings_Efficiency_RO_BufferTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Game.Objects.OutsideConnection> __Game_Objects_OutsideConnection_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<InstalledUpgrade> __Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<OwnedVehicle> __Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle;
      public ComponentTypeHandle<Game.Buildings.PoliceStation> __Game_Buildings_PoliceStation_RW_ComponentTypeHandle;
      public BufferTypeHandle<ServiceDispatch> __Game_Simulation_ServiceDispatch_RW_BufferTypeHandle;
      public BufferTypeHandle<Occupant> __Game_Buildings_Occupant_RW_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<PolicePatrolRequest> __Game_Simulation_PolicePatrolRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PoliceEmergencyRequest> __Game_Simulation_PoliceEmergencyRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ServiceRequest> __Game_Simulation_ServiceRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PathInformation> __Game_Pathfind_PathInformation_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Transform> __Game_Objects_Transform_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Criminal> __Game_Citizens_Criminal_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.PoliceCar> __Game_Vehicles_PoliceCar_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Helicopter> __Game_Vehicles_Helicopter_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PoliceStationData> __Game_Prefabs_PoliceStationData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Prefabs.SpawnLocationData> __Game_Prefabs_SpawnLocationData_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<PathElement> __Game_Pathfind_PathElement_RO_BufferLookup;
      public ComponentLookup<Game.Vehicles.PoliceCar> __Game_Vehicles_PoliceCar_RW_ComponentLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Efficiency_RO_BufferTypeHandle = state.GetBufferTypeHandle<Efficiency>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_OutsideConnection_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Objects.OutsideConnection>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle = state.GetBufferTypeHandle<InstalledUpgrade>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle = state.GetBufferTypeHandle<OwnedVehicle>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_PoliceStation_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Buildings.PoliceStation>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle = state.GetBufferTypeHandle<ServiceDispatch>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Occupant_RW_BufferTypeHandle = state.GetBufferTypeHandle<Occupant>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_PolicePatrolRequest_RO_ComponentLookup = state.GetComponentLookup<PolicePatrolRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_PoliceEmergencyRequest_RO_ComponentLookup = state.GetComponentLookup<PoliceEmergencyRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ServiceRequest_RO_ComponentLookup = state.GetComponentLookup<ServiceRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathInformation_RO_ComponentLookup = state.GetComponentLookup<PathInformation>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RO_ComponentLookup = state.GetComponentLookup<Transform>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Criminal_RO_ComponentLookup = state.GetComponentLookup<Criminal>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PoliceCar_RO_ComponentLookup = state.GetComponentLookup<Game.Vehicles.PoliceCar>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Helicopter_RO_ComponentLookup = state.GetComponentLookup<Helicopter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PoliceStationData_RO_ComponentLookup = state.GetComponentLookup<PoliceStationData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_SpawnLocationData_RO_ComponentLookup = state.GetComponentLookup<Game.Prefabs.SpawnLocationData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathElement_RO_BufferLookup = state.GetBufferLookup<PathElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PoliceCar_RW_ComponentLookup = state.GetComponentLookup<Game.Vehicles.PoliceCar>();
      }
    }
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.Simulation.TransportDepotAISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Buildings;
using Game.City;
using Game.Common;
using Game.Economy;
using Game.Events;
using Game.Objects;
using Game.Pathfind;
using Game.Prefabs;
using Game.Rendering;
using Game.Routes;
using Game.Tools;
using Game.Vehicles;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Assertions;

#nullable disable
namespace Game.Simulation
{
  [CompilerGenerated]
  public class TransportDepotAISystem : GameSystemBase
  {
    private EntityQuery m_BuildingQuery;
    private EntityQuery m_VehiclePrefabQuery;
    private EntityQuery m_EventPrefabQuery;
    private EntityArchetype m_TransportVehicleRequestArchetype;
    private EntityArchetype m_TaxiRequestArchetype;
    private EntityArchetype m_HandleRequestArchetype;
    private EndFrameBarrier m_EndFrameBarrier;
    private CityConfigurationSystem m_CityConfigurationSystem;
    private TransportVehicleSelectData m_TransportVehicleSelectData;
    private TransportDepotAISystem.TypeHandle __TypeHandle;

    public override int GetUpdateInterval(SystemUpdatePhase phase) => 256;

    public override int GetUpdateOffset(SystemUpdatePhase phase) => 32;

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
      this.m_BuildingQuery = this.GetEntityQuery(ComponentType.ReadOnly<Game.Buildings.TransportDepot>(), ComponentType.ReadOnly<ServiceDispatch>(), ComponentType.ReadOnly<PrefabRef>(), ComponentType.Exclude<Temp>(), ComponentType.Exclude<Deleted>());
      // ISSUE: reference to a compiler-generated field
      this.m_VehiclePrefabQuery = this.GetEntityQuery(TransportVehicleSelectData.GetEntityQueryDesc());
      // ISSUE: reference to a compiler-generated field
      this.m_EventPrefabQuery = this.GetEntityQuery(ComponentType.ReadOnly<VehicleLaunchData>(), ComponentType.ReadOnly<PrefabData>(), ComponentType.Exclude<Locked>());
      // ISSUE: reference to a compiler-generated field
      this.m_TransportVehicleRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<ServiceRequest>(), ComponentType.ReadWrite<TransportVehicleRequest>(), ComponentType.ReadWrite<RequestGroup>());
      // ISSUE: reference to a compiler-generated field
      this.m_TaxiRequestArchetype = this.EntityManager.CreateArchetype(ComponentType.ReadWrite<ServiceRequest>(), ComponentType.ReadWrite<TaxiRequest>(), ComponentType.ReadWrite<RequestGroup>());
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
      this.m_TransportVehicleSelectData.PreUpdate((SystemBase) this, this.m_CityConfigurationSystem, this.m_VehiclePrefabQuery, Allocator.TempJob, out jobHandle1);
      JobHandle outJobHandle;
      // ISSUE: reference to a compiler-generated field
      NativeList<ArchetypeChunk> archetypeChunkListAsync = this.m_EventPrefabQuery.ToArchetypeChunkListAsync((AllocatorManager.AllocatorHandle) Allocator.TempJob, out outJobHandle);
      NativeQueue<TransportDepotAISystem.DepotAction> nativeQueue = new NativeQueue<TransportDepotAISystem.DepotAction>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathInformation_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_TransportLineData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_TransportDepotData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_Taxi_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_CargoTransport_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PublicTransport_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_Produced_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_Color_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_VehicleModel_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ServiceRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_TaxiRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_TransportVehicleRequest_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_TransportDepot_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_Locked_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_VehicleLaunchData_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_EventData_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Events_SpectatorSite_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Efficiency_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_OutsideConnection_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
      TransportDepotAISystem.TransportDepotTickJob jobData1 = new TransportDepotAISystem.TransportDepotTickJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_TransformType = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle,
        m_OutsideConnectionType = this.__TypeHandle.__Game_Objects_OutsideConnection_RO_ComponentTypeHandle,
        m_EfficiencyType = this.__TypeHandle.__Game_Buildings_Efficiency_RO_BufferTypeHandle,
        m_SpectatorSiteType = this.__TypeHandle.__Game_Events_SpectatorSite_RO_ComponentTypeHandle,
        m_PrefabRefType = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle,
        m_EventType = this.__TypeHandle.__Game_Prefabs_EventData_RO_ComponentTypeHandle,
        m_VehicleLaunchType = this.__TypeHandle.__Game_Prefabs_VehicleLaunchData_RO_ComponentTypeHandle,
        m_LockedType = this.__TypeHandle.__Game_Prefabs_Locked_RO_ComponentTypeHandle,
        m_InstalledUpgradeType = this.__TypeHandle.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle,
        m_OwnedVehicleType = this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle,
        m_TransportDepotType = this.__TypeHandle.__Game_Buildings_TransportDepot_RW_ComponentTypeHandle,
        m_ServiceRequestType = this.__TypeHandle.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle,
        m_TransportVehicleRequestData = this.__TypeHandle.__Game_Simulation_TransportVehicleRequest_RO_ComponentLookup,
        m_TaxiRequestData = this.__TypeHandle.__Game_Simulation_TaxiRequest_RO_ComponentLookup,
        m_ServiceRequestData = this.__TypeHandle.__Game_Simulation_ServiceRequest_RO_ComponentLookup,
        m_VehicleModelData = this.__TypeHandle.__Game_Routes_VehicleModel_RO_ComponentLookup,
        m_RouteColorData = this.__TypeHandle.__Game_Routes_Color_RO_ComponentLookup,
        m_ProducedData = this.__TypeHandle.__Game_Vehicles_Produced_RO_ComponentLookup,
        m_PublicTransportData = this.__TypeHandle.__Game_Vehicles_PublicTransport_RO_ComponentLookup,
        m_CargoTransportData = this.__TypeHandle.__Game_Vehicles_CargoTransport_RO_ComponentLookup,
        m_TaxiData = this.__TypeHandle.__Game_Vehicles_Taxi_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_PrefabTransportDepotData = this.__TypeHandle.__Game_Prefabs_TransportDepotData_RO_ComponentLookup,
        m_PrefabTransportLineData = this.__TypeHandle.__Game_Prefabs_TransportLineData_RO_ComponentLookup,
        m_PathInformationData = this.__TypeHandle.__Game_Pathfind_PathInformation_RO_ComponentLookup,
        m_PathElements = this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup,
        m_ActivityLocationElements = this.__TypeHandle.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup,
        m_RandomSeed = RandomSeed.Next(),
        m_TransportVehicleRequestArchetype = this.m_TransportVehicleRequestArchetype,
        m_TaxiRequestArchetype = this.m_TaxiRequestArchetype,
        m_HandleRequestArchetype = this.m_HandleRequestArchetype,
        m_TransportVehicleSelectData = this.m_TransportVehicleSelectData,
        m_EventPrefabChunks = archetypeChunkListAsync,
        m_CommandBuffer = this.m_EndFrameBarrier.CreateCommandBuffer().AsParallelWriter(),
        m_ActionQueue = nativeQueue.AsParallelWriter()
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_Taxi_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_CargoTransport_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PublicTransport_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      TransportDepotAISystem.TransportDepotActionJob jobData2 = new TransportDepotAISystem.TransportDepotActionJob()
      {
        m_PublicTransportData = this.__TypeHandle.__Game_Vehicles_PublicTransport_RW_ComponentLookup,
        m_CargoTransportData = this.__TypeHandle.__Game_Vehicles_CargoTransport_RW_ComponentLookup,
        m_TaxiData = this.__TypeHandle.__Game_Vehicles_Taxi_RW_ComponentLookup,
        m_ActionQueue = nativeQueue
      };
      // ISSUE: reference to a compiler-generated field
      JobHandle jobHandle2 = jobData1.ScheduleParallel<TransportDepotAISystem.TransportDepotTickJob>(this.m_BuildingQuery, JobHandle.CombineDependencies(this.Dependency, jobHandle1, outJobHandle));
      JobHandle dependsOn = jobHandle2;
      JobHandle inputDeps = jobData2.Schedule<TransportDepotAISystem.TransportDepotActionJob>(dependsOn);
      archetypeChunkListAsync.Dispose(jobHandle2);
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
    public TransportDepotAISystem()
    {
    }

    private struct DepotAction
    {
      public Entity m_Entity;
      public bool m_Disabled;

      public static TransportDepotAISystem.DepotAction SetDisabled(Entity vehicle, bool disabled)
      {
        // ISSUE: object of a compiler-generated type is created
        return new TransportDepotAISystem.DepotAction()
        {
          m_Entity = vehicle,
          m_Disabled = disabled
        };
      }
    }

    [BurstCompile]
    private struct TransportDepotTickJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<Game.Objects.Transform> m_TransformType;
      [ReadOnly]
      public ComponentTypeHandle<Game.Objects.OutsideConnection> m_OutsideConnectionType;
      [ReadOnly]
      public BufferTypeHandle<Efficiency> m_EfficiencyType;
      [ReadOnly]
      public ComponentTypeHandle<SpectatorSite> m_SpectatorSiteType;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> m_PrefabRefType;
      [ReadOnly]
      public ComponentTypeHandle<EventData> m_EventType;
      [ReadOnly]
      public ComponentTypeHandle<VehicleLaunchData> m_VehicleLaunchType;
      [ReadOnly]
      public ComponentTypeHandle<Locked> m_LockedType;
      [ReadOnly]
      public BufferTypeHandle<InstalledUpgrade> m_InstalledUpgradeType;
      [ReadOnly]
      public BufferTypeHandle<OwnedVehicle> m_OwnedVehicleType;
      public ComponentTypeHandle<Game.Buildings.TransportDepot> m_TransportDepotType;
      public BufferTypeHandle<ServiceDispatch> m_ServiceRequestType;
      [ReadOnly]
      public ComponentLookup<TransportVehicleRequest> m_TransportVehicleRequestData;
      [ReadOnly]
      public ComponentLookup<TaxiRequest> m_TaxiRequestData;
      [ReadOnly]
      public ComponentLookup<ServiceRequest> m_ServiceRequestData;
      [ReadOnly]
      public ComponentLookup<VehicleModel> m_VehicleModelData;
      [ReadOnly]
      public ComponentLookup<Game.Routes.Color> m_RouteColorData;
      [ReadOnly]
      public ComponentLookup<Produced> m_ProducedData;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.PublicTransport> m_PublicTransportData;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.CargoTransport> m_CargoTransportData;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.Taxi> m_TaxiData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public ComponentLookup<TransportDepotData> m_PrefabTransportDepotData;
      [ReadOnly]
      public ComponentLookup<TransportLineData> m_PrefabTransportLineData;
      [ReadOnly]
      public ComponentLookup<PathInformation> m_PathInformationData;
      [ReadOnly]
      public BufferLookup<PathElement> m_PathElements;
      [ReadOnly]
      public BufferLookup<ActivityLocationElement> m_ActivityLocationElements;
      [ReadOnly]
      public RandomSeed m_RandomSeed;
      [ReadOnly]
      public EntityArchetype m_TransportVehicleRequestArchetype;
      [ReadOnly]
      public EntityArchetype m_TaxiRequestArchetype;
      [ReadOnly]
      public EntityArchetype m_HandleRequestArchetype;
      [ReadOnly]
      public TransportVehicleSelectData m_TransportVehicleSelectData;
      [ReadOnly]
      public NativeList<ArchetypeChunk> m_EventPrefabChunks;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;
      public NativeQueue<TransportDepotAISystem.DepotAction>.ParallelWriter m_ActionQueue;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Game.Objects.Transform> nativeArray2 = chunk.GetNativeArray<Game.Objects.Transform>(ref this.m_TransformType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<PrefabRef> nativeArray3 = chunk.GetNativeArray<PrefabRef>(ref this.m_PrefabRefType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Game.Buildings.TransportDepot> nativeArray4 = chunk.GetNativeArray<Game.Buildings.TransportDepot>(ref this.m_TransportDepotType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Efficiency> bufferAccessor1 = chunk.GetBufferAccessor<Efficiency>(ref this.m_EfficiencyType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<InstalledUpgrade> bufferAccessor2 = chunk.GetBufferAccessor<InstalledUpgrade>(ref this.m_InstalledUpgradeType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<OwnedVehicle> bufferAccessor3 = chunk.GetBufferAccessor<OwnedVehicle>(ref this.m_OwnedVehicleType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<ServiceDispatch> bufferAccessor4 = chunk.GetBufferAccessor<ServiceDispatch>(ref this.m_ServiceRequestType);
        // ISSUE: reference to a compiler-generated field
        bool isOutsideConnection = chunk.Has<Game.Objects.OutsideConnection>(ref this.m_OutsideConnectionType);
        // ISSUE: reference to a compiler-generated field
        bool isSpectatorSite = chunk.Has<SpectatorSite>(ref this.m_SpectatorSiteType);
        // ISSUE: reference to a compiler-generated field
        Unity.Mathematics.Random random = this.m_RandomSeed.GetRandom(unfilteredChunkIndex);
        for (int index = 0; index < nativeArray1.Length; ++index)
        {
          Entity entity = nativeArray1[index];
          Game.Objects.Transform transform = nativeArray2[index];
          PrefabRef prefabRef = nativeArray3[index];
          Game.Buildings.TransportDepot transportDepot = nativeArray4[index];
          DynamicBuffer<OwnedVehicle> vehicles = bufferAccessor3[index];
          DynamicBuffer<ServiceDispatch> dispatches = bufferAccessor4[index];
          TransportDepotData result = new TransportDepotData();
          // ISSUE: reference to a compiler-generated field
          if (this.m_PrefabTransportDepotData.HasComponent(prefabRef.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            result = this.m_PrefabTransportDepotData[prefabRef.m_Prefab];
          }
          if (bufferAccessor2.Length != 0)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            UpgradeUtils.CombineStats<TransportDepotData>(ref result, bufferAccessor2[index], ref this.m_PrefabRefData, ref this.m_PrefabTransportDepotData);
          }
          float efficiency = BuildingUtils.GetEfficiency(bufferAccessor1, index);
          float immediateEfficiency = BuildingUtils.GetImmediateEfficiency(bufferAccessor1, index);
          // ISSUE: reference to a compiler-generated method
          this.Tick(unfilteredChunkIndex, ref random, entity, transform, prefabRef, ref transportDepot, result, vehicles, dispatches, efficiency, immediateEfficiency, isOutsideConnection, isSpectatorSite);
          nativeArray4[index] = transportDepot;
        }
      }

      private void Tick(
        int jobIndex,
        ref Unity.Mathematics.Random random,
        Entity entity,
        Game.Objects.Transform transform,
        PrefabRef prefabRef,
        ref Game.Buildings.TransportDepot transportDepot,
        TransportDepotData prefabTransportDepotData,
        DynamicBuffer<OwnedVehicle> vehicles,
        DynamicBuffer<ServiceDispatch> dispatches,
        float efficiency,
        float immediateEfficiency,
        bool isOutsideConnection,
        bool isSpectatorSite)
      {
        int vehicleCapacity1 = BuildingUtils.GetVehicleCapacity(efficiency, prefabTransportDepotData.m_VehicleCapacity);
        int vehicleCapacity2 = BuildingUtils.GetVehicleCapacity(immediateEfficiency, prefabTransportDepotData.m_VehicleCapacity);
        int num1 = vehicleCapacity1;
        Entity entity1 = Entity.Null;
        for (int index = 0; index < vehicles.Length; ++index)
        {
          Entity vehicle = vehicles[index].m_Vehicle;
          Game.Vehicles.PublicTransport componentData1;
          // ISSUE: reference to a compiler-generated field
          if (this.m_PublicTransportData.TryGetComponent(vehicle, out componentData1))
          {
            bool disabled = --vehicleCapacity2 < 0;
            if ((componentData1.m_State & PublicTransportFlags.Disabled) > (PublicTransportFlags) 0 != disabled)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.m_ActionQueue.Enqueue(TransportDepotAISystem.DepotAction.SetDisabled(vehicle, disabled));
            }
          }
          else
          {
            Game.Vehicles.CargoTransport componentData2;
            // ISSUE: reference to a compiler-generated field
            if (this.m_CargoTransportData.TryGetComponent(vehicle, out componentData2))
            {
              bool disabled = --vehicleCapacity2 < 0;
              if ((componentData2.m_State & CargoTransportFlags.Disabled) > (CargoTransportFlags) 0 != disabled)
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated method
                this.m_ActionQueue.Enqueue(TransportDepotAISystem.DepotAction.SetDisabled(vehicle, disabled));
              }
            }
            else
            {
              Game.Vehicles.Taxi componentData3;
              // ISSUE: reference to a compiler-generated field
              if (this.m_TaxiData.TryGetComponent(vehicle, out componentData3))
              {
                bool disabled = --vehicleCapacity2 < 0;
                if ((componentData3.m_State & TaxiFlags.Disabled) > (TaxiFlags) 0 != disabled)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated method
                  this.m_ActionQueue.Enqueue(TransportDepotAISystem.DepotAction.SetDisabled(vehicle, disabled));
                }
              }
              else
                continue;
            }
          }
          --num1;
          // ISSUE: reference to a compiler-generated field
          if (this.m_ProducedData.HasComponent(vehicle))
            entity1 = vehicle;
        }
        if ((double) prefabTransportDepotData.m_MaintenanceDuration > 0.0)
        {
          float num2 = (float) (256.0 / (262144.0 * (double) prefabTransportDepotData.m_MaintenanceDuration)) * efficiency;
          transportDepot.m_MaintenanceRequirement = math.max(0.0f, transportDepot.m_MaintenanceRequirement - num2);
          num1 -= Mathf.CeilToInt(transportDepot.m_MaintenanceRequirement - 1f / 1000f);
        }
        if ((double) prefabTransportDepotData.m_ProductionDuration > 0.0)
        {
          float productionState = (float) (256.0 / (262144.0 * (double) prefabTransportDepotData.m_ProductionDuration)) * efficiency;
          if ((double) productionState > 0.0)
          {
            if (entity1 != Entity.Null)
            {
              // ISSUE: reference to a compiler-generated field
              Produced component = this.m_ProducedData[entity1];
              if ((double) component.m_Completed < 1.0)
              {
                component.m_Completed = math.min(1f, component.m_Completed + productionState);
                // ISSUE: reference to a compiler-generated field
                this.m_CommandBuffer.SetComponent<Produced>(jobIndex, entity1, component);
              }
              if ((double) component.m_Completed == 1.0 && !isSpectatorSite)
              {
                // ISSUE: reference to a compiler-generated method
                this.TryCreateLaunchEvent(jobIndex, entity, prefabTransportDepotData);
              }
            }
            else if (num1 > 0 && !isSpectatorSite)
            {
              // ISSUE: reference to a compiler-generated method
              this.SpawnVehicle(jobIndex, ref random, entity, Entity.Null, transform, prefabRef, ref transportDepot, prefabTransportDepotData, productionState);
              --num1;
            }
          }
        }
        int index1 = 0;
        bool flag = false;
        while (index1 < dispatches.Length)
        {
          Entity request = dispatches[index1].m_Request;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_TransportVehicleRequestData.HasComponent(request) || this.m_TaxiRequestData.HasComponent(request))
          {
            if (num1 > 0)
            {
              if (!flag)
              {
                // ISSUE: reference to a compiler-generated method
                flag = this.SpawnVehicle(jobIndex, ref random, entity, request, transform, prefabRef, ref transportDepot, prefabTransportDepotData, 0.0f);
                dispatches.RemoveAt(index1);
              }
              if (flag)
                --num1;
            }
            else
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
        transportDepot.m_AvailableVehicles = (byte) math.clamp(num1, 0, (int) byte.MaxValue);
        if (num1 > 0)
        {
          transportDepot.m_Flags |= TransportDepotFlags.HasAvailableVehicles;
          // ISSUE: reference to a compiler-generated method
          this.RequestTargetIfNeeded(jobIndex, entity, ref transportDepot, prefabTransportDepotData, num1, vehicleCapacity1, isOutsideConnection);
        }
        else
          transportDepot.m_Flags &= ~TransportDepotFlags.HasAvailableVehicles;
        if (prefabTransportDepotData.m_DispatchCenter && (double) efficiency > 1.0 / 1000.0)
          transportDepot.m_Flags |= TransportDepotFlags.HasDispatchCenter;
        else
          transportDepot.m_Flags &= ~TransportDepotFlags.HasDispatchCenter;
      }

      private void RequestTargetIfNeeded(
        int jobIndex,
        Entity entity,
        ref Game.Buildings.TransportDepot transportDepot,
        TransportDepotData prefabTransportDepotData,
        int availableVehicles,
        int vehicleCapacity,
        bool isOutsideConnection)
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_ServiceRequestData.HasComponent(transportDepot.m_TargetRequest))
          return;
        if (prefabTransportDepotData.m_TransportType == TransportType.Taxi)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity entity1 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_TaxiRequestArchetype);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<ServiceRequest>(jobIndex, entity1, new ServiceRequest(true));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<TaxiRequest>(jobIndex, entity1, new TaxiRequest(entity, Entity.Null, Entity.Null, isOutsideConnection ? TaxiRequestType.Outside : TaxiRequestType.None, availableVehicles));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<RequestGroup>(jobIndex, entity1, new RequestGroup(16U));
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity entity2 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_TransportVehicleRequestArchetype);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<ServiceRequest>(jobIndex, entity2, new ServiceRequest(true));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<TransportVehicleRequest>(jobIndex, entity2, new TransportVehicleRequest(entity, (float) availableVehicles / (float) vehicleCapacity));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<RequestGroup>(jobIndex, entity2, new RequestGroup(8U));
        }
      }

      private bool TryCreateLaunchEvent(
        int jobIndex,
        Entity entity,
        TransportDepotData prefabTransportDepotData)
      {
        // ISSUE: reference to a compiler-generated field
        for (int index1 = 0; index1 < this.m_EventPrefabChunks.Length; ++index1)
        {
          // ISSUE: reference to a compiler-generated field
          ArchetypeChunk eventPrefabChunk = this.m_EventPrefabChunks[index1];
          // ISSUE: reference to a compiler-generated field
          NativeArray<Entity> nativeArray1 = eventPrefabChunk.GetNativeArray(this.m_EntityType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<EventData> nativeArray2 = eventPrefabChunk.GetNativeArray<EventData>(ref this.m_EventType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<VehicleLaunchData> nativeArray3 = eventPrefabChunk.GetNativeArray<VehicleLaunchData>(ref this.m_VehicleLaunchType);
          // ISSUE: reference to a compiler-generated field
          EnabledMask enabledMask = eventPrefabChunk.GetEnabledMask<Locked>(ref this.m_LockedType);
          for (int index2 = 0; index2 < nativeArray3.Length; ++index2)
          {
            if ((!enabledMask.EnableBit.IsValid || !enabledMask[index2]) && nativeArray3[index2].m_TransportType == prefabTransportDepotData.m_TransportType)
            {
              Entity prefab = nativeArray1[index2];
              EventData eventData = nativeArray2[index2];
              // ISSUE: reference to a compiler-generated field
              Entity entity1 = this.m_CommandBuffer.CreateEntity(jobIndex, eventData.m_Archetype);
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetComponent<PrefabRef>(jobIndex, entity1, new PrefabRef(prefab));
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetBuffer<TargetElement>(jobIndex, entity1).Add(new TargetElement(entity));
              return true;
            }
          }
        }
        return false;
      }

      private bool SpawnVehicle(
        int jobIndex,
        ref Unity.Mathematics.Random random,
        Entity entity,
        Entity request,
        Game.Objects.Transform transform,
        PrefabRef prefabRef,
        ref Game.Buildings.TransportDepot transportDepot,
        TransportDepotData prefabTransportDepotData,
        float productionState)
      {
        Entity entity1 = Entity.Null;
        Entity destination = Entity.Null;
        Entity source = Entity.Null;
        Entity primaryPrefab = Entity.Null;
        Entity secondaryPrefab = Entity.Null;
        PublicTransportPurpose publicTransportPurpose = (PublicTransportPurpose) 0;
        Resource cargoResources = Resource.NoResource;
        int2 passengerCapacity = (int2) 0;
        int2 cargoCapacity = (int2) 0;
        TaxiRequestType taxiRequestType = TaxiRequestType.None;
        if ((double) productionState == 0.0)
        {
          // ISSUE: reference to a compiler-generated field
          if (this.m_TransportVehicleRequestData.HasComponent(request))
          {
            // ISSUE: reference to a compiler-generated field
            entity1 = this.m_TransportVehicleRequestData[request].m_Route;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            if (this.m_TaxiRequestData.HasComponent(request))
            {
              // ISSUE: reference to a compiler-generated field
              TaxiRequest taxiRequest = this.m_TaxiRequestData[request];
              entity1 = taxiRequest.m_Seeker;
              taxiRequestType = taxiRequest.m_Type;
              passengerCapacity = new int2(1, int.MaxValue);
            }
          }
          // ISSUE: reference to a compiler-generated field
          if (!this.m_PrefabRefData.HasComponent(entity1))
            return false;
          // ISSUE: reference to a compiler-generated field
          PrefabRef prefabRef1 = this.m_PrefabRefData[entity1];
          // ISSUE: reference to a compiler-generated field
          if (this.m_PrefabTransportLineData.HasComponent(prefabRef1.m_Prefab))
          {
            // ISSUE: reference to a compiler-generated field
            TransportLineData transportLineData = this.m_PrefabTransportLineData[prefabRef1.m_Prefab];
            publicTransportPurpose = transportLineData.m_PassengerTransport ? PublicTransportPurpose.TransportLine : (PublicTransportPurpose) 0;
            cargoResources = transportLineData.m_CargoTransport ? Resource.Food : Resource.NoResource;
            passengerCapacity = transportLineData.m_PassengerTransport ? new int2(1, int.MaxValue) : (int2) 0;
            cargoCapacity = transportLineData.m_CargoTransport ? new int2(1, int.MaxValue) : (int2) 0;
          }
          // ISSUE: reference to a compiler-generated field
          if (!this.m_PathInformationData.HasComponent(request))
            return false;
          // ISSUE: reference to a compiler-generated field
          destination = this.m_PathInformationData[request].m_Destination;
          // ISSUE: reference to a compiler-generated field
          if (!this.m_PrefabRefData.HasComponent(destination))
            return false;
          VehicleModel componentData;
          // ISSUE: reference to a compiler-generated field
          if (this.m_VehicleModelData.TryGetComponent(entity1, out componentData))
          {
            primaryPrefab = componentData.m_PrimaryPrefab;
            secondaryPrefab = componentData.m_SecondaryPrefab;
          }
          source = entity;
        }
        else
        {
          DynamicBuffer<ActivityLocationElement> bufferData;
          // ISSUE: reference to a compiler-generated field
          if (this.m_ActivityLocationElements.TryGetBuffer(prefabRef.m_Prefab, out bufferData))
          {
            ActivityMask activityMask = new ActivityMask(ActivityType.Producing);
            for (int index = 0; index < bufferData.Length; ++index)
            {
              ActivityLocationElement activityLocationElement = bufferData[index];
              if (((int) activityLocationElement.m_ActivityMask.m_Mask & (int) activityMask.m_Mask) != 0)
                transform = ObjectUtils.LocalToWorld(transform, activityLocationElement.m_Position, activityLocationElement.m_Rotation);
            }
          }
          publicTransportPurpose = PublicTransportPurpose.Other;
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        Entity vehicle = this.m_TransportVehicleSelectData.CreateVehicle(this.m_CommandBuffer, jobIndex, ref random, transform, source, primaryPrefab, secondaryPrefab, prefabTransportDepotData.m_TransportType, prefabTransportDepotData.m_EnergyTypes, publicTransportPurpose, cargoResources, ref passengerCapacity, ref cargoCapacity);
        if (vehicle == Entity.Null)
          return false;
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.SetComponent<Game.Common.Target>(jobIndex, vehicle, new Game.Common.Target(destination));
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.AddComponent<Owner>(jobIndex, vehicle, new Owner(entity));
        if ((double) productionState > 0.0)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.RemoveComponent<Moving>(jobIndex, vehicle);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.RemoveComponent<TransformFrame>(jobIndex, vehicle);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.RemoveComponent<InterpolatedTransform>(jobIndex, vehicle);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.RemoveComponent<Swaying>(jobIndex, vehicle);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.AddComponent<Produced>(jobIndex, vehicle, new Produced(productionState));
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.AddComponent<Stopped>(jobIndex, vehicle, new Stopped());
        }
        else
        {
          bool flag = taxiRequestType == TaxiRequestType.Customer || taxiRequestType == TaxiRequestType.Outside;
          if (flag)
          {
            if (prefabTransportDepotData.m_TransportType == TransportType.Taxi)
            {
              TaxiFlags flags = TaxiFlags.Dispatched;
              if (taxiRequestType == TaxiRequestType.Outside)
                flags |= TaxiFlags.FromOutside;
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetComponent<Game.Vehicles.Taxi>(jobIndex, vehicle, new Game.Vehicles.Taxi(flags));
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetBuffer<ServiceDispatch>(jobIndex, vehicle).Add(new ServiceDispatch(request));
            }
          }
          else if (entity1 != Entity.Null)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_CommandBuffer.AddComponent<CurrentRoute>(jobIndex, vehicle, new CurrentRoute(entity1));
            Game.Routes.Color componentData;
            // ISSUE: reference to a compiler-generated field
            if (this.m_RouteColorData.TryGetComponent(entity1, out componentData))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.AddComponent<Game.Routes.Color>(jobIndex, vehicle, componentData);
            }
            if (publicTransportPurpose != (PublicTransportPurpose) 0)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetComponent<Game.Vehicles.PublicTransport>(jobIndex, vehicle, new Game.Vehicles.PublicTransport()
              {
                m_State = PublicTransportFlags.EnRoute
              });
            }
            if (cargoResources != Resource.NoResource)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetComponent<Game.Vehicles.CargoTransport>(jobIndex, vehicle, new Game.Vehicles.CargoTransport()
              {
                m_State = CargoTransportFlags.EnRoute
              });
            }
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity entity2 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_HandleRequestArchetype);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<HandleRequest>(jobIndex, entity2, new HandleRequest(request, vehicle, !flag));
        }
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
            if (prefabTransportDepotData.m_TransportType != TransportType.Taxi)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.SetComponent<PathInformation>(jobIndex, vehicle, this.m_PathInformationData[request]);
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        if (this.m_ServiceRequestData.HasComponent(transportDepot.m_TargetRequest))
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          Entity entity3 = this.m_CommandBuffer.CreateEntity(jobIndex, this.m_HandleRequestArchetype);
          // ISSUE: reference to a compiler-generated field
          this.m_CommandBuffer.SetComponent<HandleRequest>(jobIndex, entity3, new HandleRequest(transportDepot.m_TargetRequest, Entity.Null, true));
        }
        return true;
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
    private struct TransportDepotActionJob : IJob
    {
      public ComponentLookup<Game.Vehicles.PublicTransport> m_PublicTransportData;
      public ComponentLookup<Game.Vehicles.CargoTransport> m_CargoTransportData;
      public ComponentLookup<Game.Vehicles.Taxi> m_TaxiData;
      public NativeQueue<TransportDepotAISystem.DepotAction> m_ActionQueue;

      public void Execute()
      {
        // ISSUE: variable of a compiler-generated type
        TransportDepotAISystem.DepotAction depotAction;
        // ISSUE: reference to a compiler-generated field
        while (this.m_ActionQueue.TryDequeue(out depotAction))
        {
          Game.Vehicles.PublicTransport componentData1;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_PublicTransportData.TryGetComponent(depotAction.m_Entity, out componentData1))
          {
            // ISSUE: reference to a compiler-generated field
            if (depotAction.m_Disabled)
              componentData1.m_State |= PublicTransportFlags.AbandonRoute | PublicTransportFlags.Disabled;
            else
              componentData1.m_State &= ~PublicTransportFlags.Disabled;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_PublicTransportData[depotAction.m_Entity] = componentData1;
          }
          Game.Vehicles.CargoTransport componentData2;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_CargoTransportData.TryGetComponent(depotAction.m_Entity, out componentData2))
          {
            // ISSUE: reference to a compiler-generated field
            if (depotAction.m_Disabled)
              componentData2.m_State |= CargoTransportFlags.AbandonRoute | CargoTransportFlags.Disabled;
            else
              componentData2.m_State &= ~CargoTransportFlags.Disabled;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_CargoTransportData[depotAction.m_Entity] = componentData2;
          }
          Game.Vehicles.Taxi componentData3;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_TaxiData.TryGetComponent(depotAction.m_Entity, out componentData3))
          {
            // ISSUE: reference to a compiler-generated field
            if (depotAction.m_Disabled)
              componentData3.m_State |= TaxiFlags.Disabled;
            else
              componentData3.m_State &= ~TaxiFlags.Disabled;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            this.m_TaxiData[depotAction.m_Entity] = componentData3;
          }
        }
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Game.Objects.Transform> __Game_Objects_Transform_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Game.Objects.OutsideConnection> __Game_Objects_OutsideConnection_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<Efficiency> __Game_Buildings_Efficiency_RO_BufferTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<SpectatorSite> __Game_Events_SpectatorSite_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<EventData> __Game_Prefabs_EventData_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<VehicleLaunchData> __Game_Prefabs_VehicleLaunchData_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Locked> __Game_Prefabs_Locked_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<InstalledUpgrade> __Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<OwnedVehicle> __Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle;
      public ComponentTypeHandle<Game.Buildings.TransportDepot> __Game_Buildings_TransportDepot_RW_ComponentTypeHandle;
      public BufferTypeHandle<ServiceDispatch> __Game_Simulation_ServiceDispatch_RW_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<TransportVehicleRequest> __Game_Simulation_TransportVehicleRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<TaxiRequest> __Game_Simulation_TaxiRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ServiceRequest> __Game_Simulation_ServiceRequest_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<VehicleModel> __Game_Routes_VehicleModel_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Routes.Color> __Game_Routes_Color_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Produced> __Game_Vehicles_Produced_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.PublicTransport> __Game_Vehicles_PublicTransport_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.CargoTransport> __Game_Vehicles_CargoTransport_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Vehicles.Taxi> __Game_Vehicles_Taxi_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<TransportDepotData> __Game_Prefabs_TransportDepotData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<TransportLineData> __Game_Prefabs_TransportLineData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PathInformation> __Game_Pathfind_PathInformation_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<PathElement> __Game_Pathfind_PathElement_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<ActivityLocationElement> __Game_Prefabs_ActivityLocationElement_RO_BufferLookup;
      public ComponentLookup<Game.Vehicles.PublicTransport> __Game_Vehicles_PublicTransport_RW_ComponentLookup;
      public ComponentLookup<Game.Vehicles.CargoTransport> __Game_Vehicles_CargoTransport_RW_ComponentLookup;
      public ComponentLookup<Game.Vehicles.Taxi> __Game_Vehicles_Taxi_RW_ComponentLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Objects.Transform>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_OutsideConnection_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Objects.OutsideConnection>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Efficiency_RO_BufferTypeHandle = state.GetBufferTypeHandle<Efficiency>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Events_SpectatorSite_RO_ComponentTypeHandle = state.GetComponentTypeHandle<SpectatorSite>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_EventData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<EventData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_VehicleLaunchData_RO_ComponentTypeHandle = state.GetComponentTypeHandle<VehicleLaunchData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_Locked_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Locked>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_InstalledUpgrade_RO_BufferTypeHandle = state.GetBufferTypeHandle<InstalledUpgrade>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_OwnedVehicle_RO_BufferTypeHandle = state.GetBufferTypeHandle<OwnedVehicle>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_TransportDepot_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Buildings.TransportDepot>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ServiceDispatch_RW_BufferTypeHandle = state.GetBufferTypeHandle<ServiceDispatch>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_TransportVehicleRequest_RO_ComponentLookup = state.GetComponentLookup<TransportVehicleRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_TaxiRequest_RO_ComponentLookup = state.GetComponentLookup<TaxiRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ServiceRequest_RO_ComponentLookup = state.GetComponentLookup<ServiceRequest>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_VehicleModel_RO_ComponentLookup = state.GetComponentLookup<VehicleModel>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_Color_RO_ComponentLookup = state.GetComponentLookup<Game.Routes.Color>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Produced_RO_ComponentLookup = state.GetComponentLookup<Produced>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PublicTransport_RO_ComponentLookup = state.GetComponentLookup<Game.Vehicles.PublicTransport>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_CargoTransport_RO_ComponentLookup = state.GetComponentLookup<Game.Vehicles.CargoTransport>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Taxi_RO_ComponentLookup = state.GetComponentLookup<Game.Vehicles.Taxi>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_TransportDepotData_RO_ComponentLookup = state.GetComponentLookup<TransportDepotData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_TransportLineData_RO_ComponentLookup = state.GetComponentLookup<TransportLineData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathInformation_RO_ComponentLookup = state.GetComponentLookup<PathInformation>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathElement_RO_BufferLookup = state.GetBufferLookup<PathElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup = state.GetBufferLookup<ActivityLocationElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PublicTransport_RW_ComponentLookup = state.GetComponentLookup<Game.Vehicles.PublicTransport>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_CargoTransport_RW_ComponentLookup = state.GetComponentLookup<Game.Vehicles.CargoTransport>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Taxi_RW_ComponentLookup = state.GetComponentLookup<Game.Vehicles.Taxi>();
      }
    }
  }
}

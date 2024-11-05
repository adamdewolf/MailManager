// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.ReferencesSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Colossal.Mathematics;
using Game.Citizens;
using Game.Common;
using Game.Net;
using Game.Objects;
using Game.Prefabs;
using Game.Routes;
using Game.Tools;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Vehicles
{
  [CompilerGenerated]
  public class ReferencesSystem : GameSystemBase
  {
    private ModificationBarrier5 m_ModificationBarrier;
    private Game.Objects.SearchSystem m_SearchSystem;
    private EntityQuery m_CarQuery;
    private EntityQuery m_VehicleQuery;
    private EntityQuery m_LayoutQuery;
    private ReferencesSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_ModificationBarrier = this.World.GetOrCreateSystemManaged<ModificationBarrier5>();
      // ISSUE: reference to a compiler-generated field
      this.m_SearchSystem = this.World.GetOrCreateSystemManaged<Game.Objects.SearchSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_CarQuery = this.GetEntityQuery(ComponentType.ReadOnly<Created>(), ComponentType.ReadOnly<Vehicle>(), ComponentType.ReadWrite<CarCurrentLane>(), ComponentType.Exclude<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.m_VehicleQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[1]
        {
          ComponentType.ReadOnly<Vehicle>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Created>(),
          ComponentType.ReadOnly<Deleted>()
        },
        None = new ComponentType[1]
        {
          ComponentType.ReadOnly<Temp>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.m_LayoutQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[1]
        {
          ComponentType.ReadOnly<Deleted>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<LayoutElement>(),
          ComponentType.ReadOnly<Controller>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.RequireAnyForUpdate(this.m_CarQuery, this.m_VehicleQuery, this.m_LayoutQuery);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      JobHandle jobHandle1 = new JobHandle();
      // ISSUE: reference to a compiler-generated field
      if (!this.m_CarQuery.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_SubLane_RO_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_MasterLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_CarLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_CarCurrentLane_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
        // ISSUE: reference to a compiler-generated field
        jobHandle1 = new ReferencesSystem.InitializeCurrentLaneJob()
        {
          m_TransformType = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle,
          m_CarCurrentLaneType = this.__TypeHandle.__Game_Vehicles_CarCurrentLane_RW_ComponentTypeHandle,
          m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
          m_CarLaneData = this.__TypeHandle.__Game_Net_CarLane_RO_ComponentLookup,
          m_MasterLaneData = this.__TypeHandle.__Game_Net_MasterLane_RO_ComponentLookup,
          m_CurveData = this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup,
          m_LaneData = this.__TypeHandle.__Game_Net_SubLane_RO_BufferLookup
        }.ScheduleParallel<ReferencesSystem.InitializeCurrentLaneJob>(this.m_CarQuery, this.Dependency);
      }
      JobHandle job1 = new JobHandle();
      // ISSUE: reference to a compiler-generated field
      if (!this.m_LayoutQuery.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_LayoutElement_RW_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_Controller_RW_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Deleted_RO_ComponentLookup.Update(ref this.CheckedStateRef);
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
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated field
        job1 = new ReferencesSystem.UpdateLayoutReferencesJob()
        {
          m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
          m_DeletedData = this.__TypeHandle.__Game_Common_Deleted_RO_ComponentLookup,
          m_ControllerData = this.__TypeHandle.__Game_Vehicles_Controller_RW_ComponentLookup,
          m_Layouts = this.__TypeHandle.__Game_Vehicles_LayoutElement_RW_BufferLookup
        }.Schedule<ReferencesSystem.UpdateLayoutReferencesJob>(this.m_LayoutQuery, this.Dependency);
      }
      JobHandle jobHandle2 = new JobHandle();
      // ISSUE: reference to a compiler-generated field
      if (!this.m_VehicleQuery.IsEmptyIgnoreFilter)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Routes_RouteVehicle_RW_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_LaneObject_RW_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_GuestVehicle_RW_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RW_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Buildings_TransportDepot_RW_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Citizens_CarKeeper_RW_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_SubLane_RO_BufferLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Prefabs_TaxiData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Prefabs_CargoTransportVehicleData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_GarageLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_ParkingLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_MasterLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_SlaveLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Net_CarLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Objects_BlockedLane_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Routes_CurrentRoute_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_Odometer_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Objects_Moving_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_ParkedCar_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_TrainCurrentLane_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_AircraftCurrentLane_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_WatercraftCurrentLane_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_CarTrailerLane_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_CarCurrentLane_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_DeliveryTruck_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Vehicles_PersonalCar_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Target_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Owner_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Created_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
        JobHandle dependencies;
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
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: reference to a compiler-generated field
        jobHandle2 = new ReferencesSystem.UpdateVehicleReferencesJob()
        {
          m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
          m_CreatedType = this.__TypeHandle.__Game_Common_Created_RO_ComponentTypeHandle,
          m_OwnerType = this.__TypeHandle.__Game_Common_Owner_RO_ComponentTypeHandle,
          m_TargetType = this.__TypeHandle.__Game_Common_Target_RO_ComponentTypeHandle,
          m_PersonalCarType = this.__TypeHandle.__Game_Vehicles_PersonalCar_RO_ComponentTypeHandle,
          m_DeliveryTruckType = this.__TypeHandle.__Game_Vehicles_DeliveryTruck_RO_ComponentTypeHandle,
          m_CarCurrentLaneType = this.__TypeHandle.__Game_Vehicles_CarCurrentLane_RO_ComponentTypeHandle,
          m_CarTrailerLaneType = this.__TypeHandle.__Game_Vehicles_CarTrailerLane_RO_ComponentTypeHandle,
          m_WatercraftCurrentLaneType = this.__TypeHandle.__Game_Vehicles_WatercraftCurrentLane_RO_ComponentTypeHandle,
          m_AircraftCurrentLaneType = this.__TypeHandle.__Game_Vehicles_AircraftCurrentLane_RO_ComponentTypeHandle,
          m_TrainCurrentLaneType = this.__TypeHandle.__Game_Vehicles_TrainCurrentLane_RO_ComponentTypeHandle,
          m_ParkedCarType = this.__TypeHandle.__Game_Vehicles_ParkedCar_RO_ComponentTypeHandle,
          m_TransformType = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentTypeHandle,
          m_MovingType = this.__TypeHandle.__Game_Objects_Moving_RO_ComponentTypeHandle,
          m_OdometerType = this.__TypeHandle.__Game_Vehicles_Odometer_RO_ComponentTypeHandle,
          m_CurrentRouteType = this.__TypeHandle.__Game_Routes_CurrentRoute_RO_ComponentTypeHandle,
          m_PrefabRefType = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle,
          m_BlockedLaneType = this.__TypeHandle.__Game_Objects_BlockedLane_RO_BufferTypeHandle,
          m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
          m_CarLaneData = this.__TypeHandle.__Game_Net_CarLane_RO_ComponentLookup,
          m_SlaveLaneData = this.__TypeHandle.__Game_Net_SlaveLane_RO_ComponentLookup,
          m_MasterLaneData = this.__TypeHandle.__Game_Net_MasterLane_RO_ComponentLookup,
          m_ParkingLaneData = this.__TypeHandle.__Game_Net_ParkingLane_RO_ComponentLookup,
          m_GarageLaneData = this.__TypeHandle.__Game_Net_GarageLane_RO_ComponentLookup,
          m_ObjectGeometryData = this.__TypeHandle.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup,
          m_PublicTransportVehicleData = this.__TypeHandle.__Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup,
          m_CargoTransportVehicleData = this.__TypeHandle.__Game_Prefabs_CargoTransportVehicleData_RO_ComponentLookup,
          m_TaxiData = this.__TypeHandle.__Game_Prefabs_TaxiData_RO_ComponentLookup,
          m_SubLanes = this.__TypeHandle.__Game_Net_SubLane_RO_BufferLookup,
          m_CarKeepers = this.__TypeHandle.__Game_Citizens_CarKeeper_RW_ComponentLookup,
          m_TransportDepots = this.__TypeHandle.__Game_Buildings_TransportDepot_RW_ComponentLookup,
          m_OwnedVehicles = this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RW_BufferLookup,
          m_GuestVehicles = this.__TypeHandle.__Game_Vehicles_GuestVehicle_RW_BufferLookup,
          m_LaneObjects = this.__TypeHandle.__Game_Net_LaneObject_RW_BufferLookup,
          m_RouteVehicles = this.__TypeHandle.__Game_Routes_RouteVehicle_RW_BufferLookup,
          m_SearchTree = this.m_SearchSystem.GetMovingSearchTree(false, out dependencies),
          m_CommandBuffer = this.m_ModificationBarrier.CreateCommandBuffer()
        }.Schedule<ReferencesSystem.UpdateVehicleReferencesJob>(this.m_VehicleQuery, JobHandle.CombineDependencies(this.Dependency, jobHandle1, dependencies));
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_SearchSystem.AddMovingSearchTreeWriter(jobHandle2);
        // ISSUE: reference to a compiler-generated field
        this.m_ModificationBarrier.AddJobHandleForProducer(jobHandle2);
      }
      this.Dependency = JobHandle.CombineDependencies(jobHandle1, job1, jobHandle2);
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
    public struct InitializeCurrentLaneJob : IJobChunk
    {
      [ReadOnly]
      public ComponentTypeHandle<Transform> m_TransformType;
      public ComponentTypeHandle<CarCurrentLane> m_CarCurrentLaneType;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      [ReadOnly]
      public ComponentLookup<Game.Net.CarLane> m_CarLaneData;
      [ReadOnly]
      public ComponentLookup<MasterLane> m_MasterLaneData;
      [ReadOnly]
      public ComponentLookup<Curve> m_CurveData;
      [ReadOnly]
      public BufferLookup<Game.Net.SubLane> m_LaneData;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Transform> nativeArray1 = chunk.GetNativeArray<Transform>(ref this.m_TransformType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<CarCurrentLane> nativeArray2 = chunk.GetNativeArray<CarCurrentLane>(ref this.m_CarCurrentLaneType);
        for (int index1 = 0; index1 < nativeArray2.Length; ++index1)
        {
          Transform transform = nativeArray1[index1];
          CarCurrentLane carCurrentLane = nativeArray2[index1];
          // ISSUE: reference to a compiler-generated field
          if (this.m_CarLaneData.HasComponent(carCurrentLane.m_Lane))
          {
            // ISSUE: reference to a compiler-generated field
            Game.Net.CarLane carLane1 = this.m_CarLaneData[carCurrentLane.m_Lane];
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            DynamicBuffer<Game.Net.SubLane> dynamicBuffer = this.m_LaneData[this.m_OwnerData[carCurrentLane.m_Lane].m_Owner];
            carCurrentLane.m_Lane = Entity.Null;
            float3 curvePosition = carCurrentLane.m_CurvePosition;
            float num1 = float.MaxValue;
            for (int index2 = 0; index2 < dynamicBuffer.Length; ++index2)
            {
              Entity subLane = dynamicBuffer[index2].m_SubLane;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (this.m_CarLaneData.HasComponent(subLane) && !this.m_MasterLaneData.HasComponent(subLane))
              {
                // ISSUE: reference to a compiler-generated field
                Game.Net.CarLane carLane2 = this.m_CarLaneData[subLane];
                if ((int) carLane2.m_CarriagewayGroup == (int) carLane1.m_CarriagewayGroup)
                {
                  float3 float3 = math.select(curvePosition, 1f - curvePosition.zyx, ((carLane1.m_Flags ^ carLane2.m_Flags) & Game.Net.CarLaneFlags.Invert) > ~(Game.Net.CarLaneFlags.Unsafe | Game.Net.CarLaneFlags.UTurnLeft | Game.Net.CarLaneFlags.Invert | Game.Net.CarLaneFlags.SideConnection | Game.Net.CarLaneFlags.TurnLeft | Game.Net.CarLaneFlags.TurnRight | Game.Net.CarLaneFlags.LevelCrossing | Game.Net.CarLaneFlags.Twoway | Game.Net.CarLaneFlags.IsSecured | Game.Net.CarLaneFlags.Runway | Game.Net.CarLaneFlags.Yield | Game.Net.CarLaneFlags.Stop | Game.Net.CarLaneFlags.ForbidCombustionEngines | Game.Net.CarLaneFlags.ForbidTransitTraffic | Game.Net.CarLaneFlags.ForbidHeavyTraffic | Game.Net.CarLaneFlags.PublicOnly | Game.Net.CarLaneFlags.Highway | Game.Net.CarLaneFlags.UTurnRight | Game.Net.CarLaneFlags.GentleTurnLeft | Game.Net.CarLaneFlags.GentleTurnRight | Game.Net.CarLaneFlags.Forward | Game.Net.CarLaneFlags.Approach | Game.Net.CarLaneFlags.Roundabout | Game.Net.CarLaneFlags.RightLimit | Game.Net.CarLaneFlags.LeftLimit | Game.Net.CarLaneFlags.ForbidPassing | Game.Net.CarLaneFlags.RightOfWay | Game.Net.CarLaneFlags.TrafficLights | Game.Net.CarLaneFlags.ParkingLeft | Game.Net.CarLaneFlags.ParkingRight | Game.Net.CarLaneFlags.Forbidden | Game.Net.CarLaneFlags.AllowEnter));
                  // ISSUE: reference to a compiler-generated field
                  float num2 = math.lengthsq(MathUtils.Position(this.m_CurveData[subLane].m_Bezier, float3.x) - transform.m_Position);
                  if ((double) num2 < (double) num1)
                  {
                    carCurrentLane.m_Lane = subLane;
                    carCurrentLane.m_CurvePosition = float3;
                    num1 = num2;
                  }
                }
              }
            }
          }
          nativeArray2[index1] = carCurrentLane;
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
    private struct UpdateLayoutReferencesJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentLookup<Deleted> m_DeletedData;
      public ComponentLookup<Controller> m_ControllerData;
      public BufferLookup<LayoutElement> m_Layouts;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray = chunk.GetNativeArray(this.m_EntityType);
        for (int index1 = 0; index1 < nativeArray.Length; ++index1)
        {
          Entity entity = nativeArray[index1];
          // ISSUE: reference to a compiler-generated field
          if (this.m_Layouts.HasBuffer(entity))
          {
            // ISSUE: reference to a compiler-generated field
            DynamicBuffer<LayoutElement> layout = this.m_Layouts[entity];
            for (int index2 = 0; index2 < layout.Length; ++index2)
            {
              Entity vehicle = layout[index2].m_Vehicle;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (vehicle != entity && vehicle != Entity.Null && !this.m_DeletedData.HasComponent(vehicle) && this.m_ControllerData.HasComponent(vehicle))
              {
                // ISSUE: reference to a compiler-generated field
                Controller controller = this.m_ControllerData[vehicle];
                if (controller.m_Controller == entity)
                {
                  controller.m_Controller = Entity.Null;
                  // ISSUE: reference to a compiler-generated field
                  this.m_ControllerData[vehicle] = controller;
                }
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          if (this.m_ControllerData.HasComponent(entity))
          {
            // ISSUE: reference to a compiler-generated field
            Controller controller = this.m_ControllerData[entity];
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (controller.m_Controller != entity && controller.m_Controller != Entity.Null && !this.m_DeletedData.HasComponent(controller.m_Controller) && this.m_Layouts.HasBuffer(controller.m_Controller))
            {
              // ISSUE: reference to a compiler-generated field
              CollectionUtils.RemoveValue<LayoutElement>(this.m_Layouts[controller.m_Controller], new LayoutElement(entity));
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
    private struct UpdateVehicleReferencesJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<Created> m_CreatedType;
      [ReadOnly]
      public ComponentTypeHandle<Owner> m_OwnerType;
      [ReadOnly]
      public ComponentTypeHandle<Target> m_TargetType;
      [ReadOnly]
      public ComponentTypeHandle<PersonalCar> m_PersonalCarType;
      [ReadOnly]
      public ComponentTypeHandle<DeliveryTruck> m_DeliveryTruckType;
      [ReadOnly]
      public ComponentTypeHandle<CarCurrentLane> m_CarCurrentLaneType;
      [ReadOnly]
      public ComponentTypeHandle<CarTrailerLane> m_CarTrailerLaneType;
      [ReadOnly]
      public ComponentTypeHandle<WatercraftCurrentLane> m_WatercraftCurrentLaneType;
      [ReadOnly]
      public ComponentTypeHandle<AircraftCurrentLane> m_AircraftCurrentLaneType;
      [ReadOnly]
      public ComponentTypeHandle<TrainCurrentLane> m_TrainCurrentLaneType;
      [ReadOnly]
      public ComponentTypeHandle<ParkedCar> m_ParkedCarType;
      [ReadOnly]
      public ComponentTypeHandle<Transform> m_TransformType;
      [ReadOnly]
      public ComponentTypeHandle<Moving> m_MovingType;
      [ReadOnly]
      public ComponentTypeHandle<Odometer> m_OdometerType;
      [ReadOnly]
      public ComponentTypeHandle<CurrentRoute> m_CurrentRouteType;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> m_PrefabRefType;
      [ReadOnly]
      public BufferTypeHandle<BlockedLane> m_BlockedLaneType;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      [ReadOnly]
      public ComponentLookup<Game.Net.CarLane> m_CarLaneData;
      [ReadOnly]
      public ComponentLookup<SlaveLane> m_SlaveLaneData;
      [ReadOnly]
      public ComponentLookup<MasterLane> m_MasterLaneData;
      [ReadOnly]
      public ComponentLookup<Game.Net.ParkingLane> m_ParkingLaneData;
      [ReadOnly]
      public ComponentLookup<GarageLane> m_GarageLaneData;
      [ReadOnly]
      public ComponentLookup<ObjectGeometryData> m_ObjectGeometryData;
      [ReadOnly]
      public ComponentLookup<PublicTransportVehicleData> m_PublicTransportVehicleData;
      [ReadOnly]
      public ComponentLookup<CargoTransportVehicleData> m_CargoTransportVehicleData;
      [ReadOnly]
      public ComponentLookup<TaxiData> m_TaxiData;
      [ReadOnly]
      public BufferLookup<Game.Net.SubLane> m_SubLanes;
      public ComponentLookup<CarKeeper> m_CarKeepers;
      public ComponentLookup<Game.Buildings.TransportDepot> m_TransportDepots;
      public BufferLookup<OwnedVehicle> m_OwnedVehicles;
      public BufferLookup<GuestVehicle> m_GuestVehicles;
      public BufferLookup<LaneObject> m_LaneObjects;
      public BufferLookup<RouteVehicle> m_RouteVehicles;
      public NativeQuadTree<Entity, QuadTreeBoundsXZ> m_SearchTree;
      public EntityCommandBuffer m_CommandBuffer;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        if (chunk.Has<Created>(ref this.m_CreatedType))
        {
          // ISSUE: reference to a compiler-generated field
          NativeArray<Transform> nativeArray2 = chunk.GetNativeArray<Transform>(ref this.m_TransformType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<PrefabRef> nativeArray3 = chunk.GetNativeArray<PrefabRef>(ref this.m_PrefabRefType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<Owner> nativeArray4 = chunk.GetNativeArray<Owner>(ref this.m_OwnerType);
          for (int index = 0; index < nativeArray4.Length; ++index)
          {
            Entity vehicle = nativeArray1[index];
            Owner owner = nativeArray4[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_OwnedVehicles.HasBuffer(owner.m_Owner))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_OwnedVehicles[owner.m_Owner].Add(new OwnedVehicle(vehicle));
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<PersonalCar> nativeArray5 = chunk.GetNativeArray<PersonalCar>(ref this.m_PersonalCarType);
          for (int index = 0; index < nativeArray5.Length; ++index)
          {
            Entity entity = nativeArray1[index];
            PersonalCar personalCar = nativeArray5[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_CarKeepers.HasComponent(personalCar.m_Keeper))
            {
              // ISSUE: reference to a compiler-generated field
              CarKeeper carKeeper = this.m_CarKeepers[personalCar.m_Keeper] with
              {
                m_Car = entity
              };
              // ISSUE: reference to a compiler-generated field
              this.m_CarKeepers[personalCar.m_Keeper] = carKeeper;
            }
          }
          // ISSUE: reference to a compiler-generated field
          if (chunk.Has<DeliveryTruck>(ref this.m_DeliveryTruckType))
          {
            // ISSUE: reference to a compiler-generated field
            NativeArray<Target> nativeArray6 = chunk.GetNativeArray<Target>(ref this.m_TargetType);
            for (int index = 0; index < nativeArray6.Length; ++index)
            {
              Entity vehicle = nativeArray1[index];
              Target target = nativeArray6[index];
              // ISSUE: reference to a compiler-generated field
              if (this.m_GuestVehicles.HasBuffer(target.m_Target))
              {
                // ISSUE: reference to a compiler-generated field
                this.m_GuestVehicles[target.m_Target].Add(new GuestVehicle(vehicle));
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<CarCurrentLane> nativeArray7 = chunk.GetNativeArray<CarCurrentLane>(ref this.m_CarCurrentLaneType);
          for (int index = 0; index < nativeArray7.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            CarCurrentLane carCurrentLane = nativeArray7[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carCurrentLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[carCurrentLane.m_Lane], laneObject, carCurrentLane.m_CurvePosition.xy);
            }
            else
            {
              Transform transform = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              ObjectGeometryData geometryData = this.m_ObjectGeometryData[nativeArray3[index].m_Prefab];
              Bounds3 bounds = ObjectUtils.CalculateBounds(transform.m_Position, transform.m_Rotation, geometryData);
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.Add(laneObject, new QuadTreeBoundsXZ(bounds));
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carCurrentLane.m_ChangeLane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[carCurrentLane.m_ChangeLane], laneObject, carCurrentLane.m_CurvePosition.xy);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<CarTrailerLane> nativeArray8 = chunk.GetNativeArray<CarTrailerLane>(ref this.m_CarTrailerLaneType);
          for (int index = 0; index < nativeArray8.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            CarTrailerLane carTrailerLane = nativeArray8[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carTrailerLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[carTrailerLane.m_Lane], laneObject, carTrailerLane.m_CurvePosition.xy);
            }
            else
            {
              Transform transform = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              ObjectGeometryData geometryData = this.m_ObjectGeometryData[nativeArray3[index].m_Prefab];
              Bounds3 bounds = ObjectUtils.CalculateBounds(transform.m_Position, transform.m_Rotation, geometryData);
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.Add(laneObject, new QuadTreeBoundsXZ(bounds));
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carTrailerLane.m_NextLane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[carTrailerLane.m_NextLane], laneObject, carTrailerLane.m_NextPosition.xy);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<WatercraftCurrentLane> nativeArray9 = chunk.GetNativeArray<WatercraftCurrentLane>(ref this.m_WatercraftCurrentLaneType);
          for (int index = 0; index < nativeArray9.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            WatercraftCurrentLane watercraftCurrentLane = nativeArray9[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(watercraftCurrentLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[watercraftCurrentLane.m_Lane], laneObject, watercraftCurrentLane.m_CurvePosition.xy);
            }
            else
            {
              Transform transform = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              ObjectGeometryData geometryData = this.m_ObjectGeometryData[nativeArray3[index].m_Prefab];
              Bounds3 bounds = ObjectUtils.CalculateBounds(transform.m_Position, transform.m_Rotation, geometryData);
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.Add(laneObject, new QuadTreeBoundsXZ(bounds));
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(watercraftCurrentLane.m_ChangeLane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[watercraftCurrentLane.m_ChangeLane], laneObject, watercraftCurrentLane.m_CurvePosition.xy);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<AircraftCurrentLane> nativeArray10 = chunk.GetNativeArray<AircraftCurrentLane>(ref this.m_AircraftCurrentLaneType);
          for (int index = 0; index < nativeArray10.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            AircraftCurrentLane aircraftCurrentLane = nativeArray10[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(aircraftCurrentLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[aircraftCurrentLane.m_Lane], laneObject, aircraftCurrentLane.m_CurvePosition.xy);
            }
            // ISSUE: reference to a compiler-generated field
            if (!this.m_LaneObjects.HasBuffer(aircraftCurrentLane.m_Lane) || (aircraftCurrentLane.m_LaneFlags & AircraftLaneFlags.Flying) != (AircraftLaneFlags) 0)
            {
              Transform transform = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              ObjectGeometryData geometryData = this.m_ObjectGeometryData[nativeArray3[index].m_Prefab];
              Bounds3 bounds = ObjectUtils.CalculateBounds(transform.m_Position, transform.m_Rotation, geometryData);
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.Add(laneObject, new QuadTreeBoundsXZ(bounds));
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<TrainCurrentLane> nativeArray11 = chunk.GetNativeArray<TrainCurrentLane>(ref this.m_TrainCurrentLaneType);
          for (int index = 0; index < nativeArray11.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            TrainCurrentLane trainCurrentLane = nativeArray11[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(trainCurrentLane.m_Front.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[trainCurrentLane.m_Front.m_Lane], laneObject, trainCurrentLane.m_Front.m_CurvePosition.yz);
            }
            // ISSUE: reference to a compiler-generated field
            if (trainCurrentLane.m_Rear.m_Lane != trainCurrentLane.m_Front.m_Lane && this.m_LaneObjects.HasBuffer(trainCurrentLane.m_Rear.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[trainCurrentLane.m_Rear.m_Lane], laneObject, trainCurrentLane.m_Rear.m_CurvePosition.yz);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<ParkedCar> nativeArray12 = chunk.GetNativeArray<ParkedCar>(ref this.m_ParkedCarType);
          for (int index = 0; index < nativeArray12.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            ParkedCar parkedCar = nativeArray12[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(parkedCar.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.AddLaneObject(this.m_LaneObjects[parkedCar.m_Lane], laneObject, (float2) parkedCar.m_CurvePosition);
            }
            else
            {
              Transform transform = nativeArray2[index];
              // ISSUE: reference to a compiler-generated field
              ObjectGeometryData geometryData = this.m_ObjectGeometryData[nativeArray3[index].m_Prefab];
              Bounds3 bounds = ObjectUtils.CalculateBounds(transform.m_Position, transform.m_Rotation, geometryData);
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.Add(laneObject, new QuadTreeBoundsXZ(bounds));
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<CurrentRoute> nativeArray13 = chunk.GetNativeArray<CurrentRoute>(ref this.m_CurrentRouteType);
          for (int index = 0; index < nativeArray13.Length; ++index)
          {
            Entity vehicle = nativeArray1[index];
            CurrentRoute currentRoute = nativeArray13[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_RouteVehicles.HasBuffer(currentRoute.m_Route))
            {
              // ISSUE: reference to a compiler-generated field
              this.m_RouteVehicles[currentRoute.m_Route].Add(new RouteVehicle(vehicle));
            }
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          bool flag = chunk.Has<Moving>(ref this.m_MovingType);
          // ISSUE: reference to a compiler-generated field
          NativeArray<Owner> nativeArray14 = chunk.GetNativeArray<Owner>(ref this.m_OwnerType);
          if (nativeArray14.Length != 0)
          {
            // ISSUE: reference to a compiler-generated field
            NativeArray<Odometer> nativeArray15 = chunk.GetNativeArray<Odometer>(ref this.m_OdometerType);
            // ISSUE: reference to a compiler-generated field
            NativeArray<PrefabRef> nativeArray16 = chunk.GetNativeArray<PrefabRef>(ref this.m_PrefabRefType);
            for (int index = 0; index < nativeArray14.Length; ++index)
            {
              Entity vehicle = nativeArray1[index];
              Owner owner = nativeArray14[index];
              // ISSUE: reference to a compiler-generated field
              if (this.m_OwnedVehicles.HasBuffer(owner.m_Owner))
              {
                // ISSUE: reference to a compiler-generated field
                CollectionUtils.RemoveValue<OwnedVehicle>(this.m_OwnedVehicles[owner.m_Owner], new OwnedVehicle(vehicle));
              }
              // ISSUE: reference to a compiler-generated field
              if (nativeArray15.Length != 0 && this.m_TransportDepots.HasComponent(owner.m_Owner))
              {
                Odometer odometer = nativeArray15[index];
                PrefabRef prefabRef = nativeArray16[index];
                // ISSUE: reference to a compiler-generated field
                Game.Buildings.TransportDepot transportDepot = this.m_TransportDepots[owner.m_Owner];
                // ISSUE: reference to a compiler-generated field
                if (this.m_PublicTransportVehicleData.HasComponent(prefabRef.m_Prefab))
                {
                  // ISSUE: reference to a compiler-generated field
                  PublicTransportVehicleData transportVehicleData = this.m_PublicTransportVehicleData[prefabRef.m_Prefab];
                  if ((double) transportVehicleData.m_MaintenanceRange > 0.10000000149011612)
                  {
                    transportDepot.m_MaintenanceRequirement += math.saturate(odometer.m_Distance / transportVehicleData.m_MaintenanceRange);
                    // ISSUE: reference to a compiler-generated field
                    this.m_TransportDepots[owner.m_Owner] = transportDepot;
                  }
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_CargoTransportVehicleData.HasComponent(prefabRef.m_Prefab))
                  {
                    // ISSUE: reference to a compiler-generated field
                    CargoTransportVehicleData transportVehicleData = this.m_CargoTransportVehicleData[prefabRef.m_Prefab];
                    if ((double) transportVehicleData.m_MaintenanceRange > 0.10000000149011612)
                    {
                      transportDepot.m_MaintenanceRequirement += math.saturate(odometer.m_Distance / transportVehicleData.m_MaintenanceRange);
                      // ISSUE: reference to a compiler-generated field
                      this.m_TransportDepots[owner.m_Owner] = transportDepot;
                    }
                  }
                  else
                  {
                    // ISSUE: reference to a compiler-generated field
                    if (this.m_TaxiData.HasComponent(prefabRef.m_Prefab))
                    {
                      // ISSUE: reference to a compiler-generated field
                      TaxiData taxiData = this.m_TaxiData[prefabRef.m_Prefab];
                      if ((double) taxiData.m_MaintenanceRange > 0.10000000149011612)
                      {
                        transportDepot.m_MaintenanceRequirement += math.saturate(odometer.m_Distance / taxiData.m_MaintenanceRange);
                        // ISSUE: reference to a compiler-generated field
                        this.m_TransportDepots[owner.m_Owner] = transportDepot;
                      }
                    }
                  }
                }
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<PersonalCar> nativeArray17 = chunk.GetNativeArray<PersonalCar>(ref this.m_PersonalCarType);
          for (int index = 0; index < nativeArray17.Length; ++index)
          {
            Entity entity = nativeArray1[index];
            PersonalCar personalCar = nativeArray17[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_CarKeepers.HasComponent(personalCar.m_Keeper))
            {
              // ISSUE: reference to a compiler-generated field
              CarKeeper carKeeper = this.m_CarKeepers[personalCar.m_Keeper];
              if (carKeeper.m_Car == entity)
              {
                carKeeper.m_Car = Entity.Null;
                // ISSUE: reference to a compiler-generated field
                this.m_CarKeepers[personalCar.m_Keeper] = carKeeper;
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          if (chunk.Has<DeliveryTruck>(ref this.m_DeliveryTruckType))
          {
            // ISSUE: reference to a compiler-generated field
            NativeArray<Target> nativeArray18 = chunk.GetNativeArray<Target>(ref this.m_TargetType);
            for (int index = 0; index < nativeArray18.Length; ++index)
            {
              Entity vehicle = nativeArray1[index];
              Target target = nativeArray18[index];
              // ISSUE: reference to a compiler-generated field
              if (this.m_GuestVehicles.HasBuffer(target.m_Target))
              {
                // ISSUE: reference to a compiler-generated field
                CollectionUtils.RemoveValue<GuestVehicle>(this.m_GuestVehicles[target.m_Target], new GuestVehicle(vehicle));
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<CarCurrentLane> nativeArray19 = chunk.GetNativeArray<CarCurrentLane>(ref this.m_CarCurrentLaneType);
          for (int index = 0; index < nativeArray19.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            CarCurrentLane carCurrentLane = nativeArray19[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carCurrentLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[carCurrentLane.m_Lane], laneObject);
              // ISSUE: reference to a compiler-generated field
              if (!flag && this.m_CarLaneData.HasComponent(carCurrentLane.m_Lane))
              {
                // ISSUE: reference to a compiler-generated method
                this.AddLaneComponent<PathfindUpdated>(carCurrentLane.m_Lane, new PathfindUpdated());
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.TryRemove(laneObject);
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carCurrentLane.m_ChangeLane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[carCurrentLane.m_ChangeLane], laneObject);
              // ISSUE: reference to a compiler-generated field
              if (!flag && this.m_CarLaneData.HasComponent(carCurrentLane.m_ChangeLane))
              {
                // ISSUE: reference to a compiler-generated method
                this.AddLaneComponent<PathfindUpdated>(carCurrentLane.m_ChangeLane, new PathfindUpdated());
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<CarTrailerLane> nativeArray20 = chunk.GetNativeArray<CarTrailerLane>(ref this.m_CarTrailerLaneType);
          for (int index = 0; index < nativeArray20.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            CarTrailerLane carTrailerLane = nativeArray20[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carTrailerLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[carTrailerLane.m_Lane], laneObject);
              // ISSUE: reference to a compiler-generated field
              if (!flag && this.m_CarLaneData.HasComponent(carTrailerLane.m_Lane))
              {
                // ISSUE: reference to a compiler-generated method
                this.AddLaneComponent<PathfindUpdated>(carTrailerLane.m_Lane, new PathfindUpdated());
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.TryRemove(laneObject);
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(carTrailerLane.m_NextLane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[carTrailerLane.m_NextLane], laneObject);
              // ISSUE: reference to a compiler-generated field
              if (!flag && this.m_CarLaneData.HasComponent(carTrailerLane.m_NextLane))
              {
                // ISSUE: reference to a compiler-generated method
                this.AddLaneComponent<PathfindUpdated>(carTrailerLane.m_NextLane, new PathfindUpdated());
              }
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<WatercraftCurrentLane> nativeArray21 = chunk.GetNativeArray<WatercraftCurrentLane>(ref this.m_WatercraftCurrentLaneType);
          for (int index = 0; index < nativeArray21.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            WatercraftCurrentLane watercraftCurrentLane = nativeArray21[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(watercraftCurrentLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[watercraftCurrentLane.m_Lane], laneObject);
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.TryRemove(laneObject);
            }
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(watercraftCurrentLane.m_ChangeLane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[watercraftCurrentLane.m_ChangeLane], laneObject);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<AircraftCurrentLane> nativeArray22 = chunk.GetNativeArray<AircraftCurrentLane>(ref this.m_AircraftCurrentLaneType);
          for (int index = 0; index < nativeArray22.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            AircraftCurrentLane aircraftCurrentLane = nativeArray22[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(aircraftCurrentLane.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[aircraftCurrentLane.m_Lane], laneObject);
            }
            // ISSUE: reference to a compiler-generated field
            if (!this.m_LaneObjects.HasBuffer(aircraftCurrentLane.m_Lane) || (aircraftCurrentLane.m_LaneFlags & AircraftLaneFlags.Flying) != (AircraftLaneFlags) 0)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.TryRemove(laneObject);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<TrainCurrentLane> nativeArray23 = chunk.GetNativeArray<TrainCurrentLane>(ref this.m_TrainCurrentLaneType);
          for (int index = 0; index < nativeArray23.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            TrainCurrentLane trainCurrentLane = nativeArray23[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(trainCurrentLane.m_Front.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[trainCurrentLane.m_Front.m_Lane], laneObject);
            }
            // ISSUE: reference to a compiler-generated field
            if (trainCurrentLane.m_Rear.m_Lane != trainCurrentLane.m_Front.m_Lane && this.m_LaneObjects.HasBuffer(trainCurrentLane.m_Rear.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[trainCurrentLane.m_Rear.m_Lane], laneObject);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<ParkedCar> nativeArray24 = chunk.GetNativeArray<ParkedCar>(ref this.m_ParkedCarType);
          for (int index = 0; index < nativeArray24.Length; ++index)
          {
            Entity laneObject = nativeArray1[index];
            ParkedCar parkedCar = nativeArray24[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_LaneObjects.HasBuffer(parkedCar.m_Lane))
            {
              // ISSUE: reference to a compiler-generated field
              NetUtils.RemoveLaneObject(this.m_LaneObjects[parkedCar.m_Lane], laneObject);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (this.m_ParkingLaneData.HasComponent(parkedCar.m_Lane) || this.m_GarageLaneData.HasComponent(parkedCar.m_Lane))
              {
                // ISSUE: reference to a compiler-generated method
                this.AddLaneComponent<PathfindUpdated>(parkedCar.m_Lane, new PathfindUpdated());
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              this.m_SearchTree.TryRemove(laneObject);
            }
          }
          // ISSUE: reference to a compiler-generated field
          NativeArray<CurrentRoute> nativeArray25 = chunk.GetNativeArray<CurrentRoute>(ref this.m_CurrentRouteType);
          for (int index = 0; index < nativeArray25.Length; ++index)
          {
            Entity vehicle = nativeArray1[index];
            CurrentRoute currentRoute = nativeArray25[index];
            // ISSUE: reference to a compiler-generated field
            if (this.m_RouteVehicles.HasBuffer(currentRoute.m_Route))
            {
              // ISSUE: reference to a compiler-generated field
              CollectionUtils.RemoveValue<RouteVehicle>(this.m_RouteVehicles[currentRoute.m_Route], new RouteVehicle(vehicle));
            }
          }
          // ISSUE: reference to a compiler-generated field
          BufferAccessor<BlockedLane> bufferAccessor = chunk.GetBufferAccessor<BlockedLane>(ref this.m_BlockedLaneType);
          for (int index1 = 0; index1 < bufferAccessor.Length; ++index1)
          {
            Entity laneObject = nativeArray1[index1];
            DynamicBuffer<BlockedLane> dynamicBuffer = bufferAccessor[index1];
            for (int index2 = 0; index2 < dynamicBuffer.Length; ++index2)
            {
              BlockedLane blockedLane = dynamicBuffer[index2];
              // ISSUE: reference to a compiler-generated field
              if (this.m_LaneObjects.HasBuffer(blockedLane.m_Lane))
              {
                // ISSUE: reference to a compiler-generated field
                NetUtils.RemoveLaneObject(this.m_LaneObjects[blockedLane.m_Lane], laneObject);
                // ISSUE: reference to a compiler-generated field
                if (!flag && this.m_CarLaneData.HasComponent(blockedLane.m_Lane))
                {
                  // ISSUE: reference to a compiler-generated method
                  this.AddLaneComponent<PathfindUpdated>(blockedLane.m_Lane, new PathfindUpdated());
                }
              }
            }
          }
        }
      }

      private void AddLaneComponent<T>(Entity lane, T component) where T : unmanaged, IComponentData
      {
        // ISSUE: reference to a compiler-generated field
        this.m_CommandBuffer.AddComponent<T>(lane, component);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!this.m_SlaveLaneData.HasComponent(lane) || !this.m_OwnerData.HasComponent(lane))
          return;
        // ISSUE: reference to a compiler-generated field
        uint group = this.m_SlaveLaneData[lane].m_Group;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        DynamicBuffer<Game.Net.SubLane> subLane1 = this.m_SubLanes[this.m_OwnerData[lane].m_Owner];
        for (int index = 0; index < subLane1.Length; ++index)
        {
          Entity subLane2 = subLane1[index].m_SubLane;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_MasterLaneData.HasComponent(subLane2) && (int) this.m_MasterLaneData[subLane2].m_Group == (int) group)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_CommandBuffer.AddComponent<T>(subLane2, component);
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
      public ComponentTypeHandle<Transform> __Game_Objects_Transform_RO_ComponentTypeHandle;
      public ComponentTypeHandle<CarCurrentLane> __Game_Vehicles_CarCurrentLane_RW_ComponentTypeHandle;
      [ReadOnly]
      public ComponentLookup<Owner> __Game_Common_Owner_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.CarLane> __Game_Net_CarLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<MasterLane> __Game_Net_MasterLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Curve> __Game_Net_Curve_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<Game.Net.SubLane> __Game_Net_SubLane_RO_BufferLookup;
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentLookup<Deleted> __Game_Common_Deleted_RO_ComponentLookup;
      public ComponentLookup<Controller> __Game_Vehicles_Controller_RW_ComponentLookup;
      public BufferLookup<LayoutElement> __Game_Vehicles_LayoutElement_RW_BufferLookup;
      [ReadOnly]
      public ComponentTypeHandle<Created> __Game_Common_Created_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Owner> __Game_Common_Owner_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Target> __Game_Common_Target_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PersonalCar> __Game_Vehicles_PersonalCar_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<DeliveryTruck> __Game_Vehicles_DeliveryTruck_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<CarCurrentLane> __Game_Vehicles_CarCurrentLane_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<CarTrailerLane> __Game_Vehicles_CarTrailerLane_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<WatercraftCurrentLane> __Game_Vehicles_WatercraftCurrentLane_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<AircraftCurrentLane> __Game_Vehicles_AircraftCurrentLane_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<TrainCurrentLane> __Game_Vehicles_TrainCurrentLane_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<ParkedCar> __Game_Vehicles_ParkedCar_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Moving> __Game_Objects_Moving_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Odometer> __Game_Vehicles_Odometer_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<CurrentRoute> __Game_Routes_CurrentRoute_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<BlockedLane> __Game_Objects_BlockedLane_RO_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<SlaveLane> __Game_Net_SlaveLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.ParkingLane> __Game_Net_ParkingLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<GarageLane> __Game_Net_GarageLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ObjectGeometryData> __Game_Prefabs_ObjectGeometryData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PublicTransportVehicleData> __Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<CargoTransportVehicleData> __Game_Prefabs_CargoTransportVehicleData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<TaxiData> __Game_Prefabs_TaxiData_RO_ComponentLookup;
      public ComponentLookup<CarKeeper> __Game_Citizens_CarKeeper_RW_ComponentLookup;
      public ComponentLookup<Game.Buildings.TransportDepot> __Game_Buildings_TransportDepot_RW_ComponentLookup;
      public BufferLookup<OwnedVehicle> __Game_Vehicles_OwnedVehicle_RW_BufferLookup;
      public BufferLookup<GuestVehicle> __Game_Vehicles_GuestVehicle_RW_BufferLookup;
      public BufferLookup<LaneObject> __Game_Net_LaneObject_RW_BufferLookup;
      public BufferLookup<RouteVehicle> __Game_Routes_RouteVehicle_RW_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Transform>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_CarCurrentLane_RW_ComponentTypeHandle = state.GetComponentTypeHandle<CarCurrentLane>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentLookup = state.GetComponentLookup<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_CarLane_RO_ComponentLookup = state.GetComponentLookup<Game.Net.CarLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_MasterLane_RO_ComponentLookup = state.GetComponentLookup<MasterLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Curve_RO_ComponentLookup = state.GetComponentLookup<Curve>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_SubLane_RO_BufferLookup = state.GetBufferLookup<Game.Net.SubLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Deleted_RO_ComponentLookup = state.GetComponentLookup<Deleted>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Controller_RW_ComponentLookup = state.GetComponentLookup<Controller>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_LayoutElement_RW_BufferLookup = state.GetBufferLookup<LayoutElement>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Created_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Created>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Target_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Target>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PersonalCar_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PersonalCar>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_DeliveryTruck_RO_ComponentTypeHandle = state.GetComponentTypeHandle<DeliveryTruck>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_CarCurrentLane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CarCurrentLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_CarTrailerLane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CarTrailerLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_WatercraftCurrentLane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<WatercraftCurrentLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_AircraftCurrentLane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<AircraftCurrentLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_TrainCurrentLane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<TrainCurrentLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_ParkedCar_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ParkedCar>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Moving_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Moving>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_Odometer_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Odometer>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_CurrentRoute_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CurrentRoute>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_BlockedLane_RO_BufferTypeHandle = state.GetBufferTypeHandle<BlockedLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_SlaveLane_RO_ComponentLookup = state.GetComponentLookup<SlaveLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_ParkingLane_RO_ComponentLookup = state.GetComponentLookup<Game.Net.ParkingLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_GarageLane_RO_ComponentLookup = state.GetComponentLookup<GarageLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup = state.GetComponentLookup<ObjectGeometryData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PublicTransportVehicleData_RO_ComponentLookup = state.GetComponentLookup<PublicTransportVehicleData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_CargoTransportVehicleData_RO_ComponentLookup = state.GetComponentLookup<CargoTransportVehicleData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_TaxiData_RO_ComponentLookup = state.GetComponentLookup<TaxiData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_CarKeeper_RW_ComponentLookup = state.GetComponentLookup<CarKeeper>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_TransportDepot_RW_ComponentLookup = state.GetComponentLookup<Game.Buildings.TransportDepot>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_OwnedVehicle_RW_BufferLookup = state.GetBufferLookup<OwnedVehicle>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_GuestVehicle_RW_BufferLookup = state.GetBufferLookup<GuestVehicle>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_LaneObject_RW_BufferLookup = state.GetBufferLookup<LaneObject>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_RouteVehicle_RW_BufferLookup = state.GetBufferLookup<RouteVehicle>();
      }
    }
  }
}

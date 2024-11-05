// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.FixParkingLocationSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Colossal.Entities;
using Colossal.Mathematics;
using Game.Buildings;
using Game.Citizens;
using Game.Common;
using Game.Net;
using Game.Objects;
using Game.Prefabs;
using Game.Tools;
using System;
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
  public class FixParkingLocationSystem : GameSystemBase
  {
    private ModificationBarrier5 m_ModificationBarrier;
    private Game.Objects.SearchSystem m_ObjectSearchSystem;
    private Game.Net.SearchSystem m_NetSearchSystem;
    private EntityQuery m_FixQuery;
    private FixParkingLocationSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_ModificationBarrier = this.World.GetOrCreateSystemManaged<ModificationBarrier5>();
      // ISSUE: reference to a compiler-generated field
      this.m_ObjectSearchSystem = this.World.GetOrCreateSystemManaged<Game.Objects.SearchSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_NetSearchSystem = this.World.GetOrCreateSystemManaged<Game.Net.SearchSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_FixQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[1]
        {
          ComponentType.ReadOnly<Deleted>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Game.Net.ParkingLane>(),
          ComponentType.ReadOnly<Game.Net.ConnectionLane>()
        },
        None = new ComponentType[1]
        {
          ComponentType.ReadOnly<Temp>()
        }
      }, new EntityQueryDesc()
      {
        All = new ComponentType[1]
        {
          ComponentType.ReadOnly<Updated>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Game.Net.ParkingLane>(),
          ComponentType.ReadOnly<FixParkingLocation>()
        },
        None = new ComponentType[1]
        {
          ComponentType.ReadOnly<Temp>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_FixQuery);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      NativeQueue<Entity> nativeQueue = new NativeQueue<Entity>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Transform_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_ParkedCar_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_LaneObject_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Curve_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_ConnectionLane_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_FixParkingLocation_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
      JobHandle dependencies1;
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
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      FixParkingLocationSystem.CollectParkedCarsJob jobData = new FixParkingLocationSystem.CollectParkedCarsJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_FixParkingLocationType = this.__TypeHandle.__Game_Vehicles_FixParkingLocation_RO_ComponentTypeHandle,
        m_ConnectionLaneType = this.__TypeHandle.__Game_Net_ConnectionLane_RO_ComponentTypeHandle,
        m_OwnerType = this.__TypeHandle.__Game_Common_Owner_RO_ComponentTypeHandle,
        m_CurveType = this.__TypeHandle.__Game_Net_Curve_RO_ComponentTypeHandle,
        m_LaneObjectType = this.__TypeHandle.__Game_Net_LaneObject_RW_BufferTypeHandle,
        m_ParkedCarData = this.__TypeHandle.__Game_Vehicles_ParkedCar_RO_ComponentLookup,
        m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
        m_TransformData = this.__TypeHandle.__Game_Objects_Transform_RO_ComponentLookup,
        m_BuildingData = this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_ActivityLocations = this.__TypeHandle.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup,
        m_MovingObjectSearchTree = this.m_ObjectSearchSystem.GetMovingSearchTree(true, out dependencies1),
        m_VehicleQueue = nativeQueue.AsParallelWriter()
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RW_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_LaneObject_RW_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_CarKeeper_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_PersonalCar_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_ParkedCar_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Transform_RW_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_LaneOverlap_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_SubLane_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_LayoutElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ParkingLaneData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Objects_Unspawned_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_FixParkingLocation_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Updated_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Deleted_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_ConnectionLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_ParkingLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      JobHandle dependencies2;
      JobHandle dependencies3;
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
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: reference to a compiler-generated field
      JobHandle jobHandle = new FixParkingLocationSystem.FixParkingLocationJob()
      {
        m_ParkingLaneData = this.__TypeHandle.__Game_Net_ParkingLane_RO_ComponentLookup,
        m_ConnectionLaneData = this.__TypeHandle.__Game_Net_ConnectionLane_RO_ComponentLookup,
        m_CurveData = this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup,
        m_DeletedData = this.__TypeHandle.__Game_Common_Deleted_RO_ComponentLookup,
        m_UpdatedData = this.__TypeHandle.__Game_Common_Updated_RO_ComponentLookup,
        m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
        m_FixParkingLocationData = this.__TypeHandle.__Game_Vehicles_FixParkingLocation_RO_ComponentLookup,
        m_UnspawnedData = this.__TypeHandle.__Game_Objects_Unspawned_RO_ComponentLookup,
        m_BuildingData = this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_PrefabParkingLaneData = this.__TypeHandle.__Game_Prefabs_ParkingLaneData_RO_ComponentLookup,
        m_PrefabObjectGeometryData = this.__TypeHandle.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup,
        m_LayoutElements = this.__TypeHandle.__Game_Vehicles_LayoutElement_RO_BufferLookup,
        m_Lanes = this.__TypeHandle.__Game_Net_SubLane_RO_BufferLookup,
        m_LaneOverlaps = this.__TypeHandle.__Game_Net_LaneOverlap_RO_BufferLookup,
        m_ActivityLocations = this.__TypeHandle.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup,
        m_TransformData = this.__TypeHandle.__Game_Objects_Transform_RW_ComponentLookup,
        m_ParkedCarData = this.__TypeHandle.__Game_Vehicles_ParkedCar_RW_ComponentLookup,
        m_PersonalCarData = this.__TypeHandle.__Game_Vehicles_PersonalCar_RW_ComponentLookup,
        m_CarKeeperData = this.__TypeHandle.__Game_Citizens_CarKeeper_RW_ComponentLookup,
        m_LaneObjects = this.__TypeHandle.__Game_Net_LaneObject_RW_BufferLookup,
        m_OwnedVehicles = this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RW_BufferLookup,
        m_RandomSeed = RandomSeed.Next(),
        m_NetSearchTree = this.m_NetSearchSystem.GetNetSearchTree(true, out dependencies2),
        m_VehicleQueue = nativeQueue,
        m_MovingObjectSearchTree = this.m_ObjectSearchSystem.GetMovingSearchTree(false, out dependencies3),
        m_CommandBuffer = this.m_ModificationBarrier.CreateCommandBuffer()
      }.Schedule<FixParkingLocationSystem.FixParkingLocationJob>(JobHandle.CombineDependencies(jobData.ScheduleParallel<FixParkingLocationSystem.CollectParkedCarsJob>(this.m_FixQuery, JobHandle.CombineDependencies(this.Dependency, dependencies1)), dependencies2, dependencies3));
      nativeQueue.Dispose(jobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_NetSearchSystem.AddNetSearchTreeReader(jobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_ObjectSearchSystem.AddMovingSearchTreeWriter(jobHandle);
      // ISSUE: reference to a compiler-generated field
      this.m_ModificationBarrier.AddJobHandleForProducer(jobHandle);
      this.Dependency = jobHandle;
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
    public FixParkingLocationSystem()
    {
    }

    [BurstCompile]
    private struct CollectParkedCarsJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<FixParkingLocation> m_FixParkingLocationType;
      [ReadOnly]
      public ComponentTypeHandle<Game.Net.ConnectionLane> m_ConnectionLaneType;
      [ReadOnly]
      public ComponentTypeHandle<Owner> m_OwnerType;
      [ReadOnly]
      public ComponentTypeHandle<Curve> m_CurveType;
      public BufferTypeHandle<LaneObject> m_LaneObjectType;
      [ReadOnly]
      public ComponentLookup<ParkedCar> m_ParkedCarData;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      [ReadOnly]
      public ComponentLookup<Transform> m_TransformData;
      [ReadOnly]
      public ComponentLookup<Building> m_BuildingData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public BufferLookup<ActivityLocationElement> m_ActivityLocations;
      [ReadOnly]
      public NativeQuadTree<Entity, QuadTreeBoundsXZ> m_MovingObjectSearchTree;
      public NativeQueue<Entity>.ParallelWriter m_VehicleQueue;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        if (chunk.Has<FixParkingLocation>(ref this.m_FixParkingLocationType))
        {
          // ISSUE: reference to a compiler-generated field
          NativeArray<Entity> nativeArray = chunk.GetNativeArray(this.m_EntityType);
          for (int index = 0; index < nativeArray.Length; ++index)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_VehicleQueue.Enqueue(nativeArray[index]);
          }
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          BufferAccessor<LaneObject> bufferAccessor = chunk.GetBufferAccessor<LaneObject>(ref this.m_LaneObjectType);
          if (bufferAccessor.Length != 0)
          {
            for (int index1 = 0; index1 < bufferAccessor.Length; ++index1)
            {
              DynamicBuffer<LaneObject> dynamicBuffer = bufferAccessor[index1];
              int index2 = 0;
              for (int index3 = 0; index3 < dynamicBuffer.Length; ++index3)
              {
                LaneObject laneObject = dynamicBuffer[index3];
                // ISSUE: reference to a compiler-generated field
                if (this.m_ParkedCarData.HasComponent(laneObject.m_LaneObject))
                {
                  // ISSUE: reference to a compiler-generated field
                  this.m_VehicleQueue.Enqueue(laneObject.m_LaneObject);
                }
                else
                  dynamicBuffer[index2++] = laneObject;
              }
              if (index2 != 0)
              {
                if (index2 < dynamicBuffer.Length)
                  dynamicBuffer.RemoveRange(index2, dynamicBuffer.Length - index2);
              }
              else
                dynamicBuffer.Clear();
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            NativeArray<Game.Net.ConnectionLane> nativeArray1 = chunk.GetNativeArray<Game.Net.ConnectionLane>(ref this.m_ConnectionLaneType);
            if (nativeArray1.Length == 0)
              return;
            // ISSUE: reference to a compiler-generated field
            NativeArray<Entity> nativeArray2 = chunk.GetNativeArray(this.m_EntityType);
            // ISSUE: reference to a compiler-generated field
            NativeArray<Curve> nativeArray3 = chunk.GetNativeArray<Curve>(ref this.m_CurveType);
            // ISSUE: reference to a compiler-generated field
            NativeArray<Owner> nativeArray4 = chunk.GetNativeArray<Owner>(ref this.m_OwnerType);
            for (int index = 0; index < nativeArray1.Length; ++index)
            {
              Game.Net.ConnectionLane connectionLane = nativeArray1[index];
              if ((connectionLane.m_Flags & ConnectionLaneFlags.Parking) != (ConnectionLaneFlags) 0)
              {
                Entity entity = nativeArray2[index];
                Curve curve = nativeArray3[index];
                Owner owner = nativeArray4[index];
                // ISSUE: reference to a compiler-generated method
                this.AddVehicles(entity, owner, curve, connectionLane);
              }
            }
          }
        }
      }

      private void AddVehicles(
        Entity entity,
        Owner owner,
        Curve curve,
        Game.Net.ConnectionLane connectionLane)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        FixParkingLocationSystem.CollectParkedCarsJob.AddVehiclesIterator iterator = new FixParkingLocationSystem.CollectParkedCarsJob.AddVehiclesIterator()
        {
          m_Lane = entity,
          m_Bounds = VehicleUtils.GetConnectionParkingBounds(connectionLane, curve.m_Bezier),
          m_VehicleQueue = this.m_VehicleQueue,
          m_ParkedCarData = this.m_ParkedCarData
        };
        Owner owner1 = owner;
        // ISSUE: reference to a compiler-generated field
        while (this.m_OwnerData.HasComponent(owner1.m_Owner))
        {
          // ISSUE: reference to a compiler-generated field
          owner1 = this.m_OwnerData[owner1.m_Owner];
        }
        DynamicBuffer<ActivityLocationElement> bufferData;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_BuildingData.HasComponent(owner1.m_Owner) && this.m_ActivityLocations.TryGetBuffer(this.m_PrefabRefData[owner1.m_Owner].m_Prefab, out bufferData))
        {
          // ISSUE: reference to a compiler-generated field
          Transform transform = this.m_TransformData[owner1.m_Owner];
          ActivityMask activityMask = new ActivityMask(ActivityType.GarageSpot);
          for (int index = 0; index < bufferData.Length; ++index)
          {
            ActivityLocationElement activityLocationElement = bufferData[index];
            if (((int) activityLocationElement.m_ActivityMask.m_Mask & (int) activityMask.m_Mask) != 0)
            {
              float3 world = ObjectUtils.LocalToWorld(transform, activityLocationElement.m_Position);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              iterator.m_Bounds.min = math.min(iterator.m_Bounds.min, world - 1f);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              iterator.m_Bounds.max = math.max(iterator.m_Bounds.max, world + 1f);
            }
          }
        }
        // ISSUE: reference to a compiler-generated field
        this.m_MovingObjectSearchTree.Iterate<FixParkingLocationSystem.CollectParkedCarsJob.AddVehiclesIterator>(ref iterator);
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

      private struct AddVehiclesIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public Entity m_Lane;
        public Bounds3 m_Bounds;
        public NativeQueue<Entity>.ParallelWriter m_VehicleQueue;
        public ComponentLookup<ParkedCar> m_ParkedCarData;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity entity)
        {
          ParkedCar componentData;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_ParkedCarData.TryGetComponent(entity, out componentData) || !(componentData.m_Lane == this.m_Lane))
            return;
          // ISSUE: reference to a compiler-generated field
          this.m_VehicleQueue.Enqueue(entity);
        }
      }
    }

    [BurstCompile]
    private struct FixParkingLocationJob : IJob
    {
      [ReadOnly]
      public ComponentLookup<Game.Net.ParkingLane> m_ParkingLaneData;
      [ReadOnly]
      public ComponentLookup<Game.Net.ConnectionLane> m_ConnectionLaneData;
      [ReadOnly]
      public ComponentLookup<Curve> m_CurveData;
      [ReadOnly]
      public ComponentLookup<Deleted> m_DeletedData;
      [ReadOnly]
      public ComponentLookup<Updated> m_UpdatedData;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      [ReadOnly]
      public ComponentLookup<FixParkingLocation> m_FixParkingLocationData;
      [ReadOnly]
      public ComponentLookup<Unspawned> m_UnspawnedData;
      [ReadOnly]
      public ComponentLookup<Building> m_BuildingData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public ComponentLookup<ParkingLaneData> m_PrefabParkingLaneData;
      [ReadOnly]
      public ComponentLookup<ObjectGeometryData> m_PrefabObjectGeometryData;
      [ReadOnly]
      public BufferLookup<LayoutElement> m_LayoutElements;
      [ReadOnly]
      public BufferLookup<Game.Net.SubLane> m_Lanes;
      [ReadOnly]
      public BufferLookup<LaneOverlap> m_LaneOverlaps;
      [ReadOnly]
      public BufferLookup<ActivityLocationElement> m_ActivityLocations;
      public ComponentLookup<Transform> m_TransformData;
      public ComponentLookup<ParkedCar> m_ParkedCarData;
      public ComponentLookup<PersonalCar> m_PersonalCarData;
      public ComponentLookup<CarKeeper> m_CarKeeperData;
      public BufferLookup<LaneObject> m_LaneObjects;
      public BufferLookup<OwnedVehicle> m_OwnedVehicles;
      [ReadOnly]
      public RandomSeed m_RandomSeed;
      [ReadOnly]
      public NativeQuadTree<Entity, QuadTreeBoundsXZ> m_NetSearchTree;
      public NativeQueue<Entity> m_VehicleQueue;
      public NativeQuadTree<Entity, QuadTreeBoundsXZ> m_MovingObjectSearchTree;
      public EntityCommandBuffer m_CommandBuffer;

      public void Execute()
      {
        // ISSUE: reference to a compiler-generated field
        if (this.m_VehicleQueue.Count == 0)
          return;
        // ISSUE: reference to a compiler-generated field
        NativeParallelHashSet<Entity> nativeParallelHashSet = new NativeParallelHashSet<Entity>(this.m_VehicleQueue.Count * 2, (AllocatorManager.AllocatorHandle) Allocator.Temp);
        // ISSUE: reference to a compiler-generated field
        Unity.Mathematics.Random random = this.m_RandomSeed.GetRandom(0);
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
        FixParkingLocationSystem.FixParkingLocationJob.NetIterator iterator = new FixParkingLocationSystem.FixParkingLocationJob.NetIterator()
        {
          m_ParkedCarData = this.m_ParkedCarData,
          m_ParkingLaneData = this.m_ParkingLaneData,
          m_CurveData = this.m_CurveData,
          m_UnspawnedData = this.m_UnspawnedData,
          m_PrefabRefData = this.m_PrefabRefData,
          m_PrefabParkingLaneData = this.m_PrefabParkingLaneData,
          m_PrefabObjectGeometryData = this.m_PrefabObjectGeometryData,
          m_Lanes = this.m_Lanes,
          m_LaneObjects = this.m_LaneObjects,
          m_LaneOverlaps = this.m_LaneOverlaps
        };
        Entity entity;
        // ISSUE: reference to a compiler-generated field
        while (this.m_VehicleQueue.TryDequeue(out entity))
        {
          if (nativeParallelHashSet.Add(entity))
          {
            // ISSUE: reference to a compiler-generated field
            if (!this.m_ParkedCarData.HasComponent(entity))
            {
              // ISSUE: reference to a compiler-generated field
              FixParkingLocation fixParkingLocation = this.m_FixParkingLocationData[entity];
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.RemoveComponent<FixParkingLocation>(entity);
              // ISSUE: reference to a compiler-generated field
              if (this.m_LaneObjects.HasBuffer(fixParkingLocation.m_ChangeLane))
              {
                // ISSUE: reference to a compiler-generated field
                NetUtils.RemoveLaneObject(this.m_LaneObjects[fixParkingLocation.m_ChangeLane], entity);
              }
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              Transform parkingSpaceTarget = this.m_TransformData[entity];
              // ISSUE: reference to a compiler-generated field
              ParkedCar parkedCar = this.m_ParkedCarData[entity];
              // ISSUE: reference to a compiler-generated field
              PrefabRef prefabRef = this.m_PrefabRefData[entity];
              DynamicBuffer<LayoutElement> dynamicBuffer = new DynamicBuffer<LayoutElement>();
              // ISSUE: reference to a compiler-generated field
              if (this.m_LayoutElements.HasBuffer(entity))
              {
                // ISSUE: reference to a compiler-generated field
                dynamicBuffer = this.m_LayoutElements[entity];
              }
              Transform other = parkingSpaceTarget;
              bool flag1 = false;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              bool flag2 = this.m_LaneObjects.HasBuffer(parkedCar.m_Lane) && this.m_UnspawnedData.HasComponent(entity);
              // ISSUE: reference to a compiler-generated field
              if (this.m_FixParkingLocationData.HasComponent(entity))
              {
                // ISSUE: reference to a compiler-generated field
                FixParkingLocation fixParkingLocation = this.m_FixParkingLocationData[entity];
                // ISSUE: reference to a compiler-generated field
                this.m_CommandBuffer.RemoveComponent<FixParkingLocation>(entity);
                // ISSUE: reference to a compiler-generated field
                if (this.m_LaneObjects.HasBuffer(fixParkingLocation.m_ChangeLane))
                {
                  // ISSUE: reference to a compiler-generated field
                  NetUtils.RemoveLaneObject(this.m_LaneObjects[fixParkingLocation.m_ChangeLane], entity);
                }
                if (fixParkingLocation.m_ResetLocation != entity)
                {
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_TransformData.HasComponent(fixParkingLocation.m_ResetLocation))
                  {
                    // ISSUE: reference to a compiler-generated field
                    parkingSpaceTarget = this.m_TransformData[fixParkingLocation.m_ResetLocation];
                  }
                  else
                    flag1 = true;
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_PersonalCarData.HasComponent(entity))
                  {
                    // ISSUE: reference to a compiler-generated field
                    PersonalCar personalCar = this.m_PersonalCarData[entity];
                    CarKeeper component;
                    // ISSUE: reference to a compiler-generated field
                    if (this.m_CarKeeperData.TryGetEnabledComponent<CarKeeper>(personalCar.m_Keeper, out component) && component.m_Car == entity)
                    {
                      component.m_Car = Entity.Null;
                      // ISSUE: reference to a compiler-generated field
                      this.m_CarKeeperData[personalCar.m_Keeper] = component;
                    }
                    personalCar.m_Keeper = Entity.Null;
                    // ISSUE: reference to a compiler-generated field
                    this.m_PersonalCarData[entity] = personalCar;
                  }
                }
                // ISSUE: reference to a compiler-generated field
                if (this.m_LaneObjects.HasBuffer(parkedCar.m_Lane))
                {
                  // ISSUE: reference to a compiler-generated field
                  NetUtils.RemoveLaneObject(this.m_LaneObjects[parkedCar.m_Lane], entity);
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_ParkingLaneData.HasComponent(parkedCar.m_Lane) && nativeParallelHashSet.Add(parkedCar.m_Lane) && !this.m_UpdatedData.HasComponent(parkedCar.m_Lane))
                  {
                    // ISSUE: reference to a compiler-generated field
                    this.m_CommandBuffer.AddComponent<PathfindUpdated>(parkedCar.m_Lane, new PathfindUpdated());
                  }
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_ConnectionLaneData.HasComponent(parkedCar.m_Lane) && !this.m_DeletedData.HasComponent(parkedCar.m_Lane) && !flag1 && (this.m_ConnectionLaneData[parkedCar.m_Lane].m_Flags & ConnectionLaneFlags.Parking) != (ConnectionLaneFlags) 0)
                  {
                    // ISSUE: reference to a compiler-generated method
                    if (this.FindGarageSpot(ref random, entity, parkedCar.m_Lane, ref parkingSpaceTarget))
                    {
                      // ISSUE: reference to a compiler-generated field
                      this.m_TransformData[entity] = parkingSpaceTarget;
                      // ISSUE: reference to a compiler-generated field
                      if (this.m_UnspawnedData.HasComponent(entity))
                      {
                        // ISSUE: reference to a compiler-generated field
                        this.m_CommandBuffer.RemoveComponent<Unspawned>(entity);
                        // ISSUE: reference to a compiler-generated field
                        this.m_CommandBuffer.AddComponent<BatchesUpdated>(entity, new BatchesUpdated());
                      }
                    }
                    // ISSUE: reference to a compiler-generated field
                    ObjectGeometryData geometryData = this.m_PrefabObjectGeometryData[prefabRef.m_Prefab];
                    Bounds3 bounds = ObjectUtils.CalculateBounds(parkingSpaceTarget.m_Position, parkingSpaceTarget.m_Rotation, geometryData);
                    // ISSUE: reference to a compiler-generated field
                    this.m_MovingObjectSearchTree.TryUpdate(entity, new QuadTreeBoundsXZ(bounds));
                    continue;
                  }
                  // ISSUE: reference to a compiler-generated field
                  this.m_MovingObjectSearchTree.TryRemove(entity);
                }
                parkedCar.m_Lane = Entity.Null;
              }
              // ISSUE: reference to a compiler-generated field
              iterator.m_Position = parkingSpaceTarget.m_Position;
              // ISSUE: reference to a compiler-generated field
              iterator.m_MaxDistance = 100f;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              iterator.m_ParkingSize = VehicleUtils.GetParkingSize(entity, ref this.m_PrefabRefData, ref this.m_PrefabObjectGeometryData, out iterator.m_ParkingOffset);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              iterator.m_Bounds = new Bounds3(iterator.m_Position - iterator.m_MaxDistance, iterator.m_Position + iterator.m_MaxDistance);
              // ISSUE: reference to a compiler-generated field
              iterator.m_SelectedLane = Entity.Null;
              // ISSUE: reference to a compiler-generated field
              iterator.m_KeepUnspawned = flag2;
              Game.Net.ConnectionLane componentData1;
              // ISSUE: reference to a compiler-generated field
              if (this.m_ConnectionLaneData.TryGetComponent(parkedCar.m_Lane, out componentData1))
              {
                flag1 |= (componentData1.m_Flags & ConnectionLaneFlags.Outside) != 0;
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                if (parkedCar.m_Lane != Entity.Null && !this.m_DeletedData.HasComponent(parkedCar.m_Lane))
                {
                  // ISSUE: reference to a compiler-generated field
                  Curve curve1 = this.m_CurveData[parkedCar.m_Lane];
                  // ISSUE: reference to a compiler-generated method
                  if (flag2 || iterator.TryFindParkingSpace(parkedCar.m_Lane, curve1, false, ref parkedCar.m_CurvePosition))
                  {
                    // ISSUE: reference to a compiler-generated field
                    Game.Net.ParkingLane parkingLane = this.m_ParkingLaneData[parkedCar.m_Lane];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    ParkingLaneData parkingLaneData1 = this.m_PrefabParkingLaneData[this.m_PrefabRefData[parkedCar.m_Lane].m_Prefab];
                    // ISSUE: reference to a compiler-generated field
                    ObjectGeometryData objectGeometryData = this.m_PrefabObjectGeometryData[prefabRef.m_Prefab];
                    Transform transform = new Transform();
                    Owner componentData2;
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (this.m_OwnerData.TryGetComponent(parkedCar.m_Lane, out componentData2) && this.m_TransformData.HasComponent(componentData2.m_Owner))
                    {
                      // ISSUE: reference to a compiler-generated field
                      transform = this.m_TransformData[componentData2.m_Owner];
                    }
                    ParkingLaneData parkingLaneData2 = parkingLaneData1;
                    ObjectGeometryData prefabGeometryData = objectGeometryData;
                    Curve curve2 = curve1;
                    Transform ownerTransform = transform;
                    double curvePosition = (double) parkedCar.m_CurvePosition;
                    parkingSpaceTarget = VehicleUtils.CalculateParkingSpaceTarget(parkingLane, parkingLaneData2, prefabGeometryData, curve2, ownerTransform, (float) curvePosition);
                    // ISSUE: reference to a compiler-generated field
                    NetUtils.AddLaneObject(this.m_LaneObjects[parkedCar.m_Lane], entity, (float2) parkedCar.m_CurvePosition);
                    if (!parkingSpaceTarget.Equals(other))
                    {
                      // ISSUE: reference to a compiler-generated field
                      this.m_TransformData[entity] = parkingSpaceTarget;
                      // ISSUE: reference to a compiler-generated field
                      this.m_CommandBuffer.AddComponent<Updated>(entity, new Updated());
                    }
                    // ISSUE: reference to a compiler-generated field
                    this.m_ParkedCarData[entity] = parkedCar;
                    continue;
                  }
                }
              }
              if (!flag1)
              {
                // ISSUE: reference to a compiler-generated field
                this.m_NetSearchTree.Iterate<FixParkingLocationSystem.FixParkingLocationJob.NetIterator>(ref iterator);
              }
              // ISSUE: reference to a compiler-generated field
              if (iterator.m_SelectedLane != Entity.Null)
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Curve curve3 = this.m_CurveData[iterator.m_SelectedLane];
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                Game.Net.ParkingLane parkingLane = this.m_ParkingLaneData[iterator.m_SelectedLane];
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                ParkingLaneData parkingLaneData3 = this.m_PrefabParkingLaneData[this.m_PrefabRefData[iterator.m_SelectedLane].m_Prefab];
                // ISSUE: reference to a compiler-generated field
                ObjectGeometryData objectGeometryData = this.m_PrefabObjectGeometryData[prefabRef.m_Prefab];
                Transform transform = new Transform();
                Owner componentData3;
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if (this.m_OwnerData.TryGetComponent(iterator.m_SelectedLane, out componentData3) && this.m_TransformData.HasComponent(componentData3.m_Owner))
                {
                  // ISSUE: reference to a compiler-generated field
                  transform = this.m_TransformData[componentData3.m_Owner];
                }
                if (flag2)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  iterator.m_SelectedCurvePos = math.clamp(iterator.m_SelectedCurvePos, 0.05f, 0.95f);
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  iterator.m_SelectedCurvePos = random.NextFloat(math.max(0.05f, iterator.m_SelectedCurvePos - 0.2f), math.min(0.95f, iterator.m_SelectedCurvePos + 0.2f));
                }
                ParkingLaneData parkingLaneData4 = parkingLaneData3;
                ObjectGeometryData prefabGeometryData = objectGeometryData;
                Curve curve4 = curve3;
                Transform ownerTransform = transform;
                // ISSUE: reference to a compiler-generated field
                double selectedCurvePos = (double) iterator.m_SelectedCurvePos;
                parkingSpaceTarget = VehicleUtils.CalculateParkingSpaceTarget(parkingLane, parkingLaneData4, prefabGeometryData, curve4, ownerTransform, (float) selectedCurvePos);
                // ISSUE: reference to a compiler-generated field
                parkedCar.m_Lane = iterator.m_SelectedLane;
                // ISSUE: reference to a compiler-generated field
                parkedCar.m_CurvePosition = iterator.m_SelectedCurvePos;
                // ISSUE: reference to a compiler-generated field
                NetUtils.AddLaneObject(this.m_LaneObjects[parkedCar.m_Lane], entity, (float2) parkedCar.m_CurvePosition);
                // ISSUE: reference to a compiler-generated field
                if (nativeParallelHashSet.Add(parkedCar.m_Lane) && !this.m_UpdatedData.HasComponent(parkedCar.m_Lane))
                {
                  // ISSUE: reference to a compiler-generated field
                  this.m_CommandBuffer.AddComponent<PathfindUpdated>(parkedCar.m_Lane, new PathfindUpdated());
                }
                // ISSUE: reference to a compiler-generated field
                if (this.m_UnspawnedData.HasComponent(entity) && !flag2)
                {
                  // ISSUE: reference to a compiler-generated field
                  this.m_CommandBuffer.RemoveComponent<Unspawned>(entity);
                  // ISSUE: reference to a compiler-generated field
                  this.m_CommandBuffer.AddComponent<BatchesUpdated>(entity, new BatchesUpdated());
                }
              }
              else
              {
                parkedCar.m_Lane = Entity.Null;
                // ISSUE: reference to a compiler-generated field
                if (this.m_OwnerData.HasComponent(entity))
                {
                  // ISSUE: reference to a compiler-generated field
                  Owner owner = this.m_OwnerData[entity];
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_OwnedVehicles.HasBuffer(owner.m_Owner))
                  {
                    // ISSUE: reference to a compiler-generated field
                    CollectionUtils.RemoveValue<OwnedVehicle>(this.m_OwnedVehicles[owner.m_Owner], new OwnedVehicle(entity));
                  }
                }
                // ISSUE: reference to a compiler-generated field
                if (this.m_PersonalCarData.HasComponent(entity))
                {
                  // ISSUE: reference to a compiler-generated field
                  PersonalCar personalCar = this.m_PersonalCarData[entity];
                  CarKeeper component;
                  // ISSUE: reference to a compiler-generated field
                  if (this.m_CarKeeperData.TryGetEnabledComponent<CarKeeper>(personalCar.m_Keeper, out component) && component.m_Car == entity)
                  {
                    component.m_Car = Entity.Null;
                    // ISSUE: reference to a compiler-generated field
                    this.m_CarKeeperData[personalCar.m_Keeper] = component;
                  }
                  personalCar.m_Keeper = Entity.Null;
                  // ISSUE: reference to a compiler-generated field
                  this.m_PersonalCarData[entity] = personalCar;
                }
                if (dynamicBuffer.IsCreated && dynamicBuffer.Length != 0)
                {
                  for (int index = 0; index < dynamicBuffer.Length; ++index)
                  {
                    // ISSUE: reference to a compiler-generated field
                    this.m_CommandBuffer.AddComponent<Updated>(dynamicBuffer[index].m_Vehicle, new Updated());
                  }
                }
                else
                {
                  // ISSUE: reference to a compiler-generated field
                  this.m_CommandBuffer.AddComponent<Unspawned>(entity, new Unspawned());
                  // ISSUE: reference to a compiler-generated field
                  this.m_CommandBuffer.AddComponent<Updated>(entity, new Updated());
                }
              }
              if (!parkingSpaceTarget.Equals(other))
              {
                // ISSUE: reference to a compiler-generated field
                this.m_TransformData[entity] = parkingSpaceTarget;
                // ISSUE: reference to a compiler-generated field
                this.m_CommandBuffer.AddComponent<Updated>(entity, new Updated());
              }
              // ISSUE: reference to a compiler-generated field
              this.m_ParkedCarData[entity] = parkedCar;
            }
          }
        }
        nativeParallelHashSet.Dispose();
      }

      private bool FindGarageSpot(
        ref Unity.Mathematics.Random random,
        Entity vehicle,
        Entity lane,
        ref Transform transform)
      {
        Entity entity = lane;
        // ISSUE: reference to a compiler-generated field
        while (this.m_OwnerData.HasComponent(entity))
        {
          // ISSUE: reference to a compiler-generated field
          entity = this.m_OwnerData[entity].m_Owner;
        }
        DynamicBuffer<ActivityLocationElement> bufferData;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!this.m_BuildingData.HasComponent(entity) || !this.m_ActivityLocations.TryGetBuffer(this.m_PrefabRefData[entity].m_Prefab, out bufferData))
          return false;
        // ISSUE: reference to a compiler-generated field
        Transform transform1 = this.m_TransformData[entity];
        ActivityMask activityMask = new ActivityMask(ActivityType.GarageSpot);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        // ISSUE: variable of a compiler-generated type
        FixParkingLocationSystem.FixParkingLocationJob.OccupySpotsIterator iterator = new FixParkingLocationSystem.FixParkingLocationJob.OccupySpotsIterator()
        {
          m_Lane = lane,
          m_Ignore = vehicle,
          m_Bounds = new Bounds3((float3) float.MaxValue, (float3) float.MinValue),
          m_Spots = new NativeList<FixParkingLocationSystem.FixParkingLocationJob.SpotData>(bufferData.Length, (AllocatorManager.AllocatorHandle) Allocator.Temp),
          m_ParkedCarData = this.m_ParkedCarData,
          m_TransformData = this.m_TransformData
        };
        int index1 = -1;
        for (int index2 = 0; index2 < bufferData.Length; ++index2)
        {
          ActivityLocationElement activityLocationElement = bufferData[index2];
          if (((int) activityLocationElement.m_ActivityMask.m_Mask & (int) activityMask.m_Mask) != 0)
          {
            float3 world = ObjectUtils.LocalToWorld(transform1, activityLocationElement.m_Position);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            iterator.m_Bounds.min = math.min(iterator.m_Bounds.min, world - 1f);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            iterator.m_Bounds.max = math.max(iterator.m_Bounds.max, world + 1f);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: object of a compiler-generated type is created
            iterator.m_Spots.Add(new FixParkingLocationSystem.FixParkingLocationJob.SpotData()
            {
              m_Position = world,
              m_Index = index2
            });
            if ((double) math.distancesq(transform.m_Position, world) < 1.0)
              index1 = index2;
          }
        }
        bool garageSpot = false;
        // ISSUE: reference to a compiler-generated field
        if (iterator.m_Spots.Length > 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (iterator.m_Spots.Length >= 2)
          {
            // ISSUE: reference to a compiler-generated field
            float3 float3 = MathUtils.Size(iterator.m_Bounds);
            // ISSUE: reference to a compiler-generated field
            iterator.m_Order = math.select(0, 1, (double) float3.y > (double) float3.x);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            iterator.m_Order = math.select(iterator.m_Order, 2, math.all(float3.z > float3.xy));
          }
          // ISSUE: reference to a compiler-generated field
          for (int index3 = 0; index3 < iterator.m_Spots.Length; ++index3)
          {
            // ISSUE: reference to a compiler-generated field
            ref FixParkingLocationSystem.FixParkingLocationJob.SpotData local = ref iterator.m_Spots.ElementAt(index3);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            local.m_Order = local.m_Position[iterator.m_Order];
          }
          // ISSUE: reference to a compiler-generated field
          if (iterator.m_Spots.Length >= 2)
          {
            // ISSUE: reference to a compiler-generated field
            iterator.m_Spots.Sort<FixParkingLocationSystem.FixParkingLocationJob.SpotData>();
          }
          // ISSUE: reference to a compiler-generated field
          this.m_MovingObjectSearchTree.Iterate<FixParkingLocationSystem.FixParkingLocationJob.OccupySpotsIterator>(ref iterator);
          int max = 0;
          bool flag = false;
          // ISSUE: reference to a compiler-generated field
          for (int index4 = 0; index4 < iterator.m_Spots.Length; ++index4)
          {
            // ISSUE: reference to a compiler-generated field
            ref FixParkingLocationSystem.FixParkingLocationJob.SpotData local = ref iterator.m_Spots.ElementAt(index4);
            // ISSUE: reference to a compiler-generated field
            max += math.select(1, 0, local.m_Occupied);
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            flag = ((flag ? 1 : 0) | (local.m_Index != index1 ? 0 : (!local.m_Occupied ? 1 : 0))) != 0;
          }
          if (max != 0 && !flag)
          {
            int num = random.NextInt(max);
            // ISSUE: reference to a compiler-generated field
            for (int index5 = 0; index5 < iterator.m_Spots.Length; ++index5)
            {
              // ISSUE: reference to a compiler-generated field
              ref FixParkingLocationSystem.FixParkingLocationJob.SpotData local = ref iterator.m_Spots.ElementAt(index5);
              // ISSUE: reference to a compiler-generated field
              if (!local.m_Occupied && num-- == 0)
              {
                // ISSUE: reference to a compiler-generated field
                index1 = local.m_Index;
                flag = true;
                break;
              }
            }
          }
          if (flag)
          {
            ActivityLocationElement activityLocationElement = bufferData[index1];
            transform = ObjectUtils.LocalToWorld(transform1, activityLocationElement.m_Position, activityLocationElement.m_Rotation);
            garageSpot = true;
          }
        }
        // ISSUE: reference to a compiler-generated field
        iterator.m_Spots.Dispose();
        return garageSpot;
      }

      private struct SpotData : IComparable<FixParkingLocationSystem.FixParkingLocationJob.SpotData>
      {
        public float3 m_Position;
        public float m_Order;
        public int m_Index;
        public bool m_Occupied;

        public int CompareTo(
          FixParkingLocationSystem.FixParkingLocationJob.SpotData other)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          return math.select(0, math.select(-1, 1, (double) this.m_Order > (double) other.m_Order), (double) this.m_Order != (double) other.m_Order);
        }
      }

      private struct OccupySpotsIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public Entity m_Lane;
        public Entity m_Ignore;
        public Bounds3 m_Bounds;
        public int m_Order;
        public NativeList<FixParkingLocationSystem.FixParkingLocationJob.SpotData> m_Spots;
        public ComponentLookup<ParkedCar> m_ParkedCarData;
        public ComponentLookup<Transform> m_TransformData;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity entity)
        {
          ParkedCar componentData;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_ParkedCarData.TryGetComponent(entity, out componentData) || !(entity != this.m_Ignore) || !(componentData.m_Lane == this.m_Lane))
            return;
          // ISSUE: reference to a compiler-generated field
          Transform transform = this.m_TransformData[entity];
          // ISSUE: reference to a compiler-generated field
          float num1 = transform.m_Position[this.m_Order] - 1f;
          // ISSUE: reference to a compiler-generated field
          float num2 = transform.m_Position[this.m_Order] + 1f;
          int num3 = 0;
          // ISSUE: reference to a compiler-generated field
          int num4 = this.m_Spots.Length;
          while (num4 > num3)
          {
            int index = num3 + num4 >> 1;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if ((double) this.m_Spots[index].m_Order < (double) num1)
              num3 = index + 1;
            else
              num4 = index;
          }
          // ISSUE: reference to a compiler-generated field
          int length = this.m_Spots.Length;
          while (num3 < length)
          {
            // ISSUE: reference to a compiler-generated field
            ref FixParkingLocationSystem.FixParkingLocationJob.SpotData local = ref this.m_Spots.ElementAt(num3++);
            // ISSUE: reference to a compiler-generated field
            if ((double) local.m_Order > (double) num2)
              break;
            // ISSUE: reference to a compiler-generated field
            if ((double) math.distancesq(transform.m_Position, local.m_Position) < 1.0)
            {
              // ISSUE: reference to a compiler-generated field
              local.m_Occupied = true;
            }
          }
        }
      }

      private struct NetIterator : 
        INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
        IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>
      {
        public Bounds3 m_Bounds;
        public float3 m_Position;
        public float2 m_ParkingSize;
        public float m_MaxDistance;
        public float m_ParkingOffset;
        public ComponentLookup<ParkedCar> m_ParkedCarData;
        public ComponentLookup<Game.Net.ParkingLane> m_ParkingLaneData;
        public ComponentLookup<Curve> m_CurveData;
        public ComponentLookup<Unspawned> m_UnspawnedData;
        public ComponentLookup<PrefabRef> m_PrefabRefData;
        public ComponentLookup<ParkingLaneData> m_PrefabParkingLaneData;
        public ComponentLookup<ObjectGeometryData> m_PrefabObjectGeometryData;
        public BufferLookup<Game.Net.SubLane> m_Lanes;
        public BufferLookup<LaneObject> m_LaneObjects;
        public BufferLookup<LaneOverlap> m_LaneOverlaps;
        public Entity m_SelectedLane;
        public float m_SelectedCurvePos;
        public bool m_KeepUnspawned;

        public bool Intersect(QuadTreeBoundsXZ bounds)
        {
          // ISSUE: reference to a compiler-generated field
          return MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds);
        }

        public void Iterate(QuadTreeBoundsXZ bounds, Entity entity)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_Lanes.HasBuffer(entity))
            return;
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<Game.Net.SubLane> lane = this.m_Lanes[entity];
          for (int index = 0; index < lane.Length; ++index)
          {
            Entity subLane = lane[index].m_SubLane;
            // ISSUE: reference to a compiler-generated field
            if (this.m_ParkingLaneData.HasComponent(subLane))
            {
              // ISSUE: reference to a compiler-generated field
              Curve curve = this.m_CurveData[subLane];
              float t;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              if ((double) MathUtils.Distance(curve.m_Bezier, this.m_Position, out t) < (double) this.m_MaxDistance && (this.m_KeepUnspawned || this.TryFindParkingSpace(subLane, curve, true, ref t)))
              {
                // ISSUE: reference to a compiler-generated field
                float num = math.distance(this.m_Position, MathUtils.Position(curve.m_Bezier, t));
                // ISSUE: reference to a compiler-generated field
                if ((double) num < (double) this.m_MaxDistance)
                {
                  // ISSUE: reference to a compiler-generated field
                  this.m_MaxDistance = num;
                  // ISSUE: reference to a compiler-generated field
                  this.m_SelectedLane = subLane;
                  // ISSUE: reference to a compiler-generated field
                  this.m_SelectedCurvePos = t;
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  this.m_Bounds = new Bounds3(this.m_Position - this.m_MaxDistance, this.m_Position + this.m_MaxDistance);
                }
              }
            }
          }
        }

        public bool TryFindParkingSpace(
          Entity lane,
          Curve curve,
          bool ignoreDisabled,
          ref float curvePos)
        {
          // ISSUE: reference to a compiler-generated field
          Game.Net.ParkingLane parkingLane = this.m_ParkingLaneData[lane];
          if ((parkingLane.m_Flags & ParkingLaneFlags.VirtualLane) != (ParkingLaneFlags) 0 || ignoreDisabled && (parkingLane.m_Flags & ParkingLaneFlags.ParkingDisabled) != (ParkingLaneFlags) 0)
            return false;
          // ISSUE: reference to a compiler-generated field
          PrefabRef prefabRef = this.m_PrefabRefData[lane];
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<LaneObject> laneObject1 = this.m_LaneObjects[lane];
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<LaneOverlap> laneOverlap1 = this.m_LaneOverlaps[lane];
          // ISSUE: reference to a compiler-generated field
          ParkingLaneData parkingLaneData = this.m_PrefabParkingLaneData[prefabRef.m_Prefab];
          // ISSUE: reference to a compiler-generated field
          if (math.any(this.m_ParkingSize > VehicleUtils.GetParkingSize(parkingLaneData)))
            return false;
          if ((double) parkingLaneData.m_SlotInterval != 0.0)
          {
            int num1 = (int) math.floor((curve.m_Length + 0.01f) / parkingLaneData.m_SlotInterval);
            float3 x1 = curve.m_Bezier.a;
            float2 float2_1 = (float2) 0.0f;
            float num2 = 0.0f;
            float x2;
            switch (parkingLane.m_Flags & (ParkingLaneFlags.StartingLane | ParkingLaneFlags.EndingLane))
            {
              case ParkingLaneFlags.StartingLane:
                x2 = curve.m_Length - (float) num1 * parkingLaneData.m_SlotInterval;
                break;
              case ParkingLaneFlags.EndingLane:
                x2 = 0.0f;
                break;
              default:
                x2 = (float) (((double) curve.m_Length - (double) num1 * (double) parkingLaneData.m_SlotInterval) * 0.5);
                break;
            }
            float num3 = math.max(x2, 0.0f);
            int num4 = -1;
            float num5 = 1f;
            float num6 = curvePos;
            float num7 = 2f;
            int num8 = 0;
            while (num8 < laneObject1.Length)
            {
              LaneObject laneObject2 = laneObject1[num8++];
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (this.m_ParkedCarData.HasComponent(laneObject2.m_LaneObject) && !this.m_UnspawnedData.HasComponent(laneObject2.m_LaneObject))
              {
                num7 = laneObject2.m_CurvePosition.x;
                break;
              }
            }
            float2 float2_2 = (float2) 2f;
            int num9 = 0;
            if (num9 < laneOverlap1.Length)
            {
              LaneOverlap laneOverlap2 = laneOverlap1[num9++];
              float2_2 = new float2((float) laneOverlap2.m_ThisStart, (float) laneOverlap2.m_ThisEnd) * 0.003921569f;
            }
            for (int index = 1; index <= 16; ++index)
            {
              float num10 = (float) index * (1f / 16f);
              float3 y = MathUtils.Position(curve.m_Bezier, num10);
              for (num2 += math.distance(x1, y); (double) num2 >= (double) num3 || index == 16 && num4 < num1; ++num4)
              {
                float2_1.y = math.select(num10, math.lerp(float2_1.x, num10, num3 / num2), (double) num3 < (double) num2);
                bool flag = false;
                if ((double) num7 <= (double) float2_1.y)
                {
                  num7 = 2f;
                  flag = true;
                  while (num8 < laneObject1.Length)
                  {
                    LaneObject laneObject3 = laneObject1[num8++];
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    if (this.m_ParkedCarData.HasComponent(laneObject3.m_LaneObject) && !this.m_UnspawnedData.HasComponent(laneObject3.m_LaneObject) && (double) laneObject3.m_CurvePosition.x > (double) float2_1.y)
                    {
                      num7 = laneObject3.m_CurvePosition.x;
                      break;
                    }
                  }
                }
                if ((double) float2_2.x < (double) float2_1.y)
                {
                  flag = true;
                  if ((double) float2_2.y <= (double) float2_1.y)
                  {
                    float2_2 = (float2) 2f;
                    while (num9 < laneOverlap1.Length)
                    {
                      LaneOverlap laneOverlap3 = laneOverlap1[num9++];
                      float2 float2_3 = new float2((float) laneOverlap3.m_ThisStart, (float) laneOverlap3.m_ThisEnd) * 0.003921569f;
                      if ((double) float2_3.y > (double) float2_1.y)
                      {
                        float2_2 = float2_3;
                        break;
                      }
                    }
                  }
                }
                if (!flag && num4 >= 0 && num4 < num1)
                {
                  float num11 = math.max(float2_1.x - curvePos, curvePos - float2_1.y);
                  if ((double) num11 < (double) num5)
                  {
                    num6 = math.lerp(float2_1.x, float2_1.y, 0.5f);
                    num5 = num11;
                  }
                }
                num2 -= num3;
                float2_1.x = float2_1.y;
                num3 = parkingLaneData.m_SlotInterval;
              }
              x1 = y;
            }
            curvePos = num6;
            return (double) num5 != 1.0;
          }
          float2 float2_4 = new float2();
          float2 float2_5 = new float2();
          float num12 = 1f;
          float3 float3 = new float3();
          float2 x3 = (float2) math.select(0.0f, 0.5f, (parkingLane.m_Flags & ParkingLaneFlags.StartingLane) == (ParkingLaneFlags) 0);
          float3 x4 = curve.m_Bezier.a;
          float num13 = 2f;
          float2 float2_6 = (float2) 0.0f;
          int num14 = 0;
          while (num14 < laneObject1.Length)
          {
            LaneObject laneObject4 = laneObject1[num14++];
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_ParkedCarData.HasComponent(laneObject4.m_LaneObject) && !this.m_UnspawnedData.HasComponent(laneObject4.m_LaneObject))
            {
              num13 = laneObject4.m_CurvePosition.x;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              float2_6 = VehicleUtils.GetParkingOffsets(laneObject4.m_LaneObject, ref this.m_PrefabRefData, ref this.m_PrefabObjectGeometryData) + 1f;
              break;
            }
          }
          float2 float2_7 = (float2) 2f;
          int num15 = 0;
          if (num15 < laneOverlap1.Length)
          {
            LaneOverlap laneOverlap4 = laneOverlap1[num15++];
            float2_7 = new float2((float) laneOverlap4.m_ThisStart, (float) laneOverlap4.m_ThisEnd) * 0.003921569f;
          }
          while ((double) num13 != 2.0 || (double) float2_7.x != 2.0)
          {
            float num16;
            if ((double) num13 <= (double) float2_7.x)
            {
              float3.yz = (float2) num13;
              x3.y = float2_6.x;
              num16 = float2_6.y;
              num13 = 2f;
              while (num14 < laneObject1.Length)
              {
                LaneObject laneObject5 = laneObject1[num14++];
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                if (this.m_ParkedCarData.HasComponent(laneObject5.m_LaneObject) && !this.m_UnspawnedData.HasComponent(laneObject5.m_LaneObject))
                {
                  num13 = laneObject5.m_CurvePosition.x;
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  float2_6 = VehicleUtils.GetParkingOffsets(laneObject5.m_LaneObject, ref this.m_PrefabRefData, ref this.m_PrefabObjectGeometryData) + 1f;
                  break;
                }
              }
            }
            else
            {
              float3.yz = float2_7;
              x3.y = 0.5f;
              num16 = 0.5f;
              float2_7 = (float2) 2f;
              while (num15 < laneOverlap1.Length)
              {
                LaneOverlap laneOverlap5 = laneOverlap1[num15++];
                float2 float2_8 = new float2((float) laneOverlap5.m_ThisStart, (float) laneOverlap5.m_ThisEnd) * 0.003921569f;
                if ((double) float2_8.x <= (double) float3.z)
                {
                  float3.z = math.max(float3.z, float2_8.y);
                }
                else
                {
                  float2_7 = float2_8;
                  break;
                }
              }
            }
            float3 y = MathUtils.Position(curve.m_Bezier, float3.y);
            // ISSUE: reference to a compiler-generated field
            if ((double) math.distance(x4, y) - (double) math.csum(x3) >= (double) this.m_ParkingSize.y)
            {
              float num17 = math.max(float3.x - curvePos, curvePos - float3.y);
              if ((double) num17 < (double) num12)
              {
                float2_4 = float3.xy;
                float2_5 = x3;
                num12 = num17;
              }
            }
            float3.x = float3.z;
            x3.x = num16;
            x4 = MathUtils.Position(curve.m_Bezier, float3.z);
          }
          float3.y = 1f;
          x3.y = math.select(0.0f, 0.5f, (parkingLane.m_Flags & ParkingLaneFlags.EndingLane) == (ParkingLaneFlags) 0);
          // ISSUE: reference to a compiler-generated field
          if ((double) math.distance(x4, curve.m_Bezier.d) - (double) math.csum(x3) >= (double) this.m_ParkingSize.y)
          {
            float num18 = math.max(float3.x - curvePos, curvePos - float3.y);
            if ((double) num18 < (double) num12)
            {
              float2_4 = float3.xy;
              float2_5 = x3;
              num12 = num18;
            }
          }
          if ((double) num12 == 1.0)
            return false;
          // ISSUE: reference to a compiler-generated field
          float2 float2_9 = float2_5 + this.m_ParkingSize.y * 0.5f;
          // ISSUE: reference to a compiler-generated field
          float2_9.x += this.m_ParkingOffset;
          // ISSUE: reference to a compiler-generated field
          float2_9.y -= this.m_ParkingOffset;
          Bounds1 t1 = new Bounds1(float2_4.x, float2_4.y);
          Bounds1 t2 = new Bounds1(float2_4.x, float2_4.y);
          MathUtils.ClampLength(curve.m_Bezier, ref t1, float2_9.x);
          MathUtils.ClampLengthInverse(curve.m_Bezier, ref t2, float2_9.y);
          if ((double) curvePos < (double) t1.max || (double) curvePos > (double) t2.min)
            curvePos = (double) t1.max >= (double) t2.min ? math.lerp(t1.max, t2.min, 0.5f) : math.select(t1.max, t2.min, (double) curvePos > (double) t2.min);
          return true;
        }
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<FixParkingLocation> __Game_Vehicles_FixParkingLocation_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Game.Net.ConnectionLane> __Game_Net_ConnectionLane_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Owner> __Game_Common_Owner_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Curve> __Game_Net_Curve_RO_ComponentTypeHandle;
      public BufferTypeHandle<LaneObject> __Game_Net_LaneObject_RW_BufferTypeHandle;
      [ReadOnly]
      public ComponentLookup<ParkedCar> __Game_Vehicles_ParkedCar_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Owner> __Game_Common_Owner_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Transform> __Game_Objects_Transform_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Building> __Game_Buildings_Building_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<ActivityLocationElement> __Game_Prefabs_ActivityLocationElement_RO_BufferLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.ParkingLane> __Game_Net_ParkingLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.ConnectionLane> __Game_Net_ConnectionLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Curve> __Game_Net_Curve_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Deleted> __Game_Common_Deleted_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Updated> __Game_Common_Updated_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<FixParkingLocation> __Game_Vehicles_FixParkingLocation_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Unspawned> __Game_Objects_Unspawned_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ParkingLaneData> __Game_Prefabs_ParkingLaneData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ObjectGeometryData> __Game_Prefabs_ObjectGeometryData_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<LayoutElement> __Game_Vehicles_LayoutElement_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<Game.Net.SubLane> __Game_Net_SubLane_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<LaneOverlap> __Game_Net_LaneOverlap_RO_BufferLookup;
      public ComponentLookup<Transform> __Game_Objects_Transform_RW_ComponentLookup;
      public ComponentLookup<ParkedCar> __Game_Vehicles_ParkedCar_RW_ComponentLookup;
      public ComponentLookup<PersonalCar> __Game_Vehicles_PersonalCar_RW_ComponentLookup;
      public ComponentLookup<CarKeeper> __Game_Citizens_CarKeeper_RW_ComponentLookup;
      public BufferLookup<LaneObject> __Game_Net_LaneObject_RW_BufferLookup;
      public BufferLookup<OwnedVehicle> __Game_Vehicles_OwnedVehicle_RW_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_FixParkingLocation_RO_ComponentTypeHandle = state.GetComponentTypeHandle<FixParkingLocation>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_ConnectionLane_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Game.Net.ConnectionLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Curve_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Curve>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_LaneObject_RW_BufferTypeHandle = state.GetBufferTypeHandle<LaneObject>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_ParkedCar_RO_ComponentLookup = state.GetComponentLookup<ParkedCar>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentLookup = state.GetComponentLookup<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RO_ComponentLookup = state.GetComponentLookup<Transform>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Building_RO_ComponentLookup = state.GetComponentLookup<Building>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ActivityLocationElement_RO_BufferLookup = state.GetBufferLookup<ActivityLocationElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_ParkingLane_RO_ComponentLookup = state.GetComponentLookup<Game.Net.ParkingLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_ConnectionLane_RO_ComponentLookup = state.GetComponentLookup<Game.Net.ConnectionLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Curve_RO_ComponentLookup = state.GetComponentLookup<Curve>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Deleted_RO_ComponentLookup = state.GetComponentLookup<Deleted>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Updated_RO_ComponentLookup = state.GetComponentLookup<Updated>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_FixParkingLocation_RO_ComponentLookup = state.GetComponentLookup<FixParkingLocation>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Unspawned_RO_ComponentLookup = state.GetComponentLookup<Unspawned>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ParkingLaneData_RO_ComponentLookup = state.GetComponentLookup<ParkingLaneData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ObjectGeometryData_RO_ComponentLookup = state.GetComponentLookup<ObjectGeometryData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_LayoutElement_RO_BufferLookup = state.GetBufferLookup<LayoutElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_SubLane_RO_BufferLookup = state.GetBufferLookup<Game.Net.SubLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_LaneOverlap_RO_BufferLookup = state.GetBufferLookup<LaneOverlap>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Objects_Transform_RW_ComponentLookup = state.GetComponentLookup<Transform>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_ParkedCar_RW_ComponentLookup = state.GetComponentLookup<ParkedCar>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_PersonalCar_RW_ComponentLookup = state.GetComponentLookup<PersonalCar>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_CarKeeper_RW_ComponentLookup = state.GetComponentLookup<CarKeeper>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_LaneObject_RW_BufferLookup = state.GetBufferLookup<LaneObject>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_OwnedVehicle_RW_BufferLookup = state.GetBufferLookup<OwnedVehicle>();
      }
    }
  }
}

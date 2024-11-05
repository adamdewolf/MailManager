// Decompiled with JetBrains decompiler
// Type: Game.Routes.SegmentCurveSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Common;
using Game.Net;
using Game.Pathfind;
using Game.Prefabs;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Routes
{
  [CompilerGenerated]
  public class SegmentCurveSystem : GameSystemBase
  {
    private EntityQuery m_UpdatedRoutesQuery;
    private EntityQuery m_AllRoutesQuery;
    private bool m_Loaded;
    private SegmentCurveSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_UpdatedRoutesQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[3]
        {
          ComponentType.ReadOnly<Segment>(),
          ComponentType.ReadOnly<CurveElement>(),
          ComponentType.ReadOnly<Updated>()
        }
      }, new EntityQueryDesc()
      {
        All = new ComponentType[2]
        {
          ComponentType.ReadOnly<Game.Common.Event>(),
          ComponentType.ReadOnly<PathUpdated>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.m_AllRoutesQuery = this.GetEntityQuery(ComponentType.ReadOnly<Segment>(), ComponentType.ReadOnly<CurveElement>());
    }

    protected override void OnGameLoaded(Colossal.Serialization.Entities.Context serializationContext)
    {
      // ISSUE: reference to a compiler-generated field
      this.m_Loaded = true;
    }

    private bool GetLoaded()
    {
      // ISSUE: reference to a compiler-generated field
      if (!this.m_Loaded)
        return false;
      // ISSUE: reference to a compiler-generated field
      this.m_Loaded = false;
      return true;
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated method
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      EntityQuery entityQuery = this.GetLoaded() ? this.m_AllRoutesQuery : this.m_UpdatedRoutesQuery;
      if (entityQuery.IsEmptyIgnoreFilter)
        return;
      NativeList<Entity> nativeList = new NativeList<Entity>((AllocatorManager.AllocatorHandle) Allocator.TempJob);
      JobHandle outJobHandle;
      NativeList<ArchetypeChunk> archetypeChunkListAsync = entityQuery.ToArchetypeChunkListAsync((AllocatorManager.AllocatorHandle) Allocator.TempJob, out outJobHandle);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_CurveElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathUpdated_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
      SegmentCurveSystem.FindUpdatedSegmentsJob jobData1 = new SegmentCurveSystem.FindUpdatedSegmentsJob()
      {
        m_Chunks = archetypeChunkListAsync,
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_PathUpdatedType = this.__TypeHandle.__Game_Pathfind_PathUpdated_RO_ComponentTypeHandle,
        m_CurveElements = this.__TypeHandle.__Game_Routes_CurveElement_RO_BufferLookup,
        m_SegmentList = nativeList
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_CurveElement_RW_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_RouteWaypoint_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_RouteData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_ConnectionLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_CarLane_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_PathTargets_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_Position_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_Segment_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
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
      SegmentCurveSystem.UpdateSegmentCurvesJob jobData2 = new SegmentCurveSystem.UpdateSegmentCurvesJob()
      {
        m_SegmentList = nativeList.AsDeferredJobArray(),
        m_OwnerData = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup,
        m_SegmentData = this.__TypeHandle.__Game_Routes_Segment_RO_ComponentLookup,
        m_PositionData = this.__TypeHandle.__Game_Routes_Position_RO_ComponentLookup,
        m_PathTargetsData = this.__TypeHandle.__Game_Routes_PathTargets_RO_ComponentLookup,
        m_CurveData = this.__TypeHandle.__Game_Net_Curve_RO_ComponentLookup,
        m_CarLaneData = this.__TypeHandle.__Game_Net_CarLane_RO_ComponentLookup,
        m_ConnectionLaneData = this.__TypeHandle.__Game_Net_ConnectionLane_RO_ComponentLookup,
        m_PrefabRefData = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_PrefabRouteData = this.__TypeHandle.__Game_Prefabs_RouteData_RO_ComponentLookup,
        m_RouteWaypoints = this.__TypeHandle.__Game_Routes_RouteWaypoint_RO_BufferLookup,
        m_PathElements = this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup,
        m_CurveElements = this.__TypeHandle.__Game_Routes_CurveElement_RW_BufferLookup
      };
      JobHandle jobHandle = jobData1.Schedule<SegmentCurveSystem.FindUpdatedSegmentsJob>(JobHandle.CombineDependencies(this.Dependency, outJobHandle));
      NativeList<Entity> list = nativeList;
      JobHandle dependsOn = jobHandle;
      JobHandle inputDeps = jobData2.Schedule<SegmentCurveSystem.UpdateSegmentCurvesJob, Entity>(list, 1, dependsOn);
      nativeList.Dispose(inputDeps);
      archetypeChunkListAsync.Dispose(inputDeps);
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
    public SegmentCurveSystem()
    {
    }

    [BurstCompile]
    private struct FindUpdatedSegmentsJob : IJob
    {
      [ReadOnly]
      public NativeList<ArchetypeChunk> m_Chunks;
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<PathUpdated> m_PathUpdatedType;
      [ReadOnly]
      public BufferLookup<CurveElement> m_CurveElements;
      public NativeList<Entity> m_SegmentList;

      public void Execute()
      {
        int capacity = 0;
        // ISSUE: reference to a compiler-generated field
        for (int index = 0; index < this.m_Chunks.Length; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          capacity += this.m_Chunks[index].Count;
        }
        NativeParallelHashSet<Entity> nativeParallelHashSet = new NativeParallelHashSet<Entity>(capacity, (AllocatorManager.AllocatorHandle) Allocator.Temp);
        // ISSUE: reference to a compiler-generated field
        this.m_SegmentList.Capacity = capacity;
        // ISSUE: reference to a compiler-generated field
        for (int index1 = 0; index1 < this.m_Chunks.Length; ++index1)
        {
          // ISSUE: reference to a compiler-generated field
          ArchetypeChunk chunk = this.m_Chunks[index1];
          // ISSUE: reference to a compiler-generated field
          NativeArray<PathUpdated> nativeArray1 = chunk.GetNativeArray<PathUpdated>(ref this.m_PathUpdatedType);
          if (nativeArray1.Length != 0)
          {
            for (int index2 = 0; index2 < nativeArray1.Length; ++index2)
            {
              PathUpdated pathUpdated = nativeArray1[index2];
              // ISSUE: reference to a compiler-generated field
              if (this.m_CurveElements.HasBuffer(pathUpdated.m_Owner) && nativeParallelHashSet.Add(pathUpdated.m_Owner))
              {
                // ISSUE: reference to a compiler-generated field
                this.m_SegmentList.Add(in pathUpdated.m_Owner);
              }
            }
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            NativeArray<Entity> nativeArray2 = chunk.GetNativeArray(this.m_EntityType);
            for (int index3 = 0; index3 < nativeArray2.Length; ++index3)
            {
              Entity entity = nativeArray2[index3];
              if (nativeParallelHashSet.Add(entity))
              {
                // ISSUE: reference to a compiler-generated field
                this.m_SegmentList.Add(in entity);
              }
            }
          }
        }
        nativeParallelHashSet.Dispose();
      }
    }

    [BurstCompile]
    private struct UpdateSegmentCurvesJob : IJobParallelForDefer
    {
      [ReadOnly]
      public NativeArray<Entity> m_SegmentList;
      [ReadOnly]
      public ComponentLookup<Owner> m_OwnerData;
      [ReadOnly]
      public ComponentLookup<Segment> m_SegmentData;
      [ReadOnly]
      public ComponentLookup<Position> m_PositionData;
      [ReadOnly]
      public ComponentLookup<PathTargets> m_PathTargetsData;
      [ReadOnly]
      public ComponentLookup<Curve> m_CurveData;
      [ReadOnly]
      public ComponentLookup<Game.Net.CarLane> m_CarLaneData;
      [ReadOnly]
      public ComponentLookup<Game.Net.ConnectionLane> m_ConnectionLaneData;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefData;
      [ReadOnly]
      public ComponentLookup<RouteData> m_PrefabRouteData;
      [ReadOnly]
      public BufferLookup<RouteWaypoint> m_RouteWaypoints;
      [ReadOnly]
      public BufferLookup<PathElement> m_PathElements;
      [NativeDisableParallelForRestriction]
      public BufferLookup<CurveElement> m_CurveElements;

      public void Execute(int index)
      {
        // ISSUE: reference to a compiler-generated field
        Entity segment1 = this.m_SegmentList[index];
        // ISSUE: reference to a compiler-generated field
        DynamicBuffer<CurveElement> curveElement = this.m_CurveElements[segment1];
        curveElement.Clear();
        // ISSUE: reference to a compiler-generated field
        if (!this.m_OwnerData.HasComponent(segment1))
          return;
        // ISSUE: reference to a compiler-generated field
        Entity owner = this.m_OwnerData[segment1].m_Owner;
        // ISSUE: reference to a compiler-generated field
        Segment segment2 = this.m_SegmentData[segment1];
        // ISSUE: reference to a compiler-generated field
        PrefabRef prefabRef = this.m_PrefabRefData[owner];
        // ISSUE: reference to a compiler-generated field
        DynamicBuffer<RouteWaypoint> routeWaypoint = this.m_RouteWaypoints[owner];
        // ISSUE: reference to a compiler-generated field
        RouteData routeData = this.m_PrefabRouteData[prefabRef.m_Prefab];
        Entity waypoint1 = routeWaypoint[segment2.m_Index].m_Waypoint;
        Entity waypoint2 = routeWaypoint[math.select(segment2.m_Index + 1, 0, segment2.m_Index + 1 >= routeWaypoint.Length)].m_Waypoint;
        // ISSUE: reference to a compiler-generated field
        float3 lastPosition = this.m_PositionData[waypoint1].m_Position;
        // ISSUE: reference to a compiler-generated field
        float3 float3 = this.m_PositionData[waypoint2].m_Position;
        float nodeDistance = routeData.m_Width * 2.5f;
        float segmentLength = routeData.m_SegmentLength;
        float3 lastTangent = new float3();
        bool airway = false;
        // ISSUE: reference to a compiler-generated field
        if (this.m_PathTargetsData.HasComponent(segment1))
        {
          // ISSUE: reference to a compiler-generated field
          PathTargets pathTargets = this.m_PathTargetsData[segment1];
          lastPosition = pathTargets.m_ReadyStartPosition;
          float3 = pathTargets.m_ReadyEndPosition;
        }
        // ISSUE: reference to a compiler-generated field
        if (this.m_PathElements.HasBuffer(segment1))
        {
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<PathElement> pathElement = this.m_PathElements[segment1];
          // ISSUE: reference to a compiler-generated method
          this.TryAddSegments(curveElement, pathElement, lastPosition, float3, nodeDistance, segmentLength, ref lastPosition, ref lastTangent, ref airway);
        }
        // ISSUE: reference to a compiler-generated method
        this.TryAddSegments(curveElement, float3, new float3(), segmentLength, ref lastPosition, ref lastTangent, ref airway);
      }

      private void TryAddSegments(
        DynamicBuffer<CurveElement> curveElements,
        DynamicBuffer<PathElement> path,
        float3 lastNodePos,
        float3 nextNodePos,
        float nodeDistance,
        float segmentLength,
        ref float3 lastPosition,
        ref float3 lastTangent,
        ref bool airway)
      {
        bool flag = true;
        int num1 = -1;
        bool airway1 = false;
        for (int index = path.Length - 1; index >= 0; --index)
        {
          PathElement pathElement = path[index];
          // ISSUE: reference to a compiler-generated method
          if (!this.ShouldSkipTarget(pathElement.m_Target, ref airway1))
          {
            // ISSUE: reference to a compiler-generated field
            Bezier4x3 bezier4x3 = MathUtils.Cut(this.m_CurveData[pathElement.m_Target].m_Bezier, pathElement.m_TargetDelta);
            if ((double) math.distance(nextNodePos, bezier4x3.a) > (double) nodeDistance)
            {
              num1 = index;
              break;
            }
          }
        }
        for (int index = 0; index <= num1; ++index)
        {
          PathElement pathElement = path[index];
          // ISSUE: reference to a compiler-generated method
          if (!this.ShouldSkipTarget(pathElement.m_Target, ref airway))
          {
            // ISSUE: reference to a compiler-generated field
            Bezier4x3 curve = MathUtils.Cut(this.m_CurveData[pathElement.m_Target].m_Bezier, pathElement.m_TargetDelta);
            if (flag)
            {
              if ((double) math.distance(lastNodePos, curve.a) < (double) nodeDistance)
              {
                if ((double) math.distance(lastNodePos, curve.d) > (double) nodeDistance)
                {
                  // ISSUE: reference to a compiler-generated method
                  float x = this.MoveCurvePosition(lastNodePos, nodeDistance, curve);
                  curve = MathUtils.Cut(curve, new float2(x, 1f));
                }
                else
                  continue;
              }
              flag = false;
            }
            if (index == num1 && (double) math.distance(nextNodePos, curve.d) < (double) nodeDistance)
            {
              if ((double) math.distance(nextNodePos, curve.a) > (double) nodeDistance)
              {
                // ISSUE: reference to a compiler-generated method
                float num2 = this.MoveCurvePosition(nextNodePos, nodeDistance, MathUtils.Invert(curve));
                curve = MathUtils.Cut(curve, new float2(0.0f, 1f - num2));
              }
              else
                break;
            }
            // ISSUE: reference to a compiler-generated method
            this.TryAddSegments(curveElements, curve, segmentLength, ref lastPosition, ref lastTangent, ref airway);
          }
        }
        airway |= airway1;
      }

      private bool ShouldSkipTarget(Entity target, ref bool airway)
      {
        // ISSUE: reference to a compiler-generated field
        if (!this.m_CurveData.HasComponent(target))
          return true;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_CarLaneData.HasComponent(target) && (this.m_CarLaneData[target].m_Flags & CarLaneFlags.Runway) != ~(CarLaneFlags.Unsafe | CarLaneFlags.UTurnLeft | CarLaneFlags.Invert | CarLaneFlags.SideConnection | CarLaneFlags.TurnLeft | CarLaneFlags.TurnRight | CarLaneFlags.LevelCrossing | CarLaneFlags.Twoway | CarLaneFlags.IsSecured | CarLaneFlags.Runway | CarLaneFlags.Yield | CarLaneFlags.Stop | CarLaneFlags.ForbidCombustionEngines | CarLaneFlags.ForbidTransitTraffic | CarLaneFlags.ForbidHeavyTraffic | CarLaneFlags.PublicOnly | CarLaneFlags.Highway | CarLaneFlags.UTurnRight | CarLaneFlags.GentleTurnLeft | CarLaneFlags.GentleTurnRight | CarLaneFlags.Forward | CarLaneFlags.Approach | CarLaneFlags.Roundabout | CarLaneFlags.RightLimit | CarLaneFlags.LeftLimit | CarLaneFlags.ForbidPassing | CarLaneFlags.RightOfWay | CarLaneFlags.TrafficLights | CarLaneFlags.ParkingLeft | CarLaneFlags.ParkingRight | CarLaneFlags.Forbidden | CarLaneFlags.AllowEnter))
        {
          airway = true;
          return true;
        }
        // ISSUE: reference to a compiler-generated field
        if (!this.m_ConnectionLaneData.HasComponent(target))
          return false;
        // ISSUE: reference to a compiler-generated field
        Game.Net.ConnectionLane connectionLane = this.m_ConnectionLaneData[target];
        airway |= (connectionLane.m_Flags & ConnectionLaneFlags.Airway) != 0;
        return true;
      }

      private float MoveCurvePosition(float3 comparePosition, float minDistance, Bezier4x3 curve)
      {
        float2 float2 = new float2(0.0f, 1f);
        for (int index = 0; index < 8; ++index)
        {
          float t = math.lerp(float2.x, float2.y, 0.5f);
          float3 y = MathUtils.Position(curve, t);
          if ((double) math.distance(comparePosition, y) < (double) minDistance)
            float2.x = t;
          else
            float2.y = t;
        }
        return math.lerp(float2.x, float2.y, 0.5f);
      }

      private void TryAddSegments(
        DynamicBuffer<CurveElement> curveElements,
        Bezier4x3 curve,
        float segmentLength,
        ref float3 lastPosition,
        ref float3 lastTangent,
        ref bool airway)
      {
        float3 nextTangent = MathUtils.StartTangent(curve);
        // ISSUE: reference to a compiler-generated method
        this.TryAddSegments(curveElements, curve.a, nextTangent, segmentLength, ref lastPosition, ref lastTangent, ref airway);
        if ((double) math.distance(curve.a, curve.d) <= 0.0099999997764825821)
          return;
        curveElements.Add(new CurveElement()
        {
          m_Curve = curve
        });
        lastPosition = curve.d;
        lastTangent = MathUtils.EndTangent(curve);
        airway = false;
      }

      private void TryAddSegments(
        DynamicBuffer<CurveElement> curveElements,
        float3 position,
        float3 nextTangent,
        float segmentLength,
        ref float3 lastPosition,
        ref float3 lastTangent,
        ref bool airway)
      {
        float num1 = math.distance(lastPosition, position);
        if ((double) num1 <= 1.0)
          return;
        Bezier4x3 curve;
        if (airway)
        {
          lastTangent = position - lastPosition;
          nextTangent = position - lastPosition;
          lastTangent.y += num1;
          nextTangent.y -= num1;
          lastTangent = MathUtils.Normalize(lastTangent, lastTangent.xz);
          nextTangent = MathUtils.Normalize(nextTangent, nextTangent.xz);
          curve = NetUtils.FitCurve(lastPosition, lastTangent, nextTangent, position);
          num1 = MathUtils.Length(curve);
          nextTangent = new float3();
        }
        else
        {
          bool2 x = new bool2(!lastTangent.Equals(new float3()), !nextTangent.Equals(new float3()));
          if (math.all(x))
          {
            lastTangent = MathUtils.Normalize(lastTangent, lastTangent.xz);
            nextTangent = MathUtils.Normalize(nextTangent, nextTangent.xz);
            curve = NetUtils.FitCurve(lastPosition, lastTangent, nextTangent, position);
            num1 = MathUtils.Length(curve);
          }
          else if (x.x)
          {
            float3 y = (position - lastPosition) / num1;
            lastTangent = MathUtils.Normalize(lastTangent, lastTangent.xz);
            nextTangent = y * (math.dot(lastTangent, y) * 2f) - lastTangent;
            curve = NetUtils.FitCurve(lastPosition, lastTangent, nextTangent, position);
            num1 = MathUtils.Length(curve);
          }
          else if (x.y)
          {
            float3 y = (position - lastPosition) / num1;
            nextTangent = MathUtils.Normalize(nextTangent, nextTangent.xz);
            lastTangent = y * (math.dot(nextTangent, y) * 2f) - nextTangent;
            curve = NetUtils.FitCurve(lastPosition, lastTangent, nextTangent, position);
            num1 = MathUtils.Length(curve);
          }
          else
          {
            curve = NetUtils.StraightCurve(lastPosition, position);
            nextTangent = position - lastPosition;
          }
        }
        int num2 = Mathf.RoundToInt(num1 / segmentLength);
        if (num2 > 1)
        {
          for (int x = 0; x < num2; ++x)
          {
            float2 t = new float2((float) x, (float) (x + 1)) / (float) num2;
            curveElements.Add(new CurveElement()
            {
              m_Curve = MathUtils.Cut(curve, t)
            });
          }
        }
        else
          curveElements.Add(new CurveElement()
          {
            m_Curve = curve
          });
        lastPosition = position;
        lastTangent = nextTangent;
        airway = false;
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PathUpdated> __Game_Pathfind_PathUpdated_RO_ComponentTypeHandle;
      [ReadOnly]
      public BufferLookup<CurveElement> __Game_Routes_CurveElement_RO_BufferLookup;
      [ReadOnly]
      public ComponentLookup<Owner> __Game_Common_Owner_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Segment> __Game_Routes_Segment_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Position> __Game_Routes_Position_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PathTargets> __Game_Routes_PathTargets_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Curve> __Game_Net_Curve_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.CarLane> __Game_Net_CarLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Game.Net.ConnectionLane> __Game_Net_ConnectionLane_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<RouteData> __Game_Prefabs_RouteData_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<RouteWaypoint> __Game_Routes_RouteWaypoint_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<PathElement> __Game_Pathfind_PathElement_RO_BufferLookup;
      public BufferLookup<CurveElement> __Game_Routes_CurveElement_RW_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathUpdated_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PathUpdated>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_CurveElement_RO_BufferLookup = state.GetBufferLookup<CurveElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentLookup = state.GetComponentLookup<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_Segment_RO_ComponentLookup = state.GetComponentLookup<Segment>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_Position_RO_ComponentLookup = state.GetComponentLookup<Position>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_PathTargets_RO_ComponentLookup = state.GetComponentLookup<PathTargets>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_Curve_RO_ComponentLookup = state.GetComponentLookup<Curve>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_CarLane_RO_ComponentLookup = state.GetComponentLookup<Game.Net.CarLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Net_ConnectionLane_RO_ComponentLookup = state.GetComponentLookup<Game.Net.ConnectionLane>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_RouteData_RO_ComponentLookup = state.GetComponentLookup<RouteData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_RouteWaypoint_RO_BufferLookup = state.GetBufferLookup<RouteWaypoint>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathElement_RO_BufferLookup = state.GetBufferLookup<PathElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_CurveElement_RW_BufferLookup = state.GetBufferLookup<CurveElement>();
      }
    }
  }
}

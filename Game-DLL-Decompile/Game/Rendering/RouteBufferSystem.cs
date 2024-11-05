// Decompiled with JetBrains decompiler
// Type: Game.Rendering.RouteBufferSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Common;
using Game.Pathfind;
using Game.Prefabs;
using Game.Routes;
using Game.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Collections.LowLevel.Unsafe;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Rendering
{
  [CompilerGenerated]
  public class RouteBufferSystem : GameSystemBase, IPreDeserialize
  {
    private PrefabSystem m_PrefabSystem;
    private EntityQuery m_UpdatedRoutesQuery;
    private EntityQuery m_AllRoutesQuery;
    private List<RouteBufferSystem.ManagedData> m_ManagedData;
    private NativeList<RouteBufferSystem.NativeData> m_NativeData;
    private Stack<int> m_FreeBufferIndices;
    private JobHandle m_BufferDependencies;
    private bool m_Loaded;
    private RouteBufferSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_PrefabSystem = this.World.GetOrCreateSystemManaged<PrefabSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_UpdatedRoutesQuery = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[1]
        {
          ComponentType.ReadOnly<Route>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<Updated>(),
          ComponentType.ReadOnly<Deleted>()
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
      this.m_AllRoutesQuery = this.GetEntityQuery(ComponentType.ReadOnly<Route>());
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnDestroy()
    {
      // ISSUE: reference to a compiler-generated method
      this.Clear();
      // ISSUE: reference to a compiler-generated field
      if (this.m_NativeData.IsCreated)
      {
        // ISSUE: reference to a compiler-generated field
        this.m_NativeData.Dispose();
      }
      base.OnDestroy();
    }

    public void PreDeserialize(Colossal.Serialization.Entities.Context context)
    {
      // ISSUE: reference to a compiler-generated method
      this.Clear();
      // ISSUE: reference to a compiler-generated field
      this.m_Loaded = true;
    }

    private void Clear()
    {
      // ISSUE: reference to a compiler-generated field
      if (this.m_ManagedData != null)
      {
        // ISSUE: reference to a compiler-generated field
        for (int index = 0; index < this.m_ManagedData.Count; ++index)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.m_ManagedData[index].Dispose();
        }
        // ISSUE: reference to a compiler-generated field
        this.m_ManagedData.Clear();
      }
      // ISSUE: reference to a compiler-generated field
      if (this.m_FreeBufferIndices != null)
      {
        // ISSUE: reference to a compiler-generated field
        this.m_FreeBufferIndices.Clear();
      }
      // ISSUE: reference to a compiler-generated field
      if (!this.m_NativeData.IsCreated)
        return;
      // ISSUE: reference to a compiler-generated field
      this.m_BufferDependencies.Complete();
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < this.m_NativeData.Length; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_NativeData.ElementAt(index).Dispose();
      }
      // ISSUE: reference to a compiler-generated field
      this.m_NativeData.Clear();
    }

    public unsafe void GetBuffer(
      int index,
      out Material material,
      out ComputeBuffer segmentBuffer,
      out int originalRenderQueue,
      out Bounds bounds,
      out Vector4 size)
    {
      material = (Material) null;
      segmentBuffer = (ComputeBuffer) null;
      originalRenderQueue = 0;
      bounds = new Bounds();
      size = new Vector4();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      if (this.m_ManagedData == null || index < 0 || index >= this.m_ManagedData.Count)
        return;
      // ISSUE: reference to a compiler-generated field
      this.m_BufferDependencies.Complete();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: variable of a compiler-generated type
      RouteBufferSystem.ManagedData managedData = this.m_ManagedData[index];
      // ISSUE: reference to a compiler-generated field
      ref RouteBufferSystem.NativeData local = ref this.m_NativeData.ElementAt(index);
      // ISSUE: reference to a compiler-generated field
      if (managedData.m_Updated)
      {
        // ISSUE: reference to a compiler-generated field
        managedData.m_Updated = false;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (managedData.m_SegmentBuffer != null && managedData.m_SegmentBuffer.count != local.m_SegmentData.Length)
        {
          // ISSUE: reference to a compiler-generated field
          managedData.m_SegmentBuffer.Release();
          // ISSUE: reference to a compiler-generated field
          managedData.m_SegmentBuffer = (ComputeBuffer) null;
        }
        // ISSUE: reference to a compiler-generated field
        if (local.m_SegmentData.Length > 0)
        {
          // ISSUE: reference to a compiler-generated field
          if (managedData.m_SegmentBuffer == null)
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            managedData.m_SegmentBuffer = new ComputeBuffer(local.m_SegmentData.Length, sizeof (RouteBufferSystem.SegmentData));
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            managedData.m_SegmentBuffer.name = "Route segment buffer (" + managedData.m_Material.name + ")";
          }
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          NativeArray<RouteBufferSystem.SegmentData> nativeArray = NativeArrayUnsafeUtility.ConvertExistingDataToNativeArray<RouteBufferSystem.SegmentData>((void*) local.m_SegmentData.Ptr, local.m_SegmentData.Length, Allocator.None);
          // ISSUE: reference to a compiler-generated field
          managedData.m_SegmentBuffer.SetData<RouteBufferSystem.SegmentData>(nativeArray);
        }
        // ISSUE: reference to a compiler-generated field
        local.m_SegmentData.Dispose();
      }
      // ISSUE: reference to a compiler-generated field
      material = managedData.m_Material;
      // ISSUE: reference to a compiler-generated field
      segmentBuffer = managedData.m_SegmentBuffer;
      // ISSUE: reference to a compiler-generated field
      originalRenderQueue = managedData.m_OriginalRenderQueue;
      // ISSUE: reference to a compiler-generated field
      bounds = RenderingUtils.ToBounds(local.m_Bounds);
      // ISSUE: reference to a compiler-generated field
      size = managedData.m_Size;
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
      bool loaded = this.GetLoaded();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      EntityQuery entityQuery = loaded ? this.m_AllRoutesQuery : this.m_UpdatedRoutesQuery;
      if (entityQuery.IsEmptyIgnoreFilter)
        return;
      HashSet<Entity> entitySet = (HashSet<Entity>) null;
      // ISSUE: reference to a compiler-generated field
      this.m_BufferDependencies.Complete();
      using (NativeArray<ArchetypeChunk> archetypeChunkArray = entityQuery.ToArchetypeChunkArray((AllocatorManager.AllocatorHandle) Allocator.TempJob))
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Unity_Entities_Entity_TypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        EntityTypeHandle entityTypeHandle = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Deleted_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<Deleted> componentTypeHandle1 = this.__TypeHandle.__Game_Common_Deleted_RO_ComponentTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Created_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<Created> componentTypeHandle2 = this.__TypeHandle.__Game_Common_Created_RO_ComponentTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Applied_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<Applied> componentTypeHandle3 = this.__TypeHandle.__Game_Common_Applied_RO_ComponentTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Pathfind_PathUpdated_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<PathUpdated> componentTypeHandle4 = this.__TypeHandle.__Game_Pathfind_PathUpdated_RO_ComponentTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<PrefabRef> componentTypeHandle5 = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Rendering_RouteBufferIndex_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentTypeHandle<RouteBufferIndex> componentTypeHandle6 = this.__TypeHandle.__Game_Rendering_RouteBufferIndex_RW_ComponentTypeHandle;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Routes_Segment_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentLookup<Game.Routes.Segment> roComponentLookup1 = this.__TypeHandle.__Game_Routes_Segment_RO_ComponentLookup;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentLookup<Owner> roComponentLookup2 = this.__TypeHandle.__Game_Common_Owner_RO_ComponentLookup;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.__TypeHandle.__Game_Common_Deleted_RO_ComponentLookup.Update(ref this.CheckedStateRef);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        ComponentLookup<Deleted> roComponentLookup3 = this.__TypeHandle.__Game_Common_Deleted_RO_ComponentLookup;
        for (int index1 = 0; index1 < archetypeChunkArray.Length; ++index1)
        {
          ArchetypeChunk archetypeChunk = archetypeChunkArray[index1];
          NativeArray<PathUpdated> nativeArray1 = archetypeChunk.GetNativeArray<PathUpdated>(ref componentTypeHandle4);
          if (nativeArray1.Length != 0)
          {
            for (int index2 = 0; index2 < nativeArray1.Length; ++index2)
            {
              PathUpdated pathUpdated = nativeArray1[index2];
              if (roComponentLookup1.HasComponent(pathUpdated.m_Owner) && roComponentLookup2.HasComponent(pathUpdated.m_Owner) && !roComponentLookup3.HasComponent(pathUpdated.m_Owner))
              {
                if (entitySet == null)
                  entitySet = new HashSet<Entity>();
                entitySet.Add(roComponentLookup2[pathUpdated.m_Owner].m_Owner);
              }
            }
          }
          else if (archetypeChunk.Has<Deleted>(ref componentTypeHandle1))
          {
            NativeArray<RouteBufferIndex> nativeArray2 = archetypeChunk.GetNativeArray<RouteBufferIndex>(ref componentTypeHandle6);
            // ISSUE: reference to a compiler-generated field
            if (this.m_FreeBufferIndices == null)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_FreeBufferIndices = new Stack<int>(nativeArray2.Length);
            }
            for (int index3 = 0; index3 < nativeArray2.Length; ++index3)
            {
              RouteBufferIndex routeBufferIndex = nativeArray2[index3];
              // ISSUE: reference to a compiler-generated field
              // ISSUE: variable of a compiler-generated type
              RouteBufferSystem.ManagedData managedData = this.m_ManagedData[routeBufferIndex.m_Index];
              // ISSUE: reference to a compiler-generated field
              ref RouteBufferSystem.NativeData local = ref this.m_NativeData.ElementAt(routeBufferIndex.m_Index);
              // ISSUE: reference to a compiler-generated field
              managedData.m_Updated = false;
              // ISSUE: reference to a compiler-generated field
              local.m_Updated = false;
              // ISSUE: reference to a compiler-generated field
              this.m_FreeBufferIndices.Push(routeBufferIndex.m_Index);
              routeBufferIndex.m_Index = -1;
              nativeArray2[index3] = routeBufferIndex;
            }
          }
          else if (loaded || archetypeChunk.Has<Created>(ref componentTypeHandle2) && !archetypeChunk.Has<Applied>(ref componentTypeHandle3))
          {
            NativeArray<Entity> nativeArray3 = archetypeChunk.GetNativeArray(entityTypeHandle);
            NativeArray<RouteBufferIndex> nativeArray4 = archetypeChunk.GetNativeArray<RouteBufferIndex>(ref componentTypeHandle6);
            NativeArray<PrefabRef> nativeArray5 = archetypeChunk.GetNativeArray<PrefabRef>(ref componentTypeHandle5);
            // ISSUE: reference to a compiler-generated field
            if (this.m_ManagedData == null)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_ManagedData = new List<RouteBufferSystem.ManagedData>(nativeArray4.Length);
            }
            // ISSUE: reference to a compiler-generated field
            if (!this.m_NativeData.IsCreated)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_NativeData = new NativeList<RouteBufferSystem.NativeData>(nativeArray4.Length, (AllocatorManager.AllocatorHandle) Allocator.Persistent);
            }
            if (entitySet == null)
              entitySet = new HashSet<Entity>();
            for (int index4 = 0; index4 < nativeArray4.Length; ++index4)
            {
              Entity entity1 = nativeArray3[index4];
              RouteBufferIndex routeBufferIndex = nativeArray4[index4];
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              RoutePrefab prefab = this.m_PrefabSystem.GetPrefab<RoutePrefab>(nativeArray5[index4]);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (this.m_FreeBufferIndices != null && this.m_FreeBufferIndices.Count > 0)
              {
                // ISSUE: reference to a compiler-generated field
                routeBufferIndex.m_Index = this.m_FreeBufferIndices.Pop();
                // ISSUE: reference to a compiler-generated field
                // ISSUE: variable of a compiler-generated type
                RouteBufferSystem.ManagedData managedData = this.m_ManagedData[routeBufferIndex.m_Index];
                // ISSUE: reference to a compiler-generated field
                ref RouteBufferSystem.NativeData local = ref this.m_NativeData.ElementAt(routeBufferIndex.m_Index);
                // ISSUE: reference to a compiler-generated method
                managedData.Initialize(prefab);
                Entity entity2 = entity1;
                // ISSUE: reference to a compiler-generated method
                local.Initialize(entity2);
              }
              else
              {
                // ISSUE: reference to a compiler-generated field
                routeBufferIndex.m_Index = this.m_ManagedData.Count;
                // ISSUE: object of a compiler-generated type is created
                // ISSUE: variable of a compiler-generated type
                RouteBufferSystem.ManagedData managedData = new RouteBufferSystem.ManagedData();
                // ISSUE: object of a compiler-generated type is created
                // ISSUE: variable of a compiler-generated type
                RouteBufferSystem.NativeData nativeData = new RouteBufferSystem.NativeData();
                // ISSUE: reference to a compiler-generated method
                managedData.Initialize(prefab);
                // ISSUE: reference to a compiler-generated method
                nativeData.Initialize(entity1);
                // ISSUE: reference to a compiler-generated field
                this.m_ManagedData.Add(managedData);
                // ISSUE: reference to a compiler-generated field
                this.m_NativeData.Add(in nativeData);
              }
              nativeArray4[index4] = routeBufferIndex;
              entitySet.Add(entity1);
            }
          }
          else
          {
            NativeArray<Entity> nativeArray6 = archetypeChunk.GetNativeArray(entityTypeHandle);
            if (entitySet == null)
              entitySet = new HashSet<Entity>();
            for (int index5 = 0; index5 < nativeArray6.Length; ++index5)
              entitySet.Add(nativeArray6[index5]);
          }
        }
      }
      if (entitySet == null)
        return;
      foreach (Entity entity in entitySet)
      {
        RouteBufferIndex componentData = this.EntityManager.GetComponentData<RouteBufferIndex>(entity);
        if (componentData.m_Index >= 0)
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: variable of a compiler-generated type
          RouteBufferSystem.ManagedData managedData = this.m_ManagedData[componentData.m_Index];
          // ISSUE: reference to a compiler-generated field
          ref RouteBufferSystem.NativeData local = ref this.m_NativeData.ElementAt(componentData.m_Index);
          // ISSUE: reference to a compiler-generated field
          managedData.m_Updated = true;
          // ISSUE: reference to a compiler-generated field
          local.m_Updated = true;
          // ISSUE: reference to a compiler-generated field
          if (!local.m_SegmentData.IsCreated)
          {
            // ISSUE: reference to a compiler-generated field
            local.m_SegmentData = new UnsafeList<RouteBufferSystem.SegmentData>(0, (AllocatorManager.AllocatorHandle) Allocator.Persistent);
          }
        }
      }
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_CurveElement_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_RouteSegment_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_RouteWaypoint_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Routes_Position_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
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
      RouteBufferSystem.UpdateBufferJob jobData = new RouteBufferSystem.UpdateBufferJob()
      {
        m_PositionData = this.__TypeHandle.__Game_Routes_Position_RO_ComponentLookup,
        m_RouteWaypoints = this.__TypeHandle.__Game_Routes_RouteWaypoint_RO_BufferLookup,
        m_RouteSegments = this.__TypeHandle.__Game_Routes_RouteSegment_RO_BufferLookup,
        m_CurveElements = this.__TypeHandle.__Game_Routes_CurveElement_RO_BufferLookup,
        m_PathElements = this.__TypeHandle.__Game_Pathfind_PathElement_RO_BufferLookup,
        m_NativeData = this.m_NativeData
      };
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.m_BufferDependencies = jobData.Schedule<RouteBufferSystem.UpdateBufferJob>(this.m_NativeData.Length, 1, this.Dependency);
      // ISSUE: reference to a compiler-generated field
      this.Dependency = this.m_BufferDependencies;
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
    public RouteBufferSystem()
    {
    }

    private class ManagedData : IDisposable
    {
      public Material m_Material;
      public ComputeBuffer m_SegmentBuffer;
      public Vector4 m_Size;
      public int m_OriginalRenderQueue;
      public bool m_Updated;

      public void Initialize(RoutePrefab routePrefab)
      {
        // ISSUE: reference to a compiler-generated field
        if ((UnityEngine.Object) this.m_Material != (UnityEngine.Object) null)
        {
          // ISSUE: reference to a compiler-generated field
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_Material);
        }
        // ISSUE: reference to a compiler-generated field
        this.m_Material = new Material(routePrefab.m_Material);
        // ISSUE: reference to a compiler-generated field
        this.m_Material.name = "Routes (" + routePrefab.name + ")";
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        this.m_OriginalRenderQueue = this.m_Material.renderQueue;
        // ISSUE: reference to a compiler-generated field
        this.m_Size = new Vector4(routePrefab.m_Width, routePrefab.m_Width * 0.25f, routePrefab.m_SegmentLength, 0.0f);
      }

      public void Dispose()
      {
        // ISSUE: reference to a compiler-generated field
        if ((UnityEngine.Object) this.m_Material != (UnityEngine.Object) null)
        {
          // ISSUE: reference to a compiler-generated field
          UnityEngine.Object.Destroy((UnityEngine.Object) this.m_Material);
        }
        // ISSUE: reference to a compiler-generated field
        if (this.m_SegmentBuffer == null)
          return;
        // ISSUE: reference to a compiler-generated field
        this.m_SegmentBuffer.Release();
      }
    }

    private struct NativeData : IDisposable
    {
      public UnsafeList<RouteBufferSystem.SegmentData> m_SegmentData;
      public Bounds3 m_Bounds;
      public Entity m_Entity;
      public float m_Length;
      public bool m_Updated;

      public void Initialize(Entity entity) => this.m_Entity = entity;

      public void Dispose()
      {
        // ISSUE: reference to a compiler-generated field
        if (!this.m_SegmentData.IsCreated)
          return;
        // ISSUE: reference to a compiler-generated field
        this.m_SegmentData.Dispose();
      }
    }

    private struct SegmentData
    {
      public Matrix4x4 m_Curve;
      public Vector3 m_Position;
      public Vector2 m_Opacity;
      public float m_Broken;
    }

    [BurstCompile]
    private struct UpdateBufferJob : IJobParallelFor
    {
      [ReadOnly]
      public ComponentLookup<Position> m_PositionData;
      [ReadOnly]
      public BufferLookup<RouteWaypoint> m_RouteWaypoints;
      [ReadOnly]
      public BufferLookup<RouteSegment> m_RouteSegments;
      [ReadOnly]
      public BufferLookup<CurveElement> m_CurveElements;
      [ReadOnly]
      public BufferLookup<PathElement> m_PathElements;
      [NativeDisableParallelForRestriction]
      public NativeList<RouteBufferSystem.NativeData> m_NativeData;

      public void Execute(int index)
      {
        // ISSUE: reference to a compiler-generated field
        ref RouteBufferSystem.NativeData local = ref this.m_NativeData.ElementAt(index);
        // ISSUE: reference to a compiler-generated field
        if (!local.m_Updated)
          return;
        // ISSUE: reference to a compiler-generated field
        local.m_Updated = false;
        // ISSUE: reference to a compiler-generated field
        local.m_SegmentData.Clear();
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        DynamicBuffer<RouteWaypoint> routeWaypoint = this.m_RouteWaypoints[local.m_Entity];
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        DynamicBuffer<RouteSegment> routeSegment = this.m_RouteSegments[local.m_Entity];
        float x1 = 0.0f;
        Bounds3 bounds3 = new Bounds3((float3) float.MaxValue, (float3) float.MinValue);
        for (int index1 = 0; index1 < routeSegment.Length; ++index1)
        {
          Entity segment = routeSegment[index1].m_Segment;
          if (!(segment == Entity.Null))
          {
            float broken = 0.0f;
            // ISSUE: reference to a compiler-generated field
            if (this.m_PathElements.HasBuffer(segment))
            {
              // ISSUE: reference to a compiler-generated field
              broken = math.select(0.0f, 1f, this.m_PathElements[segment].Length == 0);
            }
            // ISSUE: reference to a compiler-generated field
            DynamicBuffer<CurveElement> curveElement1 = this.m_CurveElements[segment];
            if (curveElement1.Length > 0)
            {
              float3 y1 = new float3();
              float3 y2 = math.normalizesafe(MathUtils.StartTangent(curveElement1[0].m_Curve));
              for (int index2 = 0; index2 < curveElement1.Length; ++index2)
              {
                CurveElement curveElement2 = curveElement1[index2];
                float3 x2 = y2;
                float3 x3 = math.normalizesafe(MathUtils.EndTangent(curveElement2.m_Curve));
                y2 = index2 + 1 >= curveElement1.Length ? new float3() : math.normalizesafe(MathUtils.StartTangent(curveElement1[index2 + 1].m_Curve));
                float num = MathUtils.Length(curveElement2.m_Curve);
                float2 offset = new float2(x1, x1 + num);
                float2 opacity = math.select((float2) 1f, (float2) 0.0f, new bool2((double) math.dot(x2, y1) < 0.99900001287460327, (double) math.dot(x3, y2) < 0.99900001287460327));
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated method
                this.AddSegment(ref local.m_SegmentData, curveElement2.m_Curve, offset, opacity, broken);
                x1 = offset.y;
                bounds3 |= MathUtils.Bounds(curveElement2.m_Curve);
                y1 = x3;
              }
            }
          }
        }
        for (int index3 = 0; index3 < routeWaypoint.Length; ++index3)
        {
          // ISSUE: reference to a compiler-generated field
          float3 position = this.m_PositionData[routeWaypoint[index3].m_Waypoint].m_Position;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          this.AddNode(ref local.m_SegmentData, position, 1f);
          bounds3 |= position;
        }
        // ISSUE: reference to a compiler-generated field
        local.m_Bounds = bounds3;
        // ISSUE: reference to a compiler-generated field
        local.m_Length = x1;
      }

      private void AddSegment(
        ref UnsafeList<RouteBufferSystem.SegmentData> segments,
        Bezier4x3 curve,
        float2 offset,
        float2 opacity,
        float broken)
      {
        float3 float3 = math.lerp(curve.a, curve.d, 0.5f);
        // ISSUE: variable of a compiler-generated type
        RouteBufferSystem.SegmentData segmentData;
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Curve = (Matrix4x4) new float4x4()
        {
          c0 = new float4(curve.a - float3, offset.x),
          c1 = new float4(curve.b - float3, offset.x + math.distance(curve.a, curve.b)),
          c2 = new float4(curve.c - float3, offset.y - math.distance(curve.c, curve.d)),
          c3 = new float4(curve.d - float3, offset.y)
        };
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Position = (Vector3) float3;
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Opacity = (Vector2) opacity;
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Broken = broken;
        segments.Add(in segmentData);
      }

      private void AddNode(
        ref UnsafeList<RouteBufferSystem.SegmentData> segments,
        float3 position,
        float opacity)
      {
        // ISSUE: variable of a compiler-generated type
        RouteBufferSystem.SegmentData segmentData;
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Curve = (Matrix4x4) new float4x4()
        {
          c0 = new float4(0.0f, 0.0f, -1f, -1000000f),
          c1 = new float4(0.0f, 0.0f, -0.333333343f, -1000000f),
          c2 = new float4(0.0f, 0.0f, 0.333333343f, -1000000f),
          c3 = new float4(0.0f, 0.0f, 1f, -1000000f)
        };
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Position = (Vector3) position;
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Opacity = new Vector2(opacity, opacity);
        // ISSUE: reference to a compiler-generated field
        segmentData.m_Broken = 0.0f;
        segments.Add(in segmentData);
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Deleted> __Game_Common_Deleted_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Created> __Game_Common_Created_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<Applied> __Game_Common_Applied_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PathUpdated> __Game_Pathfind_PathUpdated_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentTypeHandle;
      public ComponentTypeHandle<RouteBufferIndex> __Game_Rendering_RouteBufferIndex_RW_ComponentTypeHandle;
      [ReadOnly]
      public ComponentLookup<Game.Routes.Segment> __Game_Routes_Segment_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Owner> __Game_Common_Owner_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Deleted> __Game_Common_Deleted_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Position> __Game_Routes_Position_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<RouteWaypoint> __Game_Routes_RouteWaypoint_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<RouteSegment> __Game_Routes_RouteSegment_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<CurveElement> __Game_Routes_CurveElement_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<PathElement> __Game_Pathfind_PathElement_RO_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Deleted_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Deleted>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Created_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Created>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Applied_RO_ComponentTypeHandle = state.GetComponentTypeHandle<Applied>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathUpdated_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PathUpdated>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Rendering_RouteBufferIndex_RW_ComponentTypeHandle = state.GetComponentTypeHandle<RouteBufferIndex>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_Segment_RO_ComponentLookup = state.GetComponentLookup<Game.Routes.Segment>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Owner_RO_ComponentLookup = state.GetComponentLookup<Owner>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Common_Deleted_RO_ComponentLookup = state.GetComponentLookup<Deleted>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_Position_RO_ComponentLookup = state.GetComponentLookup<Position>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_RouteWaypoint_RO_BufferLookup = state.GetBufferLookup<RouteWaypoint>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_RouteSegment_RO_BufferLookup = state.GetBufferLookup<RouteSegment>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Routes_CurveElement_RO_BufferLookup = state.GetBufferLookup<CurveElement>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Pathfind_PathElement_RO_BufferLookup = state.GetBufferLookup<PathElement>(true);
      }
    }
  }
}

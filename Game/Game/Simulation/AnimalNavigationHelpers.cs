﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.AnimalNavigationHelpers
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Colossal.Mathematics;
using Game.Areas;
using Game.Common;
using Game.Creatures;
using Game.Net;
using Game.Objects;
using Game.Prefabs;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public static class AnimalNavigationHelpers
  {
    public struct CurrentLaneCache
    {
      private NativeQuadTree<Entity, QuadTreeBoundsXZ> m_SearchTree;
      private Entity m_WasCurrentLane;
      private float m_WasCurvePosition;
      private bool m_WasEndReached;

      public CurrentLaneCache(
        ref AnimalCurrentLane currentLane,
        ComponentLookup<PrefabRef> prefabRefData,
        NativeQuadTree<Entity, QuadTreeBoundsXZ> searchTree)
      {
        if (!prefabRefData.HasComponent(currentLane.m_Lane))
          currentLane.m_Lane = Entity.Null;
        if (currentLane.m_NextLane != Entity.Null && !prefabRefData.HasComponent(currentLane.m_NextLane))
          currentLane.m_NextLane = Entity.Null;
        this.m_SearchTree = searchTree;
        this.m_WasCurrentLane = currentLane.m_Lane;
        this.m_WasCurvePosition = currentLane.m_CurvePosition.x;
        this.m_WasEndReached = (currentLane.m_Flags & CreatureLaneFlags.EndReached) > (CreatureLaneFlags) 0;
      }

      public void CheckChanges(
        Entity entity,
        ref AnimalCurrentLane currentLane,
        LaneObjectCommandBuffer buffer,
        BufferLookup<LaneObject> laneObjects,
        Transform transform,
        Moving moving,
        AnimalNavigation navigation,
        ObjectGeometryData objectGeometryData)
      {
        if (currentLane.m_Lane != this.m_WasCurrentLane)
        {
          if (laneObjects.HasBuffer(this.m_WasCurrentLane))
            buffer.Remove(this.m_WasCurrentLane, entity);
          else
            buffer.Remove(entity);
          if (laneObjects.HasBuffer(currentLane.m_Lane))
            buffer.Add(currentLane.m_Lane, entity, currentLane.m_CurvePosition.xx);
          else
            buffer.Add(entity, this.CalculateMaxBounds(transform, moving, navigation, objectGeometryData));
        }
        else if (laneObjects.HasBuffer(this.m_WasCurrentLane))
        {
          if (this.m_WasCurvePosition.Equals(currentLane.m_CurvePosition.x))
            return;
          buffer.Update(this.m_WasCurrentLane, entity, currentLane.m_CurvePosition.xx);
        }
        else
        {
          QuadTreeBoundsXZ bounds;
          if (!this.m_SearchTree.TryGet(entity, out bounds))
            return;
          Bounds3 minBounds = this.CalculateMinBounds(transform, moving, navigation, objectGeometryData);
          if (!(math.any(minBounds.min < bounds.m_Bounds.min) | math.any(minBounds.max > bounds.m_Bounds.max) | (currentLane.m_Flags & CreatureLaneFlags.EndReached) > (CreatureLaneFlags) 0 & !this.m_WasEndReached))
            return;
          buffer.Update(entity, this.CalculateMaxBounds(transform, moving, navigation, objectGeometryData));
        }
      }

      private Bounds3 CalculateMinBounds(
        Transform transform,
        Moving moving,
        AnimalNavigation navigation,
        ObjectGeometryData objectGeometryData)
      {
        float num = 0.266666681f;
        float3 x = moving.m_Velocity * num;
        float3 y = math.normalizesafe(navigation.m_TargetPosition - transform.m_Position) * (navigation.m_MaxSpeed * num);
        Bounds3 bounds = ObjectUtils.CalculateBounds(transform.m_Position, transform.m_Rotation, objectGeometryData);
        bounds.min += math.min((float3) 0.0f, math.min(x, y));
        bounds.max += math.max((float3) 0.0f, math.max(x, y));
        return bounds;
      }

      private Bounds3 CalculateMaxBounds(
        Transform transform,
        Moving moving,
        AnimalNavigation navigation,
        ObjectGeometryData objectGeometryData)
      {
        float num1 = -1.06666672f;
        float num2 = 2f;
        float num3 = math.length(objectGeometryData.m_Size) * 0.5f;
        float3 x1 = moving.m_Velocity * num1;
        float3 x2 = moving.m_Velocity * num2;
        float3 y = math.normalizesafe(navigation.m_TargetPosition - transform.m_Position) * (navigation.m_MaxSpeed * num2);
        float3 position = transform.m_Position;
        position.y += objectGeometryData.m_Size.y * 0.5f;
        Bounds3 maxBounds;
        maxBounds.min = position - num3 + math.min(x1, math.min(x2, y));
        maxBounds.max = position + num3 + math.max(x1, math.max(x2, y));
        return maxBounds;
      }
    }

    public struct FindLaneIterator : 
      INativeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
      IUnsafeQuadTreeIterator<Entity, QuadTreeBoundsXZ>,
      INativeQuadTreeIterator<AreaSearchItem, QuadTreeBoundsXZ>,
      IUnsafeQuadTreeIterator<AreaSearchItem, QuadTreeBoundsXZ>
    {
      public Bounds3 m_Bounds;
      public float3 m_Position;
      public float m_MinDistance;
      public bool m_UnspawnedEmerge;
      public AnimalCurrentLane m_Result;
      public BufferLookup<Game.Net.SubLane> m_SubLanes;
      public BufferLookup<Game.Areas.Node> m_AreaNodes;
      public BufferLookup<Triangle> m_AreaTriangles;
      public ComponentLookup<Game.Net.PedestrianLane> m_PedestrianLaneData;
      public ComponentLookup<Game.Net.ConnectionLane> m_ConnectionLaneData;
      public ComponentLookup<Curve> m_CurveData;
      public ComponentLookup<HangaroundLocation> m_HangaroundLocationData;

      public bool Intersect(QuadTreeBoundsXZ bounds)
      {
        return MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds);
      }

      public void Iterate(QuadTreeBoundsXZ bounds, Entity ownerEntity)
      {
        if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_SubLanes.HasBuffer(ownerEntity))
          return;
        DynamicBuffer<Game.Net.SubLane> subLane1 = this.m_SubLanes[ownerEntity];
        for (int index = 0; index < subLane1.Length; ++index)
        {
          Entity subLane2 = subLane1[index].m_SubLane;
          CreatureLaneFlags creatureLaneFlags = this.m_Result.m_Flags & ~(CreatureLaneFlags.Connection | CreatureLaneFlags.Area | CreatureLaneFlags.Hangaround);
          if (!this.m_PedestrianLaneData.HasComponent(subLane2))
          {
            if (this.m_ConnectionLaneData.HasComponent(subLane2) && (this.m_ConnectionLaneData[subLane2].m_Flags & ConnectionLaneFlags.Pedestrian) != (ConnectionLaneFlags) 0)
              creatureLaneFlags |= CreatureLaneFlags.Connection;
            else
              continue;
          }
          if (!this.m_UnspawnedEmerge || (creatureLaneFlags & CreatureLaneFlags.Connection) != (CreatureLaneFlags) 0)
          {
            Bezier4x3 bezier = this.m_CurveData[subLane2].m_Bezier;
            if ((double) MathUtils.Distance(MathUtils.Bounds(bezier), this.m_Position) < (double) this.m_MinDistance)
            {
              float t;
              float num = MathUtils.Distance(bezier, this.m_Position, out t);
              if ((double) num < (double) this.m_MinDistance)
              {
                this.m_Bounds = new Bounds3(this.m_Position - num, this.m_Position + num);
                this.m_MinDistance = num;
                this.m_Result.m_Lane = subLane2;
                this.m_Result.m_CurvePosition = (float2) t;
                this.m_Result.m_Flags = creatureLaneFlags;
              }
            }
          }
        }
      }

      public void Iterate(QuadTreeBoundsXZ bounds, AreaSearchItem item)
      {
        if (!MathUtils.Intersect(bounds.m_Bounds, this.m_Bounds) || !this.m_SubLanes.HasBuffer(item.m_Area))
          return;
        Triangle3 triangle3 = AreaUtils.GetTriangle3(this.m_AreaNodes[item.m_Area], this.m_AreaTriangles[item.m_Area][item.m_Triangle]);
        float2 t1;
        float num1 = MathUtils.Distance(triangle3, this.m_Position, out t1);
        if ((double) num1 >= (double) this.m_MinDistance)
          return;
        float3 position = MathUtils.Position(triangle3, t1);
        DynamicBuffer<Game.Net.SubLane> subLane1 = this.m_SubLanes[item.m_Area];
        float num2 = float.MaxValue;
        Entity entity = Entity.Null;
        float num3 = 0.0f;
        CreatureLaneFlags creatureLaneFlags1 = (CreatureLaneFlags) 0;
        CreatureLaneFlags creatureLaneFlags2 = this.m_Result.m_Flags & ~(CreatureLaneFlags.Connection | CreatureLaneFlags.Hangaround) | CreatureLaneFlags.Area;
        if (this.m_HangaroundLocationData.HasComponent(item.m_Area))
          creatureLaneFlags2 |= CreatureLaneFlags.Hangaround;
        for (int index = 0; index < subLane1.Length; ++index)
        {
          Entity subLane2 = subLane1[index].m_SubLane;
          if (this.m_ConnectionLaneData.HasComponent(subLane2) && (this.m_ConnectionLaneData[subLane2].m_Flags & ConnectionLaneFlags.Pedestrian) != (ConnectionLaneFlags) 0)
          {
            Curve curve = this.m_CurveData[subLane2];
            float2 t2;
            if (MathUtils.Intersect(triangle3.xz, curve.m_Bezier.a.xz, out t2) || MathUtils.Intersect(triangle3.xz, curve.m_Bezier.d.xz, out t2))
            {
              float t3;
              float num4 = MathUtils.Distance(curve.m_Bezier, position, out t3);
              if ((double) num4 < (double) num2)
              {
                num2 = num4;
                entity = subLane2;
                num3 = t3;
                creatureLaneFlags1 = creatureLaneFlags2;
              }
            }
          }
        }
        if (!(entity != Entity.Null))
          return;
        this.m_Bounds = new Bounds3(this.m_Position - num1, this.m_Position + num1);
        this.m_MinDistance = num1;
        this.m_Result.m_Lane = entity;
        this.m_Result.m_CurvePosition = (float2) num3;
        this.m_Result.m_Flags = creatureLaneFlags1;
      }
    }
  }
}
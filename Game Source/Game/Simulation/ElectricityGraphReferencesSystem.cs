﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.ElectricityGraphReferencesSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Collections;
using Game.Common;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  [CompilerGenerated]
  public class ElectricityGraphReferencesSystem : GameSystemBase
  {
    private EntityQuery m_EdgeGroup;
    private ElectricityGraphReferencesSystem.TypeHandle __TypeHandle;

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_EdgeGroup = this.GetEntityQuery(new EntityQueryDesc()
      {
        All = new ComponentType[1]
        {
          ComponentType.ReadOnly<ElectricityFlowEdge>()
        },
        Any = new ComponentType[1]
        {
          ComponentType.ReadOnly<Deleted>()
        }
      });
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_EdgeGroup);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ConnectedFlowEdge_RW_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_ElectricityFlowEdge_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
      ElectricityGraphReferencesSystem.UpdateGraphReferencesJob jobData = new ElectricityGraphReferencesSystem.UpdateGraphReferencesJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_ElectricityFlowEdgeType = this.__TypeHandle.__Game_Simulation_ElectricityFlowEdge_RO_ComponentTypeHandle,
        m_ConnectedFlowEdges = this.__TypeHandle.__Game_Simulation_ConnectedFlowEdge_RW_BufferLookup
      };
      // ISSUE: reference to a compiler-generated field
      this.Dependency = jobData.Schedule<ElectricityGraphReferencesSystem.UpdateGraphReferencesJob>(this.m_EdgeGroup, this.Dependency);
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
    public ElectricityGraphReferencesSystem()
    {
    }

    [BurstCompile]
    public struct UpdateGraphReferencesJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      [ReadOnly]
      public ComponentTypeHandle<ElectricityFlowEdge> m_ElectricityFlowEdgeType;
      public BufferLookup<ConnectedFlowEdge> m_ConnectedFlowEdges;

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<ElectricityFlowEdge> nativeArray2 = chunk.GetNativeArray<ElectricityFlowEdge>(ref this.m_ElectricityFlowEdgeType);
        for (int index = 0; index < nativeArray2.Length; ++index)
        {
          Entity edge = nativeArray1[index];
          ElectricityFlowEdge electricityFlowEdge = nativeArray2[index];
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<ConnectedFlowEdge> connectedFlowEdge1 = this.m_ConnectedFlowEdges[electricityFlowEdge.m_Start];
          // ISSUE: reference to a compiler-generated field
          DynamicBuffer<ConnectedFlowEdge> connectedFlowEdge2 = this.m_ConnectedFlowEdges[electricityFlowEdge.m_End];
          CollectionUtils.RemoveValue<ConnectedFlowEdge>(connectedFlowEdge1, new ConnectedFlowEdge(edge));
          ConnectedFlowEdge connectedFlowEdge3 = new ConnectedFlowEdge(edge);
          CollectionUtils.RemoveValue<ConnectedFlowEdge>(connectedFlowEdge2, connectedFlowEdge3);
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
      public ComponentTypeHandle<ElectricityFlowEdge> __Game_Simulation_ElectricityFlowEdge_RO_ComponentTypeHandle;
      public BufferLookup<ConnectedFlowEdge> __Game_Simulation_ConnectedFlowEdge_RW_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ElectricityFlowEdge_RO_ComponentTypeHandle = state.GetComponentTypeHandle<ElectricityFlowEdge>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_ConnectedFlowEdge_RW_BufferLookup = state.GetBufferLookup<ConnectedFlowEdge>();
      }
    }
  }
}
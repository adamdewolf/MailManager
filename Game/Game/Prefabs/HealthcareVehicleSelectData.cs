﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.HealthcareVehicleSelectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Game.Common;
using Game.Net;
using Game.Objects;
using Game.Simulation;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct HealthcareVehicleSelectData
  {
    private NativeList<ArchetypeChunk> m_PrefabChunks;
    private VehicleSelectRequirementData m_RequirementData;
    private EntityTypeHandle m_EntityType;
    private ComponentTypeHandle<AmbulanceData> m_AmbulanceType;
    private ComponentTypeHandle<HearseData> m_HearseType;
    private ComponentTypeHandle<CarData> m_CarType;
    private ComponentTypeHandle<HelicopterData> m_HelicopterType;
    private ComponentLookup<ObjectData> m_ObjectData;

    public static EntityQueryDesc GetEntityQueryDesc()
    {
      return new EntityQueryDesc()
      {
        All = new ComponentType[3]
        {
          ComponentType.ReadOnly<VehicleData>(),
          ComponentType.ReadOnly<ObjectData>(),
          ComponentType.ReadOnly<PrefabData>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<AmbulanceData>(),
          ComponentType.ReadOnly<HearseData>()
        },
        None = new ComponentType[1]
        {
          ComponentType.ReadOnly<Locked>()
        }
      };
    }

    public HealthcareVehicleSelectData(SystemBase system)
    {
      this.m_PrefabChunks = new NativeList<ArchetypeChunk>();
      this.m_RequirementData = new VehicleSelectRequirementData(system);
      this.m_EntityType = system.GetEntityTypeHandle();
      this.m_AmbulanceType = system.GetComponentTypeHandle<AmbulanceData>(true);
      this.m_HearseType = system.GetComponentTypeHandle<HearseData>(true);
      this.m_CarType = system.GetComponentTypeHandle<CarData>(true);
      this.m_HelicopterType = system.GetComponentTypeHandle<HelicopterData>(true);
      this.m_ObjectData = system.GetComponentLookup<ObjectData>(true);
    }

    public void PreUpdate(
      SystemBase system,
      CityConfigurationSystem cityConfigurationSystem,
      EntityQuery query,
      Allocator allocator,
      out JobHandle jobHandle)
    {
      this.m_PrefabChunks = query.ToArchetypeChunkListAsync((AllocatorManager.AllocatorHandle) allocator, out jobHandle);
      this.m_RequirementData.Update(system, cityConfigurationSystem);
      this.m_EntityType.Update(system);
      this.m_AmbulanceType.Update(system);
      this.m_HearseType.Update(system);
      this.m_CarType.Update(system);
      this.m_HelicopterType.Update(system);
      this.m_ObjectData.Update(system);
    }

    public void PostUpdate(JobHandle jobHandle) => this.m_PrefabChunks.Dispose(jobHandle);

    public Entity CreateVehicle(
      EntityCommandBuffer.ParallelWriter commandBuffer,
      int jobIndex,
      ref Random random,
      Transform transform,
      Entity source,
      HealthcareRequestType healthcareType,
      RoadTypes roadType)
    {
      Entity randomVehicle = this.GetRandomVehicle(ref random, healthcareType, roadType);
      if (randomVehicle == Entity.Null)
        return Entity.Null;
      ObjectData objectData = this.m_ObjectData[randomVehicle];
      Entity entity = commandBuffer.CreateEntity(jobIndex, objectData.m_Archetype);
      commandBuffer.SetComponent<Transform>(jobIndex, entity, transform);
      commandBuffer.SetComponent<PrefabRef>(jobIndex, entity, new PrefabRef(randomVehicle));
      commandBuffer.SetComponent<PseudoRandomSeed>(jobIndex, entity, new PseudoRandomSeed(ref random));
      commandBuffer.AddComponent<TripSource>(jobIndex, entity, new TripSource(source));
      commandBuffer.AddComponent<Unspawned>(jobIndex, entity, new Unspawned());
      return entity;
    }

    private Entity GetRandomVehicle(
      ref Random random,
      HealthcareRequestType healthcareType,
      RoadTypes roadType)
    {
      Entity randomVehicle = Entity.Null;
      int totalProbability = 0;
      for (int index1 = 0; index1 < this.m_PrefabChunks.Length; ++index1)
      {
        ArchetypeChunk prefabChunk = this.m_PrefabChunks[index1];
        switch (healthcareType)
        {
          case HealthcareRequestType.Ambulance:
            if (prefabChunk.Has<AmbulanceData>(ref this.m_AmbulanceType))
              goto default;
            else
              break;
          case HealthcareRequestType.Hearse:
            if (!prefabChunk.Has<HearseData>(ref this.m_HearseType))
              break;
            goto default;
          default:
            switch (roadType)
            {
              case RoadTypes.Car:
                if (prefabChunk.Has<CarData>(ref this.m_CarType))
                  break;
                continue;
              case RoadTypes.Helicopter:
                if (!prefabChunk.Has<HelicopterData>(ref this.m_HelicopterType))
                  continue;
                break;
              default:
                continue;
            }
            NativeArray<Entity> nativeArray = prefabChunk.GetNativeArray(this.m_EntityType);
            VehicleSelectRequirementData.Chunk chunk = this.m_RequirementData.GetChunk(prefabChunk);
            for (int index2 = 0; index2 < nativeArray.Length; ++index2)
            {
              if (this.m_RequirementData.CheckRequirements(ref chunk, index2) && this.PickVehicle(ref random, 100, ref totalProbability))
                randomVehicle = nativeArray[index2];
            }
            break;
        }
      }
      return randomVehicle;
    }

    private bool PickVehicle(ref Random random, int probability, ref int totalProbability)
    {
      totalProbability += probability;
      return random.NextInt(totalProbability) < probability;
    }
  }
}
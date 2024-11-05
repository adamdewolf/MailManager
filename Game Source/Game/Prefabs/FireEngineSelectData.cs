// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.FireEngineSelectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Game.Common;
using Game.Net;
using Game.Objects;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct FireEngineSelectData
  {
    private NativeList<ArchetypeChunk> m_PrefabChunks;
    private VehicleSelectRequirementData m_RequirementData;
    private EntityTypeHandle m_EntityType;
    private ComponentTypeHandle<FireEngineData> m_FireEngineType;
    private ComponentTypeHandle<CarData> m_CarType;
    private ComponentTypeHandle<HelicopterData> m_HelicopterType;
    private ComponentLookup<ObjectData> m_ObjectData;

    public static EntityQueryDesc GetEntityQueryDesc()
    {
      return new EntityQueryDesc()
      {
        All = new ComponentType[3]
        {
          ComponentType.ReadOnly<FireEngineData>(),
          ComponentType.ReadOnly<ObjectData>(),
          ComponentType.ReadOnly<PrefabData>()
        },
        Any = new ComponentType[2]
        {
          ComponentType.ReadOnly<CarData>(),
          ComponentType.ReadOnly<HelicopterData>()
        },
        None = new ComponentType[1]
        {
          ComponentType.ReadOnly<Locked>()
        }
      };
    }

    public FireEngineSelectData(SystemBase system)
    {
      this.m_PrefabChunks = new NativeList<ArchetypeChunk>();
      this.m_RequirementData = new VehicleSelectRequirementData(system);
      this.m_EntityType = system.GetEntityTypeHandle();
      this.m_FireEngineType = system.GetComponentTypeHandle<FireEngineData>(true);
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
      this.m_FireEngineType.Update(system);
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
      ref float2 extinguishingCapacity,
      RoadTypes roadType)
    {
      Entity randomVehicle = this.GetRandomVehicle(ref random, ref extinguishingCapacity, roadType);
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
      ref float2 extinguishingCapacity,
      RoadTypes roadType)
    {
      Entity randomVehicle = Entity.Null;
      float num1 = 0.0f;
      float num2 = -extinguishingCapacity.x;
      int totalProbability = 0;
      for (int index1 = 0; index1 < this.m_PrefabChunks.Length; ++index1)
      {
        ArchetypeChunk prefabChunk = this.m_PrefabChunks[index1];
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
        NativeArray<Entity> nativeArray1 = prefabChunk.GetNativeArray(this.m_EntityType);
        NativeArray<FireEngineData> nativeArray2 = prefabChunk.GetNativeArray<FireEngineData>(ref this.m_FireEngineType);
        VehicleSelectRequirementData.Chunk chunk = this.m_RequirementData.GetChunk(prefabChunk);
        for (int index2 = 0; index2 < nativeArray2.Length; ++index2)
        {
          if (this.m_RequirementData.CheckRequirements(ref chunk, index2))
          {
            FireEngineData fireEngineData = nativeArray2[index2];
            float2 float2 = fireEngineData.m_ExtinguishingCapacity - extinguishingCapacity;
            float num3 = math.max(math.min(0.0f, float2.x), float2.y);
            if ((double) num3 != (double) num2)
            {
              if (((double) num3 >= 0.0 || (double) num2 <= (double) num3) && ((double) num2 < 0.0 || (double) num2 >= (double) num3))
              {
                num2 = num3;
                totalProbability = 0;
              }
              else
                continue;
            }
            if (this.PickVehicle(ref random, 100, ref totalProbability))
            {
              randomVehicle = nativeArray1[index2];
              num1 = fireEngineData.m_ExtinguishingCapacity;
            }
          }
        }
      }
      extinguishingCapacity = (float2) num1;
      return randomVehicle;
    }

    private bool PickVehicle(ref Random random, int probability, ref int totalProbability)
    {
      totalProbability += probability;
      return random.NextInt(totalProbability) < probability;
    }
  }
}

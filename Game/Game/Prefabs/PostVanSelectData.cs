﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PostVanSelectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Game.Common;
using Game.Objects;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct PostVanSelectData
  {
    private NativeList<ArchetypeChunk> m_PrefabChunks;
    private VehicleSelectRequirementData m_RequirementData;
    private EntityTypeHandle m_EntityType;
    private ComponentTypeHandle<PostVanData> m_PostVanType;
    private ComponentLookup<ObjectData> m_ObjectData;

    public static EntityQueryDesc GetEntityQueryDesc()
    {
      return new EntityQueryDesc()
      {
        All = new ComponentType[4]
        {
          ComponentType.ReadOnly<PostVanData>(),
          ComponentType.ReadOnly<CarData>(),
          ComponentType.ReadOnly<ObjectData>(),
          ComponentType.ReadOnly<PrefabData>()
        },
        None = new ComponentType[1]
        {
          ComponentType.ReadOnly<Locked>()
        }
      };
    }

    public PostVanSelectData(SystemBase system)
    {
      this.m_PrefabChunks = new NativeList<ArchetypeChunk>();
      this.m_RequirementData = new VehicleSelectRequirementData(system);
      this.m_EntityType = system.GetEntityTypeHandle();
      this.m_PostVanType = system.GetComponentTypeHandle<PostVanData>(true);
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
      this.m_PostVanType.Update(system);
      this.m_ObjectData.Update(system);
    }

    public void PostUpdate(JobHandle jobHandle) => this.m_PrefabChunks.Dispose(jobHandle);

    public Entity CreateVehicle(
      EntityCommandBuffer.ParallelWriter commandBuffer,
      int jobIndex,
      ref Random random,
      Transform transform,
      Entity source,
      Entity vehiclePrefab)
    {
      if (vehiclePrefab == Entity.Null)
        return Entity.Null;
      ObjectData objectData = this.m_ObjectData[vehiclePrefab];
      Entity entity = commandBuffer.CreateEntity(jobIndex, objectData.m_Archetype);
      commandBuffer.SetComponent<Transform>(jobIndex, entity, transform);
      commandBuffer.SetComponent<PrefabRef>(jobIndex, entity, new PrefabRef(vehiclePrefab));
      commandBuffer.SetComponent<PseudoRandomSeed>(jobIndex, entity, new PseudoRandomSeed(ref random));
      commandBuffer.AddComponent<TripSource>(jobIndex, entity, new TripSource(source));
      commandBuffer.AddComponent<Unspawned>(jobIndex, entity, new Unspawned());
      return entity;
    }

    public Entity SelectVehicle(ref Random random, ref int2 mailCapacity)
    {
      Entity entity = Entity.Null;
      int num1 = 0;
      int num2 = -mailCapacity.x;
      int totalProbability = 0;
      for (int index1 = 0; index1 < this.m_PrefabChunks.Length; ++index1)
      {
        ArchetypeChunk prefabChunk = this.m_PrefabChunks[index1];
        NativeArray<Entity> nativeArray1 = prefabChunk.GetNativeArray(this.m_EntityType);
        NativeArray<PostVanData> nativeArray2 = prefabChunk.GetNativeArray<PostVanData>(ref this.m_PostVanType);
        VehicleSelectRequirementData.Chunk chunk = this.m_RequirementData.GetChunk(prefabChunk);
        for (int index2 = 0; index2 < nativeArray2.Length; ++index2)
        {
          if (this.m_RequirementData.CheckRequirements(ref chunk, index2))
          {
            PostVanData postVanData = nativeArray2[index2];
            int2 int2 = postVanData.m_MailCapacity - mailCapacity;
            int num3 = math.max(math.min(0, int2.x), int2.y);
            if (num3 != num2)
            {
              if ((num3 >= 0 || num2 <= num3) && (num2 < 0 || num2 >= num3))
              {
                num2 = num3;
                totalProbability = 0;
              }
              else
                continue;
            }
            if (this.PickVehicle(ref random, 100, ref totalProbability))
            {
              entity = nativeArray1[index2];
              num1 = postVanData.m_MailCapacity;
            }
          }
        }
      }
      mailCapacity = (int2) num1;
      return entity;
    }

    private bool PickVehicle(ref Random random, int probability, ref int totalProbability)
    {
      totalProbability += probability;
      return random.NextInt(totalProbability) < probability;
    }
  }
}
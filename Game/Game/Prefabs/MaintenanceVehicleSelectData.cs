﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.MaintenanceVehicleSelectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Game.Common;
using Game.Objects;
using Game.Simulation;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct MaintenanceVehicleSelectData
  {
    private NativeList<ArchetypeChunk> m_PrefabChunks;
    private VehicleSelectRequirementData m_RequirementData;
    private EntityTypeHandle m_EntityType;
    private ComponentTypeHandle<MaintenanceVehicleData> m_MaintenanceVehicleType;
    private ComponentLookup<ObjectData> m_ObjectData;

    public static EntityQueryDesc GetEntityQueryDesc()
    {
      return new EntityQueryDesc()
      {
        All = new ComponentType[4]
        {
          ComponentType.ReadOnly<MaintenanceVehicleData>(),
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

    public MaintenanceVehicleSelectData(SystemBase system)
    {
      this.m_PrefabChunks = new NativeList<ArchetypeChunk>();
      this.m_RequirementData = new VehicleSelectRequirementData(system);
      this.m_EntityType = system.GetEntityTypeHandle();
      this.m_MaintenanceVehicleType = system.GetComponentTypeHandle<MaintenanceVehicleData>(true);
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
      this.m_MaintenanceVehicleType.Update(system);
      this.m_ObjectData.Update(system);
    }

    public void PostUpdate(JobHandle jobHandle) => this.m_PrefabChunks.Dispose(jobHandle);

    public Entity CreateVehicle(
      EntityCommandBuffer.ParallelWriter commandBuffer,
      int jobIndex,
      ref Random random,
      Transform transform,
      Entity source,
      MaintenanceType maintenanceType)
    {
      Entity randomVehicle = this.GetRandomVehicle(ref random, maintenanceType);
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

    private Entity GetRandomVehicle(ref Random random, MaintenanceType maintenanceType)
    {
      Entity randomVehicle = Entity.Null;
      int totalProbability = 0;
      int num1 = 100;
      for (int index1 = 0; index1 < this.m_PrefabChunks.Length; ++index1)
      {
        ArchetypeChunk prefabChunk = this.m_PrefabChunks[index1];
        NativeArray<Entity> nativeArray1 = prefabChunk.GetNativeArray(this.m_EntityType);
        NativeArray<MaintenanceVehicleData> nativeArray2 = prefabChunk.GetNativeArray<MaintenanceVehicleData>(ref this.m_MaintenanceVehicleType);
        VehicleSelectRequirementData.Chunk chunk = this.m_RequirementData.GetChunk(prefabChunk);
        for (int index2 = 0; index2 < nativeArray2.Length; ++index2)
        {
          MaintenanceVehicleData maintenanceVehicleData = nativeArray2[index2];
          if ((maintenanceVehicleData.m_MaintenanceType & maintenanceType) == maintenanceType && this.m_RequirementData.CheckRequirements(ref chunk, index2))
          {
            int num2 = math.countbits((int) (maintenanceVehicleData.m_MaintenanceType ^ maintenanceType));
            if (num2 <= num1)
            {
              if (num2 < num1)
              {
                totalProbability = 0;
                num1 = num2;
              }
              if (this.PickVehicle(ref random, 100, ref totalProbability))
                randomVehicle = nativeArray1[index2];
            }
          }
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
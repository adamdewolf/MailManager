﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.HouseholdBehaviorSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Agents;
using Game.Buildings;
using Game.Citizens;
using Game.City;
using Game.Common;
using Game.Companies;
using Game.Economy;
using Game.Prefabs;
using Game.Tools;
using Game.Vehicles;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Burst.Intrinsics;
using Unity.Collections;
using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

#nullable disable
namespace Game.Simulation
{
  [CompilerGenerated]
  public class HouseholdBehaviorSystem : GameSystemBase
  {
    public static readonly int kCarAmount = 50;
    public static readonly int kUpdatesPerDay = 256;
    public static readonly int kMaxShoppingPossibility = 80;
    public static readonly int kMaxHouseholdNeedAmount = 2000;
    public static readonly int kCarBuyingMinimumMoney = 10000;
    public static readonly int KMinimumShoppingAmount = 50;
    private EntityQuery m_HouseholdGroup;
    private EntityQuery m_EconomyParameterGroup;
    private SimulationSystem m_SimulationSystem;
    private EndFrameBarrier m_EndFrameBarrier;
    private ResourceSystem m_ResourceSystem;
    private TaxSystem m_TaxSystem;
    private CitySystem m_CitySystem;
    private HouseholdBehaviorSystem.TypeHandle __TypeHandle;

    public override int GetUpdateInterval(SystemUpdatePhase phase)
    {
      // ISSUE: reference to a compiler-generated field
      return 262144 / (HouseholdBehaviorSystem.kUpdatesPerDay * 16);
    }

    public static float GetLastCommutePerCitizen(
      DynamicBuffer<HouseholdCitizen> householdCitizens,
      ComponentLookup<Worker> workers)
    {
      float num1 = 0.0f;
      float num2 = 0.0f;
      for (int index = 0; index < householdCitizens.Length; ++index)
      {
        Entity citizen = householdCitizens[index].m_Citizen;
        if (workers.HasComponent(citizen))
          num2 += workers[citizen].m_LastCommuteTime;
        ++num1;
      }
      return num2 / num1;
    }

    public static float GetConsumptionMultiplier(float2 parameter, int householdWealth)
    {
      return parameter.x + parameter.y * math.smoothstep(0.0f, 1f, (float) (math.max(0, householdWealth) + 1000) / 6000f);
    }

    public static bool GetFreeCar(
      Entity household,
      BufferLookup<OwnedVehicle> ownedVehicles,
      ComponentLookup<Game.Vehicles.PersonalCar> personalCars,
      ref Entity car)
    {
      if (ownedVehicles.HasBuffer(household))
      {
        DynamicBuffer<OwnedVehicle> ownedVehicle = ownedVehicles[household];
        for (int index = 0; index < ownedVehicle.Length; ++index)
        {
          car = ownedVehicle[index].m_Vehicle;
          if (personalCars.HasComponent(car) && personalCars[car].m_Keeper.Equals(Entity.Null))
            return true;
        }
      }
      car = Entity.Null;
      return false;
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_SimulationSystem = this.World.GetOrCreateSystemManaged<SimulationSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier = this.World.GetOrCreateSystemManaged<EndFrameBarrier>();
      // ISSUE: reference to a compiler-generated field
      this.m_ResourceSystem = this.World.GetOrCreateSystemManaged<ResourceSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_TaxSystem = this.World.GetOrCreateSystemManaged<TaxSystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_CitySystem = this.World.GetOrCreateSystemManaged<CitySystem>();
      // ISSUE: reference to a compiler-generated field
      this.m_EconomyParameterGroup = this.GetEntityQuery(ComponentType.ReadOnly<EconomyParameterData>());
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdGroup = this.GetEntityQuery(ComponentType.ReadWrite<Household>(), ComponentType.ReadWrite<HouseholdNeed>(), ComponentType.ReadOnly<HouseholdCitizen>(), ComponentType.ReadOnly<Game.Economy.Resources>(), ComponentType.ReadOnly<UpdateFrame>(), ComponentType.Exclude<TouristHousehold>(), ComponentType.Exclude<MovingAway>(), ComponentType.Exclude<Deleted>(), ComponentType.Exclude<Temp>());
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_HouseholdGroup);
      // ISSUE: reference to a compiler-generated field
      this.RequireForUpdate(this.m_EconomyParameterGroup);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnDestroy() => base.OnDestroy();

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated field
      uint frameWithInterval = SimulationUtils.GetUpdateFrameWithInterval(this.m_SimulationSystem.frameIndex, (uint) this.GetUpdateInterval(SystemUpdatePhase.GameSimulation), 16);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ConsumptionData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_City_Population_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Citizen_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Companies_LodgingProvider_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_ResourceData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Agents_PropertySeeker_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Renter_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Worker_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HomelessHousehold_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_LodgingSeeker_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Simulation_UpdateFrame_SharedComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_CommuterHousehold_RO_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_TouristHousehold_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdCitizen_RO_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Economy_Resources_RW_BufferTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdNeed_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Household_RW_ComponentTypeHandle.Update(ref this.CheckedStateRef);
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
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      // ISSUE: variable of a compiler-generated type
      HouseholdBehaviorSystem.HouseholdTickJob jobData = new HouseholdBehaviorSystem.HouseholdTickJob()
      {
        m_EntityType = this.__TypeHandle.__Unity_Entities_Entity_TypeHandle,
        m_HouseholdType = this.__TypeHandle.__Game_Citizens_Household_RW_ComponentTypeHandle,
        m_HouseholdNeedType = this.__TypeHandle.__Game_Citizens_HouseholdNeed_RW_ComponentTypeHandle,
        m_ResourceType = this.__TypeHandle.__Game_Economy_Resources_RW_BufferTypeHandle,
        m_HouseholdCitizenType = this.__TypeHandle.__Game_Citizens_HouseholdCitizen_RO_BufferTypeHandle,
        m_TouristHouseholdType = this.__TypeHandle.__Game_Citizens_TouristHousehold_RW_ComponentTypeHandle,
        m_CommuterHouseholdType = this.__TypeHandle.__Game_Citizens_CommuterHousehold_RO_ComponentTypeHandle,
        m_UpdateFrameType = this.__TypeHandle.__Game_Simulation_UpdateFrame_SharedComponentTypeHandle,
        m_LodgingSeekerType = this.__TypeHandle.__Game_Citizens_LodgingSeeker_RO_ComponentTypeHandle,
        m_PropertyRenterType = this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentTypeHandle,
        m_HomelessHouseholdType = this.__TypeHandle.__Game_Citizens_HomelessHousehold_RO_ComponentTypeHandle,
        m_Workers = this.__TypeHandle.__Game_Citizens_Worker_RO_ComponentLookup,
        m_OwnedVehicles = this.__TypeHandle.__Game_Vehicles_OwnedVehicle_RO_BufferLookup,
        m_RenterBufs = this.__TypeHandle.__Game_Buildings_Renter_RO_BufferLookup,
        m_EconomyParameters = this.m_EconomyParameterGroup.GetSingleton<EconomyParameterData>(),
        m_PropertySeekers = this.__TypeHandle.__Game_Agents_PropertySeeker_RO_ComponentLookup,
        m_ResourceDatas = this.__TypeHandle.__Game_Prefabs_ResourceData_RO_ComponentLookup,
        m_LodgingProviders = this.__TypeHandle.__Game_Companies_LodgingProvider_RO_ComponentLookup,
        m_CitizenDatas = this.__TypeHandle.__Game_Citizens_Citizen_RO_ComponentLookup,
        m_Populations = this.__TypeHandle.__Game_City_Population_RO_ComponentLookup,
        m_PrefabRefs = this.__TypeHandle.__Game_Prefabs_PrefabRef_RO_ComponentLookup,
        m_ConsumptionDatas = this.__TypeHandle.__Game_Prefabs_ConsumptionData_RO_ComponentLookup,
        m_ResourcePrefabs = this.m_ResourceSystem.GetPrefabs(),
        m_RandomSeed = RandomSeed.Next(),
        m_CommandBuffer = this.m_EndFrameBarrier.CreateCommandBuffer().AsParallelWriter(),
        m_UpdateFrameIndex = frameWithInterval,
        m_City = this.m_CitySystem.City
      };
      // ISSUE: reference to a compiler-generated field
      this.Dependency = jobData.ScheduleParallel<HouseholdBehaviorSystem.HouseholdTickJob>(this.m_HouseholdGroup, this.Dependency);
      // ISSUE: reference to a compiler-generated field
      this.m_EndFrameBarrier.AddJobHandleForProducer(this.Dependency);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_ResourceSystem.AddPrefabsReader(this.Dependency);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated method
      this.m_TaxSystem.AddReader(this.Dependency);
    }

    public static int GetAgeWeight(
      ResourceData resourceData,
      DynamicBuffer<HouseholdCitizen> citizens,
      ref ComponentLookup<Citizen> citizenDatas)
    {
      int ageWeight = 0;
      for (int index = 0; index < citizens.Length; ++index)
      {
        Entity citizen = citizens[index].m_Citizen;
        switch (citizenDatas[citizen].GetAge())
        {
          case CitizenAge.Child:
            ageWeight += resourceData.m_ChildWeight;
            break;
          case CitizenAge.Teen:
            ageWeight += resourceData.m_TeenWeight;
            break;
          case CitizenAge.Elderly:
            ageWeight += resourceData.m_ElderlyWeight;
            break;
          default:
            ageWeight += resourceData.m_AdultWeight;
            break;
        }
      }
      return ageWeight;
    }

    public static int GetResourceShopWeightWithAge(
      int wealth,
      Resource resource,
      ResourcePrefabs resourcePrefabs,
      ref ComponentLookup<ResourceData> resourceDatas,
      int carCount,
      bool leisureIncluded,
      DynamicBuffer<HouseholdCitizen> citizens,
      ref ComponentLookup<Citizen> citizenDatas)
    {
      ResourceData resourceData = resourceDatas[resourcePrefabs[resource]];
      // ISSUE: reference to a compiler-generated method
      return HouseholdBehaviorSystem.GetResourceShopWeightWithAge(wealth, resourceData, carCount, leisureIncluded, citizens, ref citizenDatas);
    }

    public static int GetResourceShopWeightWithAge(
      int wealth,
      ResourceData resourceData,
      int carCount,
      bool leisureIncluded,
      DynamicBuffer<HouseholdCitizen> citizens,
      ref ComponentLookup<Citizen> citizenDatas)
    {
      float num = (leisureIncluded || !resourceData.m_IsLeisure ? resourceData.m_BaseConsumption : 0.0f) + (float) (carCount * resourceData.m_CarConsumption);
      float a = leisureIncluded || !resourceData.m_IsLeisure ? resourceData.m_WealthModifier : 0.0f;
      // ISSUE: reference to a compiler-generated method
      return Mathf.RoundToInt(100f * (float) HouseholdBehaviorSystem.GetAgeWeight(resourceData, citizens, ref citizenDatas) * num * math.smoothstep(a, 1f, math.max(0.01f, (float) (((double) wealth + 5000.0) / 10000.0))));
    }

    public static int GetWeight(
      int wealth,
      Resource resource,
      ResourcePrefabs resourcePrefabs,
      ref ComponentLookup<ResourceData> resourceDatas,
      int carCount,
      bool leisureIncluded)
    {
      ResourceData resourceData = resourceDatas[resourcePrefabs[resource]];
      // ISSUE: reference to a compiler-generated method
      return HouseholdBehaviorSystem.GetWeight(wealth, resourceData, carCount, leisureIncluded);
    }

    public static int GetWeight(
      int wealth,
      ResourceData resourceData,
      int carCount,
      bool leisureIncluded)
    {
      return Mathf.RoundToInt(((leisureIncluded || !resourceData.m_IsLeisure ? resourceData.m_BaseConsumption : 0.0f) + (float) (carCount * resourceData.m_CarConsumption)) * math.smoothstep(leisureIncluded || !resourceData.m_IsLeisure ? resourceData.m_WealthModifier : 0.0f, 1f, math.clamp((float) (((double) wealth + 5000.0) / 10000.0), 0.1f, 0.9f)));
    }

    public static int GetHighestEducation(
      DynamicBuffer<HouseholdCitizen> citizenBuffer,
      ref ComponentLookup<Citizen> citizens)
    {
      int x = 0;
      for (int index = 0; index < citizenBuffer.Length; ++index)
      {
        Entity citizen1 = citizenBuffer[index].m_Citizen;
        if (citizens.HasComponent(citizen1))
        {
          Citizen citizen2 = citizens[citizen1];
          switch (citizen2.GetAge())
          {
            case CitizenAge.Teen:
            case CitizenAge.Adult:
              x = math.max(x, citizen2.GetEducationLevel());
              continue;
            default:
              continue;
          }
        }
      }
      return x;
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
    public HouseholdBehaviorSystem()
    {
    }

    [BurstCompile]
    private struct HouseholdTickJob : IJobChunk
    {
      [ReadOnly]
      public EntityTypeHandle m_EntityType;
      public ComponentTypeHandle<Household> m_HouseholdType;
      public ComponentTypeHandle<HouseholdNeed> m_HouseholdNeedType;
      [ReadOnly]
      public BufferTypeHandle<HouseholdCitizen> m_HouseholdCitizenType;
      public BufferTypeHandle<Game.Economy.Resources> m_ResourceType;
      [ReadOnly]
      public SharedComponentTypeHandle<UpdateFrame> m_UpdateFrameType;
      public ComponentTypeHandle<TouristHousehold> m_TouristHouseholdType;
      [ReadOnly]
      public ComponentTypeHandle<CommuterHousehold> m_CommuterHouseholdType;
      [ReadOnly]
      public ComponentTypeHandle<PropertyRenter> m_PropertyRenterType;
      [ReadOnly]
      public ComponentTypeHandle<LodgingSeeker> m_LodgingSeekerType;
      [ReadOnly]
      public ComponentTypeHandle<HomelessHousehold> m_HomelessHouseholdType;
      [ReadOnly]
      public BufferLookup<OwnedVehicle> m_OwnedVehicles;
      [ReadOnly]
      public BufferLookup<Renter> m_RenterBufs;
      [ReadOnly]
      public ComponentLookup<PropertySeeker> m_PropertySeekers;
      [ReadOnly]
      public ComponentLookup<Worker> m_Workers;
      [ReadOnly]
      public ComponentLookup<ResourceData> m_ResourceDatas;
      [ReadOnly]
      public ComponentLookup<LodgingProvider> m_LodgingProviders;
      [ReadOnly]
      public ComponentLookup<Population> m_Populations;
      [ReadOnly]
      public ComponentLookup<Citizen> m_CitizenDatas;
      [ReadOnly]
      public ComponentLookup<ConsumptionData> m_ConsumptionDatas;
      [ReadOnly]
      public ComponentLookup<PrefabRef> m_PrefabRefs;
      [ReadOnly]
      public ResourcePrefabs m_ResourcePrefabs;
      public RandomSeed m_RandomSeed;
      public EconomyParameterData m_EconomyParameters;
      public EntityCommandBuffer.ParallelWriter m_CommandBuffer;
      public uint m_UpdateFrameIndex;
      public Entity m_City;

      private bool NeedsCar(int spendableMoney, int familySize, int cars, ref Unity.Mathematics.Random random)
      {
        // ISSUE: reference to a compiler-generated field
        return spendableMoney > HouseholdBehaviorSystem.kCarBuyingMinimumMoney && (double) random.NextFloat() < -(double) math.log((float) cars + 0.1f) / 10.0 + 0.1;
      }

      public void Execute(
        in ArchetypeChunk chunk,
        int unfilteredChunkIndex,
        bool useEnabledMask,
        in v128 chunkEnabledMask)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if ((int) chunk.GetSharedComponent<UpdateFrame>(this.m_UpdateFrameType).m_Index != (int) this.m_UpdateFrameIndex)
          return;
        // ISSUE: reference to a compiler-generated field
        NativeArray<Entity> nativeArray1 = chunk.GetNativeArray(this.m_EntityType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<Household> nativeArray2 = chunk.GetNativeArray<Household>(ref this.m_HouseholdType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<HouseholdNeed> nativeArray3 = chunk.GetNativeArray<HouseholdNeed>(ref this.m_HouseholdNeedType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<HouseholdCitizen> bufferAccessor1 = chunk.GetBufferAccessor<HouseholdCitizen>(ref this.m_HouseholdCitizenType);
        // ISSUE: reference to a compiler-generated field
        BufferAccessor<Game.Economy.Resources> bufferAccessor2 = chunk.GetBufferAccessor<Game.Economy.Resources>(ref this.m_ResourceType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<TouristHousehold> nativeArray4 = chunk.GetNativeArray<TouristHousehold>(ref this.m_TouristHouseholdType);
        // ISSUE: reference to a compiler-generated field
        NativeArray<PropertyRenter> nativeArray5 = chunk.GetNativeArray<PropertyRenter>(ref this.m_PropertyRenterType);
        // ISSUE: reference to a compiler-generated field
        Unity.Mathematics.Random random = this.m_RandomSeed.GetRandom(unfilteredChunkIndex);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        int population = this.m_Populations[this.m_City].m_Population;
        for (int index1 = 0; index1 < chunk.Count; ++index1)
        {
          Entity entity = nativeArray1[index1];
          Household householdData = nativeArray2[index1];
          DynamicBuffer<HouseholdCitizen> citizens = bufferAccessor1[index1];
          if (citizens.Length == 0)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_CommandBuffer.AddComponent<Deleted>(unfilteredChunkIndex, entity, new Deleted());
          }
          else
          {
            bool flag1 = true;
            int num1 = 0;
            for (int index2 = 0; index2 < citizens.Length; ++index2)
            {
              // ISSUE: reference to a compiler-generated field
              num1 += this.m_CitizenDatas[citizens[index2].m_Citizen].Happiness;
              // ISSUE: reference to a compiler-generated field
              if (this.m_CitizenDatas[citizens[index2].m_Citizen].GetAge() >= CitizenAge.Adult)
                flag1 = false;
            }
            int num2 = num1 / citizens.Length;
            bool flag2 = (double) random.NextInt(10000) < -3.0 * (double) math.log((float) (-(100 - num2) + 70)) + 9.0;
            if (flag1 | flag2)
            {
              // ISSUE: reference to a compiler-generated field
              this.m_CommandBuffer.AddComponent<MovingAway>(unfilteredChunkIndex, entity, new MovingAway());
            }
            else
            {
              DynamicBuffer<Game.Economy.Resources> resources = bufferAccessor2[index1];
              HouseholdNeed householdNeed = nativeArray3[index1];
              if (householdData.m_Resources > 0)
              {
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated method
                // ISSUE: reference to a compiler-generated field
                float num3 = HouseholdBehaviorSystem.GetConsumptionMultiplier(this.m_EconomyParameters.m_ResourceConsumptionMultiplier, EconomyUtils.GetHouseholdTotalWealth(householdData, resources)) * this.m_EconomyParameters.m_ResourceConsumptionPerCitizen * (float) citizens.Length;
                // ISSUE: reference to a compiler-generated field
                if (chunk.Has<TouristHousehold>(ref this.m_TouristHouseholdType))
                {
                  // ISSUE: reference to a compiler-generated field
                  num3 *= this.m_EconomyParameters.m_TouristConsumptionMultiplier;
                  // ISSUE: reference to a compiler-generated field
                  if (!chunk.Has<LodgingSeeker>(ref this.m_LodgingSeekerType))
                  {
                    TouristHousehold touristHousehold = nativeArray4[index1];
                    if (touristHousehold.m_Hotel.Equals(Entity.Null))
                    {
                      // ISSUE: reference to a compiler-generated field
                      this.m_CommandBuffer.AddComponent<LodgingSeeker>(unfilteredChunkIndex, entity, new LodgingSeeker());
                    }
                    else
                    {
                      // ISSUE: reference to a compiler-generated field
                      if (!this.m_LodgingProviders.HasComponent(touristHousehold.m_Hotel))
                      {
                        touristHousehold.m_Hotel = Entity.Null;
                        nativeArray4[index1] = touristHousehold;
                        // ISSUE: reference to a compiler-generated field
                        this.m_CommandBuffer.AddComponent<LodgingSeeker>(unfilteredChunkIndex, entity, new LodgingSeeker());
                      }
                    }
                  }
                }
                int intRandom = MathUtils.RoundToIntRandom(ref random, num3);
                // ISSUE: reference to a compiler-generated field
                householdData.m_ConsumptionPerDay = (short) math.min((int) short.MaxValue, HouseholdBehaviorSystem.kUpdatesPerDay * intRandom);
                householdData.m_Resources = math.max(householdData.m_Resources - intRandom, 0);
              }
              else
              {
                householdData.m_Resources = 0;
                householdData.m_ConsumptionPerDay = (short) 0;
              }
              // ISSUE: reference to a compiler-generated field
              if (householdNeed.m_Resource == Resource.NoResource || householdNeed.m_Amount < HouseholdBehaviorSystem.KMinimumShoppingAmount)
              {
                PropertyRenter propertyRenter = nativeArray5.Length > 0 ? nativeArray5[index1] : new PropertyRenter();
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                int householdSpendableMoney = EconomyUtils.GetHouseholdSpendableMoney(householdData, resources, ref this.m_RenterBufs, ref this.m_ConsumptionDatas, ref this.m_PrefabRefs, propertyRenter);
                int num4 = 0;
                // ISSUE: reference to a compiler-generated field
                if (this.m_OwnedVehicles.HasBuffer(entity))
                {
                  // ISSUE: reference to a compiler-generated field
                  num4 = this.m_OwnedVehicles[entity].Length;
                }
                // ISSUE: reference to a compiler-generated field
                // ISSUE: reference to a compiler-generated field
                int num5 = math.min(HouseholdBehaviorSystem.kMaxShoppingPossibility, Mathf.RoundToInt(200f / math.max(1f, math.sqrt(this.m_EconomyParameters.m_TrafficReduction * (float) population))));
                if (random.NextInt(100) < num5)
                {
                  ResourceIterator iterator = ResourceIterator.GetIterator();
                  int max = 0;
                  while (iterator.Next())
                  {
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated method
                    max += HouseholdBehaviorSystem.GetResourceShopWeightWithAge(householdSpendableMoney, iterator.resource, this.m_ResourcePrefabs, ref this.m_ResourceDatas, num4, false, citizens, ref this.m_CitizenDatas);
                  }
                  int num6 = random.NextInt(max);
                  iterator = ResourceIterator.GetIterator();
                  while (iterator.Next())
                  {
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated field
                    // ISSUE: reference to a compiler-generated method
                    int shopWeightWithAge = HouseholdBehaviorSystem.GetResourceShopWeightWithAge(householdSpendableMoney, iterator.resource, this.m_ResourcePrefabs, ref this.m_ResourceDatas, num4, false, citizens, ref this.m_CitizenDatas);
                    max -= shopWeightWithAge;
                    if (shopWeightWithAge > 0 && max <= num6)
                    {
                      // ISSUE: reference to a compiler-generated method
                      if (iterator.resource == Resource.Vehicles && this.NeedsCar(householdSpendableMoney, citizens.Length, num4, ref random))
                      {
                        householdNeed.m_Resource = Resource.Vehicles;
                        // ISSUE: reference to a compiler-generated field
                        householdNeed.m_Amount = HouseholdBehaviorSystem.kCarAmount;
                        nativeArray3[index1] = householdNeed;
                        break;
                      }
                      householdNeed.m_Resource = iterator.resource;
                      // ISSUE: reference to a compiler-generated field
                      // ISSUE: reference to a compiler-generated field
                      float marketPrice = EconomyUtils.GetMarketPrice(this.m_ResourceDatas[this.m_ResourcePrefabs[iterator.resource]]);
                      // ISSUE: reference to a compiler-generated field
                      householdNeed.m_Amount = math.clamp((int) ((double) householdSpendableMoney / (double) marketPrice), 0, HouseholdBehaviorSystem.kMaxHouseholdNeedAmount);
                      // ISSUE: reference to a compiler-generated field
                      if (householdNeed.m_Amount > HouseholdBehaviorSystem.KMinimumShoppingAmount)
                      {
                        nativeArray3[index1] = householdNeed;
                        break;
                      }
                      break;
                    }
                  }
                }
              }
              int max1 = math.clamp(Mathf.RoundToInt(0.06f * (float) population), 64, 1024);
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!chunk.Has<TouristHousehold>(ref this.m_TouristHouseholdType) && !chunk.Has<CommuterHousehold>(ref this.m_CommuterHouseholdType) && !this.m_PropertySeekers.HasComponent(nativeArray1[index1]) && (!chunk.Has<PropertyRenter>(ref this.m_PropertyRenterType) || chunk.Has<HomelessHousehold>(ref this.m_HomelessHouseholdType) || random.NextInt(max1) == 0))
              {
                // ISSUE: reference to a compiler-generated field
                this.m_CommandBuffer.AddComponent<PropertySeeker>(unfilteredChunkIndex, nativeArray1[index1], new PropertySeeker());
              }
              nativeArray2[index1] = householdData;
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

    private struct TypeHandle
    {
      [ReadOnly]
      public EntityTypeHandle __Unity_Entities_Entity_TypeHandle;
      public ComponentTypeHandle<Household> __Game_Citizens_Household_RW_ComponentTypeHandle;
      public ComponentTypeHandle<HouseholdNeed> __Game_Citizens_HouseholdNeed_RW_ComponentTypeHandle;
      public BufferTypeHandle<Game.Economy.Resources> __Game_Economy_Resources_RW_BufferTypeHandle;
      [ReadOnly]
      public BufferTypeHandle<HouseholdCitizen> __Game_Citizens_HouseholdCitizen_RO_BufferTypeHandle;
      public ComponentTypeHandle<TouristHousehold> __Game_Citizens_TouristHousehold_RW_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<CommuterHousehold> __Game_Citizens_CommuterHousehold_RO_ComponentTypeHandle;
      public SharedComponentTypeHandle<UpdateFrame> __Game_Simulation_UpdateFrame_SharedComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<LodgingSeeker> __Game_Citizens_LodgingSeeker_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<PropertyRenter> __Game_Buildings_PropertyRenter_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentTypeHandle<HomelessHousehold> __Game_Citizens_HomelessHousehold_RO_ComponentTypeHandle;
      [ReadOnly]
      public ComponentLookup<Worker> __Game_Citizens_Worker_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<OwnedVehicle> __Game_Vehicles_OwnedVehicle_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<Renter> __Game_Buildings_Renter_RO_BufferLookup;
      [ReadOnly]
      public ComponentLookup<PropertySeeker> __Game_Agents_PropertySeeker_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ResourceData> __Game_Prefabs_ResourceData_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<LodgingProvider> __Game_Companies_LodgingProvider_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Citizen> __Game_Citizens_Citizen_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Population> __Game_City_Population_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PrefabRef> __Game_Prefabs_PrefabRef_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<ConsumptionData> __Game_Prefabs_ConsumptionData_RO_ComponentLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Unity_Entities_Entity_TypeHandle = state.GetEntityTypeHandle();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Household_RW_ComponentTypeHandle = state.GetComponentTypeHandle<Household>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HouseholdNeed_RW_ComponentTypeHandle = state.GetComponentTypeHandle<HouseholdNeed>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Economy_Resources_RW_BufferTypeHandle = state.GetBufferTypeHandle<Game.Economy.Resources>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HouseholdCitizen_RO_BufferTypeHandle = state.GetBufferTypeHandle<HouseholdCitizen>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_TouristHousehold_RW_ComponentTypeHandle = state.GetComponentTypeHandle<TouristHousehold>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_CommuterHousehold_RO_ComponentTypeHandle = state.GetComponentTypeHandle<CommuterHousehold>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Simulation_UpdateFrame_SharedComponentTypeHandle = state.GetSharedComponentTypeHandle<UpdateFrame>();
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_LodgingSeeker_RO_ComponentTypeHandle = state.GetComponentTypeHandle<LodgingSeeker>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_PropertyRenter_RO_ComponentTypeHandle = state.GetComponentTypeHandle<PropertyRenter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HomelessHousehold_RO_ComponentTypeHandle = state.GetComponentTypeHandle<HomelessHousehold>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Worker_RO_ComponentLookup = state.GetComponentLookup<Worker>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Vehicles_OwnedVehicle_RO_BufferLookup = state.GetBufferLookup<OwnedVehicle>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Renter_RO_BufferLookup = state.GetBufferLookup<Renter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Agents_PropertySeeker_RO_ComponentLookup = state.GetComponentLookup<PropertySeeker>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ResourceData_RO_ComponentLookup = state.GetComponentLookup<ResourceData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Companies_LodgingProvider_RO_ComponentLookup = state.GetComponentLookup<LodgingProvider>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Citizen_RO_ComponentLookup = state.GetComponentLookup<Citizen>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_City_Population_RO_ComponentLookup = state.GetComponentLookup<Population>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_PrefabRef_RO_ComponentLookup = state.GetComponentLookup<PrefabRef>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_ConsumptionData_RO_ComponentLookup = state.GetComponentLookup<ConsumptionData>(true);
      }
    }
  }
}
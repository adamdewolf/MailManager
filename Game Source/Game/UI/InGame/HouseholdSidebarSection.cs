// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.HouseholdSidebarSection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Buildings;
using Game.Citizens;
using Game.Prefabs;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;

#nullable disable
namespace Game.UI.InGame
{
  [CompilerGenerated]
  public class HouseholdSidebarSection : InfoSectionBase
  {
    private NativeArray<int> m_Results;
    private NativeArray<Entity> m_ResidenceResult;
    private NativeList<Entity> m_HouseholdMembersResult;
    private NativeList<Entity> m_HouseholdPetsResult;
    private NativeList<HouseholdSidebarSection.HouseholdResult> m_HouseholdsResult;
    private HouseholdSidebarSection.TypeHandle __TypeHandle;

    protected override string group => nameof (HouseholdSidebarSection);

    protected override bool displayForDestroyedObjects => true;

    protected override bool displayForUnderConstruction => true;

    private Entity residenceEntity { get; set; }

    private HouseholdSidebarSection.HouseholdSidebarVariant householdSidebarVariant { get; set; }

    [UnityEngine.Scripting.Preserve]
    protected override void OnCreate()
    {
      // ISSUE: reference to a compiler-generated method
      base.OnCreate();
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdMembersResult = new NativeList<Entity>((AllocatorManager.AllocatorHandle) Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdPetsResult = new NativeList<Entity>((AllocatorManager.AllocatorHandle) Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdsResult = new NativeList<HouseholdSidebarSection.HouseholdResult>((AllocatorManager.AllocatorHandle) Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      this.m_Results = new NativeArray<int>(3, Allocator.Persistent);
      // ISSUE: reference to a compiler-generated field
      this.m_ResidenceResult = new NativeArray<Entity>(1, Allocator.Persistent);
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnDestroy()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdMembersResult.Dispose();
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdPetsResult.Dispose();
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdsResult.Dispose();
      // ISSUE: reference to a compiler-generated field
      this.m_Results.Dispose();
      // ISSUE: reference to a compiler-generated field
      this.m_ResidenceResult.Dispose();
      base.OnDestroy();
    }

    protected override void Reset()
    {
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdMembersResult.Clear();
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdPetsResult.Clear();
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdsResult.Clear();
      // ISSUE: reference to a compiler-generated field
      this.m_ResidenceResult[0] = Entity.Null;
      // ISSUE: reference to a compiler-generated field
      this.m_Results[0] = 0;
      // ISSUE: reference to a compiler-generated field
      this.m_Results[1] = 0;
      // ISSUE: reference to a compiler-generated field
      this.m_Results[2] = 0;
    }

    [UnityEngine.Scripting.Preserve]
    protected override void OnUpdate()
    {
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Renter_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdCitizen_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Prefabs_BuildingPropertyData_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_TravelPurpose_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HealthProblem_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdPet_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Citizen_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Household_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Abandoned_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup.Update(ref this.CheckedStateRef);
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
      new HouseholdSidebarSection.CheckVisibilityJob()
      {
        m_SelectedEntity = this.selectedEntity,
        m_SelectedPrefab = this.selectedPrefab,
        m_BuildingFromEntity = this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup,
        m_AbandonedFromEntity = this.__TypeHandle.__Game_Buildings_Abandoned_RO_ComponentLookup,
        m_HouseholdFromEntity = this.__TypeHandle.__Game_Citizens_Household_RO_ComponentLookup,
        m_CitizenFromEntity = this.__TypeHandle.__Game_Citizens_Citizen_RO_ComponentLookup,
        m_HouseholdPetFromEntity = this.__TypeHandle.__Game_Citizens_HouseholdPet_RO_ComponentLookup,
        m_HealthProblemFromEntity = this.__TypeHandle.__Game_Citizens_HealthProblem_RO_ComponentLookup,
        m_TravelPurposeFromEntity = this.__TypeHandle.__Game_Citizens_TravelPurpose_RO_ComponentLookup,
        m_PropertyDataFromEntity = this.__TypeHandle.__Game_Prefabs_BuildingPropertyData_RO_ComponentLookup,
        m_HouseholdCitizenFromEntity = this.__TypeHandle.__Game_Citizens_HouseholdCitizen_RO_BufferLookup,
        m_RenterFromEntity = this.__TypeHandle.__Game_Buildings_Renter_RO_BufferLookup,
        m_Results = this.m_Results
      }.Schedule<HouseholdSidebarSection.CheckVisibilityJob>(this.Dependency).Complete();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.visible = this.m_Results[0] == 1 && this.m_Results[1] > 0;
      if (!this.visible)
        return;
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Renter_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdAnimal_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdCitizen_RO_BufferLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_TravelPurpose_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HealthProblem_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdPet_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_HouseholdMember_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Citizen_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Citizens_Household_RO_ComponentLookup.Update(ref this.CheckedStateRef);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup.Update(ref this.CheckedStateRef);
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
      // ISSUE: object of a compiler-generated type is created
      new HouseholdSidebarSection.CollectDataJob()
      {
        m_SelectedEntity = this.selectedEntity,
        m_BuildingFromEntity = this.__TypeHandle.__Game_Buildings_Building_RO_ComponentLookup,
        m_HouseholdFromEntity = this.__TypeHandle.__Game_Citizens_Household_RO_ComponentLookup,
        m_CitizenFromEntity = this.__TypeHandle.__Game_Citizens_Citizen_RO_ComponentLookup,
        m_HouseholdMemberFromEntity = this.__TypeHandle.__Game_Citizens_HouseholdMember_RO_ComponentLookup,
        m_HouseholdPetFromEntity = this.__TypeHandle.__Game_Citizens_HouseholdPet_RO_ComponentLookup,
        m_HealthProblemFromEntity = this.__TypeHandle.__Game_Citizens_HealthProblem_RO_ComponentLookup,
        m_TravelPurposeFromEntity = this.__TypeHandle.__Game_Citizens_TravelPurpose_RO_ComponentLookup,
        m_PropertyRenterFromEntity = this.__TypeHandle.__Game_Buildings_PropertyRenter_RO_ComponentLookup,
        m_HouseholdCitizenFromEntity = this.__TypeHandle.__Game_Citizens_HouseholdCitizen_RO_BufferLookup,
        m_HouseholdAnimalsFromEntity = this.__TypeHandle.__Game_Citizens_HouseholdAnimal_RO_BufferLookup,
        m_RenterFromEntity = this.__TypeHandle.__Game_Buildings_Renter_RO_BufferLookup,
        m_ResidenceResult = this.m_ResidenceResult,
        m_HouseholdsResult = this.m_HouseholdsResult,
        m_HouseholdCitizensResult = this.m_HouseholdMembersResult,
        m_HouseholdAnimalsResult = this.m_HouseholdPetsResult
      }.Schedule<HouseholdSidebarSection.CollectDataJob>(this.Dependency).Complete();
    }

    protected override void OnProcess()
    {
      // ISSUE: reference to a compiler-generated field
      this.residenceEntity = this.m_ResidenceResult[0];
      // ISSUE: reference to a compiler-generated field
      this.householdSidebarVariant = (HouseholdSidebarSection.HouseholdSidebarVariant) this.m_Results[2];
    }

    public override void OnWriteProperties(IJsonWriter writer)
    {
      writer.PropertyName("householdSidebarVariant");
      IJsonWriter jsonWriter = writer;
      // ISSUE: variable of a compiler-generated type
      HouseholdSidebarSection.HouseholdSidebarVariant householdSidebarVariant = this.householdSidebarVariant;
      string str = householdSidebarVariant.ToString();
      jsonWriter.Write(str);
      writer.PropertyName("residence");
      // ISSUE: reference to a compiler-generated method
      this.WriteItem(writer, this.residenceEntity, "Media/Glyphs/Residence.svg");
      // ISSUE: reference to a compiler-generated field
      this.m_HouseholdsResult.Sort<HouseholdSidebarSection.HouseholdResult>();
      writer.PropertyName("households");
      // ISSUE: reference to a compiler-generated field
      writer.ArrayBegin(this.m_HouseholdsResult.Length);
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < this.m_HouseholdsResult.Length; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.WriteItem(writer, this.m_HouseholdsResult[index].m_Household, "Media/Game/Icons/Household.svg", this.m_HouseholdsResult[index].m_MemberCount);
      }
      writer.ArrayEnd();
      // ISSUE: reference to a compiler-generated field
      // ISSUE: object of a compiler-generated type is created
      this.m_HouseholdMembersResult.Sort<Entity, HouseholdSidebarSection.CitizenComparer>(new HouseholdSidebarSection.CitizenComparer(this.EntityManager));
      writer.PropertyName("householdMembers");
      // ISSUE: reference to a compiler-generated field
      writer.ArrayBegin(this.m_HouseholdMembersResult.Length);
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < this.m_HouseholdMembersResult.Length; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.WriteItem(writer, this.m_HouseholdMembersResult[index], (string) null);
      }
      writer.ArrayEnd();
      writer.PropertyName("householdPets");
      // ISSUE: reference to a compiler-generated field
      writer.ArrayBegin(this.m_HouseholdPetsResult.Length);
      // ISSUE: reference to a compiler-generated field
      for (int index = 0; index < this.m_HouseholdPetsResult.Length; ++index)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.WriteItem(writer, this.m_HouseholdPetsResult[index], "Media/Game/Icons/Pet.svg");
      }
      writer.ArrayEnd();
    }

    private void WriteItem(IJsonWriter writer, Entity entity, string iconPath, int memberCount = 0)
    {
      writer.TypeBegin("Game.UI.InGame.HouseholdSidebarSection+HouseholdSidebarItem");
      writer.PropertyName(nameof (entity));
      if (entity == Entity.Null)
        writer.WriteNull();
      else
        writer.Write(entity);
      writer.PropertyName("name");
      if (entity == Entity.Null)
      {
        writer.WriteNull();
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_NameSystem.BindName(writer, entity);
      }
      writer.PropertyName("familyName");
      if (entity == Entity.Null || !this.EntityManager.HasComponent<Household>(entity))
      {
        writer.WriteNull();
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_NameSystem.BindFamilyName(writer, entity);
      }
      writer.PropertyName(nameof (iconPath));
      writer.Write(iconPath);
      writer.PropertyName("selected");
      writer.Write(entity == this.selectedEntity);
      writer.PropertyName(nameof (memberCount));
      if (memberCount == 0)
        writer.WriteNull();
      else
        writer.Write(memberCount);
      writer.TypeEnd();
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
    public HouseholdSidebarSection()
    {
    }

    private struct HouseholdResult : IComparable<HouseholdSidebarSection.HouseholdResult>
    {
      public Entity m_Household;
      public int m_MemberCount;

      public int CompareTo(HouseholdSidebarSection.HouseholdResult other)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        int num = other.m_MemberCount.CompareTo(this.m_MemberCount);
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        return num == 0 ? other.m_Household.CompareTo(this.m_Household) : num;
      }
    }

    private struct CitizenComparer : IComparer<Entity>
    {
      private EntityManager m_EntityManager;

      public CitizenComparer(EntityManager entityManager) => this.m_EntityManager = entityManager;

      public int Compare(Entity x, Entity y)
      {
        // ISSUE: reference to a compiler-generated field
        CitizenAge age = this.m_EntityManager.GetComponentData<Citizen>(x).GetAge();
        // ISSUE: reference to a compiler-generated field
        int num = this.m_EntityManager.GetComponentData<Citizen>(y).GetAge().CompareTo((object) age);
        return num == 0 ? y.CompareTo(x) : num;
      }
    }

    public enum Result
    {
      Visible,
      ResidentCount,
      Type,
      ResultCount,
    }

    private enum HouseholdSidebarVariant
    {
      Citizen,
      Household,
      Building,
    }

    [BurstCompile]
    public struct CheckVisibilityJob : IJob
    {
      [ReadOnly]
      public Entity m_SelectedEntity;
      [ReadOnly]
      public Entity m_SelectedPrefab;
      [ReadOnly]
      public ComponentLookup<Building> m_BuildingFromEntity;
      [ReadOnly]
      public ComponentLookup<Abandoned> m_AbandonedFromEntity;
      [ReadOnly]
      public ComponentLookup<Household> m_HouseholdFromEntity;
      [ReadOnly]
      public ComponentLookup<Citizen> m_CitizenFromEntity;
      [ReadOnly]
      public ComponentLookup<HouseholdPet> m_HouseholdPetFromEntity;
      [ReadOnly]
      public ComponentLookup<HealthProblem> m_HealthProblemFromEntity;
      [ReadOnly]
      public ComponentLookup<TravelPurpose> m_TravelPurposeFromEntity;
      [ReadOnly]
      public ComponentLookup<BuildingPropertyData> m_PropertyDataFromEntity;
      [ReadOnly]
      public BufferLookup<HouseholdCitizen> m_HouseholdCitizenFromEntity;
      [ReadOnly]
      public BufferLookup<Renter> m_RenterFromEntity;
      public NativeArray<int> m_Results;

      public void Execute()
      {
        int residentCount = 0;
        int householdCount = 0;
        HouseholdPet componentData;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_CitizenFromEntity.HasComponent(this.m_SelectedEntity) || this.m_HouseholdPetFromEntity.TryGetComponent(this.m_SelectedEntity, out componentData) && componentData.m_Household != Entity.Null)
        {
          // ISSUE: reference to a compiler-generated field
          this.m_Results[0] = 1;
          // ISSUE: reference to a compiler-generated field
          this.m_Results[1] = 1;
          // ISSUE: reference to a compiler-generated field
          this.m_Results[2] = 0;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated method
          if (this.m_BuildingFromEntity.HasComponent(this.m_SelectedEntity) && this.HasResidentialProperties(ref residentCount, ref householdCount, this.m_SelectedEntity, this.m_SelectedPrefab))
          {
            // ISSUE: reference to a compiler-generated field
            this.m_Results[0] = 1;
            // ISSUE: reference to a compiler-generated field
            this.m_Results[1] = residentCount;
            // ISSUE: reference to a compiler-generated field
            this.m_Results[2] = 2;
          }
          else
          {
            DynamicBuffer<HouseholdCitizen> bufferData;
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (!this.m_HouseholdFromEntity.HasComponent(this.m_SelectedEntity) || !this.m_HouseholdCitizenFromEntity.TryGetBuffer(this.m_SelectedEntity, out bufferData))
              return;
            for (int index = 0; index < bufferData.Length; ++index)
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!CitizenUtils.IsCorpsePickedByHearse(bufferData[index].m_Citizen, ref this.m_HealthProblemFromEntity, ref this.m_TravelPurposeFromEntity))
                ++residentCount;
            }
            // ISSUE: reference to a compiler-generated field
            this.m_Results[0] = 1;
            // ISSUE: reference to a compiler-generated field
            this.m_Results[1] = residentCount;
            // ISSUE: reference to a compiler-generated field
            this.m_Results[2] = 1;
          }
        }
      }

      private bool HasResidentialProperties(
        ref int residentCount,
        ref int householdCount,
        Entity entity,
        Entity prefab)
      {
        bool flag = false;
        BuildingPropertyData componentData;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!this.m_AbandonedFromEntity.HasComponent(entity) && this.m_PropertyDataFromEntity.TryGetComponent(prefab, out componentData) && componentData.m_ResidentialProperties > 0)
        {
          flag = true;
          DynamicBuffer<Renter> bufferData1;
          // ISSUE: reference to a compiler-generated field
          if (this.m_RenterFromEntity.TryGetBuffer(entity, out bufferData1))
          {
            for (int index1 = 0; index1 < bufferData1.Length; ++index1)
            {
              DynamicBuffer<HouseholdCitizen> bufferData2;
              // ISSUE: reference to a compiler-generated field
              if (this.m_HouseholdCitizenFromEntity.TryGetBuffer(bufferData1[index1].m_Renter, out bufferData2))
              {
                ++householdCount;
                for (int index2 = 0; index2 < bufferData2.Length; ++index2)
                {
                  // ISSUE: reference to a compiler-generated field
                  // ISSUE: reference to a compiler-generated field
                  if (!CitizenUtils.IsCorpsePickedByHearse(bufferData2[index2].m_Citizen, ref this.m_HealthProblemFromEntity, ref this.m_TravelPurposeFromEntity))
                    ++residentCount;
                }
              }
            }
          }
        }
        return flag;
      }
    }

    [BurstCompile]
    private struct CollectDataJob : IJob
    {
      [ReadOnly]
      public Entity m_SelectedEntity;
      [ReadOnly]
      public ComponentLookup<Building> m_BuildingFromEntity;
      [ReadOnly]
      public ComponentLookup<Household> m_HouseholdFromEntity;
      [ReadOnly]
      public ComponentLookup<HouseholdMember> m_HouseholdMemberFromEntity;
      [ReadOnly]
      public ComponentLookup<Citizen> m_CitizenFromEntity;
      [ReadOnly]
      public ComponentLookup<HouseholdPet> m_HouseholdPetFromEntity;
      [ReadOnly]
      public ComponentLookup<HealthProblem> m_HealthProblemFromEntity;
      [ReadOnly]
      public ComponentLookup<TravelPurpose> m_TravelPurposeFromEntity;
      [ReadOnly]
      public ComponentLookup<PropertyRenter> m_PropertyRenterFromEntity;
      [ReadOnly]
      public BufferLookup<HouseholdCitizen> m_HouseholdCitizenFromEntity;
      [ReadOnly]
      public BufferLookup<HouseholdAnimal> m_HouseholdAnimalsFromEntity;
      [ReadOnly]
      public BufferLookup<Renter> m_RenterFromEntity;
      public NativeArray<Entity> m_ResidenceResult;
      public NativeList<HouseholdSidebarSection.HouseholdResult> m_HouseholdsResult;
      public NativeList<Entity> m_HouseholdCitizensResult;
      public NativeList<Entity> m_HouseholdAnimalsResult;

      public void Execute()
      {
        HouseholdPet componentData1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (this.m_HouseholdPetFromEntity.TryGetComponent(this.m_SelectedEntity, out componentData1))
        {
          Entity household = componentData1.m_Household;
          // ISSUE: reference to a compiler-generated method
          this.AddHousehold(household);
          PropertyRenter componentData2;
          // ISSUE: reference to a compiler-generated field
          if (!this.m_PropertyRenterFromEntity.TryGetComponent(household, out componentData2))
            return;
          // ISSUE: reference to a compiler-generated field
          this.m_ResidenceResult[0] = componentData2.m_Property;
        }
        else
        {
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_CitizenFromEntity.HasComponent(this.m_SelectedEntity))
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            Entity household = this.m_HouseholdMemberFromEntity[this.m_SelectedEntity].m_Household;
            // ISSUE: reference to a compiler-generated method
            this.AddHousehold(household);
            PropertyRenter componentData3;
            // ISSUE: reference to a compiler-generated field
            if (!this.m_PropertyRenterFromEntity.TryGetComponent(household, out componentData3))
              return;
            // ISSUE: reference to a compiler-generated field
            this.m_ResidenceResult[0] = componentData3.m_Property;
          }
          else
          {
            // ISSUE: reference to a compiler-generated field
            // ISSUE: reference to a compiler-generated field
            if (this.m_BuildingFromEntity.HasComponent(this.m_SelectedEntity))
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              DynamicBuffer<Renter> dynamicBuffer = this.m_RenterFromEntity[this.m_SelectedEntity];
              for (int index = 0; index < dynamicBuffer.Length; ++index)
              {
                // ISSUE: reference to a compiler-generated method
                this.AddHousehold(dynamicBuffer[index].m_Renter);
              }
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              this.m_ResidenceResult[0] = this.m_SelectedEntity;
            }
            else
            {
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated method
              this.AddHousehold(this.m_SelectedEntity);
              PropertyRenter componentData4;
              // ISSUE: reference to a compiler-generated field
              // ISSUE: reference to a compiler-generated field
              if (!this.m_PropertyRenterFromEntity.TryGetComponent(this.m_SelectedEntity, out componentData4))
                return;
              // ISSUE: reference to a compiler-generated field
              this.m_ResidenceResult[0] = componentData4.m_Property;
            }
          }
        }
      }

      private void AddHousehold(Entity householdEntity)
      {
        DynamicBuffer<HouseholdCitizen> bufferData1;
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated field
        if (!this.m_HouseholdFromEntity.HasComponent(householdEntity) || !this.m_HouseholdCitizenFromEntity.TryGetBuffer(householdEntity, out bufferData1))
          return;
        int num = 0;
        for (int index = 0; index < bufferData1.Length; ++index)
        {
          Entity citizen = bufferData1[index].m_Citizen;
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          // ISSUE: reference to a compiler-generated field
          if (this.m_CitizenFromEntity.HasComponent(citizen) && !CitizenUtils.IsCorpsePickedByHearse(citizen, ref this.m_HealthProblemFromEntity, ref this.m_TravelPurposeFromEntity))
          {
            // ISSUE: reference to a compiler-generated field
            this.m_HouseholdCitizensResult.Add(in citizen);
            ++num;
          }
        }
        DynamicBuffer<HouseholdAnimal> bufferData2;
        // ISSUE: reference to a compiler-generated field
        if (this.m_HouseholdAnimalsFromEntity.TryGetBuffer(householdEntity, out bufferData2))
        {
          for (int index = 0; index < bufferData2.Length; ++index)
          {
            // ISSUE: reference to a compiler-generated field
            this.m_HouseholdAnimalsResult.Add(in bufferData2[index].m_HouseholdPet);
          }
        }
        // ISSUE: reference to a compiler-generated field
        // ISSUE: object of a compiler-generated type is created
        this.m_HouseholdsResult.Add(new HouseholdSidebarSection.HouseholdResult()
        {
          m_Household = householdEntity,
          m_MemberCount = num
        });
      }
    }

    private struct TypeHandle
    {
      [ReadOnly]
      public ComponentLookup<Building> __Game_Buildings_Building_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Abandoned> __Game_Buildings_Abandoned_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Household> __Game_Citizens_Household_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<Citizen> __Game_Citizens_Citizen_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<HouseholdPet> __Game_Citizens_HouseholdPet_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<HealthProblem> __Game_Citizens_HealthProblem_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<TravelPurpose> __Game_Citizens_TravelPurpose_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<BuildingPropertyData> __Game_Prefabs_BuildingPropertyData_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<HouseholdCitizen> __Game_Citizens_HouseholdCitizen_RO_BufferLookup;
      [ReadOnly]
      public BufferLookup<Renter> __Game_Buildings_Renter_RO_BufferLookup;
      [ReadOnly]
      public ComponentLookup<HouseholdMember> __Game_Citizens_HouseholdMember_RO_ComponentLookup;
      [ReadOnly]
      public ComponentLookup<PropertyRenter> __Game_Buildings_PropertyRenter_RO_ComponentLookup;
      [ReadOnly]
      public BufferLookup<HouseholdAnimal> __Game_Citizens_HouseholdAnimal_RO_BufferLookup;

      [MethodImpl(MethodImplOptions.AggressiveInlining)]
      public void __AssignHandles(ref SystemState state)
      {
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Building_RO_ComponentLookup = state.GetComponentLookup<Building>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Abandoned_RO_ComponentLookup = state.GetComponentLookup<Abandoned>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Household_RO_ComponentLookup = state.GetComponentLookup<Household>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_Citizen_RO_ComponentLookup = state.GetComponentLookup<Citizen>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HouseholdPet_RO_ComponentLookup = state.GetComponentLookup<HouseholdPet>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HealthProblem_RO_ComponentLookup = state.GetComponentLookup<HealthProblem>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_TravelPurpose_RO_ComponentLookup = state.GetComponentLookup<TravelPurpose>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Prefabs_BuildingPropertyData_RO_ComponentLookup = state.GetComponentLookup<BuildingPropertyData>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HouseholdCitizen_RO_BufferLookup = state.GetBufferLookup<HouseholdCitizen>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_Renter_RO_BufferLookup = state.GetBufferLookup<Renter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HouseholdMember_RO_ComponentLookup = state.GetComponentLookup<HouseholdMember>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Buildings_PropertyRenter_RO_ComponentLookup = state.GetComponentLookup<PropertyRenter>(true);
        // ISSUE: reference to a compiler-generated field
        this.__Game_Citizens_HouseholdAnimal_RO_BufferLookup = state.GetBufferLookup<HouseholdAnimal>(true);
      }
    }
  }
}

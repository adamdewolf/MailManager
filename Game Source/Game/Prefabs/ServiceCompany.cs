﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ServiceCompany
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Companies;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Companies/", new System.Type[] {typeof (CompanyPrefab)})]
  public class ServiceCompany : ComponentBase
  {
    public int m_MaxService;
    public float m_MaxWorkersPerCell;
    [Tooltip("The service consumed per leisure tick")]
    public int m_ServiceConsuming = 1;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ServiceCompanyData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ServiceAvailable>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      entityManager.SetComponentData<ServiceCompanyData>(entity, new ServiceCompanyData()
      {
        m_MaxService = this.m_MaxService,
        m_WorkPerUnit = 0,
        m_MaxWorkersPerCell = this.m_MaxWorkersPerCell,
        m_ServiceConsuming = this.m_ServiceConsuming
      });
    }
  }
}
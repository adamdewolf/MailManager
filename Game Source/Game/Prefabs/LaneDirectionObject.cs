﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LaneDirectionObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Objects/", new Type[] {typeof (StaticObjectPrefab), typeof (MarkerObjectPrefab)})]
  public class LaneDirectionObject : ComponentBase
  {
    public LaneDirectionType m_Left = LaneDirectionType.None;
    public LaneDirectionType m_Forward;
    public LaneDirectionType m_Right = LaneDirectionType.None;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<LaneDirectionData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Objects.NetObject>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      LaneDirectionData componentData;
      componentData.m_Left = this.m_Left;
      componentData.m_Forward = this.m_Forward;
      componentData.m_Right = this.m_Right;
      entityManager.SetComponentData<LaneDirectionData>(entity, componentData);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TransportStopMarker
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Notifications/", new Type[] {typeof (NotificationIconPrefab)})]
  public class TransportStopMarker : ComponentBase
  {
    public TransportType m_TransportType;
    public bool m_PassengerTransport;
    public bool m_CargoTransport;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<TransportStopMarkerData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      TransportStopMarkerData componentData;
      componentData.m_TransportType = this.m_TransportType;
      componentData.m_PassengerTransport = this.m_PassengerTransport;
      componentData.m_CargoTransport = this.m_CargoTransport;
      entityManager.SetComponentData<TransportStopMarkerData>(entity, componentData);
    }
  }
}
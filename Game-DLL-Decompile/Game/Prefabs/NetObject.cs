﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Net;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Objects/", new System.Type[] {typeof (StaticObjectPrefab), typeof (MarkerObjectPrefab)})]
  public class NetObject : ComponentBase
  {
    public NetPieceRequirements[] m_SetCompositionState;
    public RoadTypes m_RequireRoad;
    public TrackTypes m_TrackPassThrough;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<NetObjectData>());
      components.Add(ComponentType.ReadWrite<PlaceableObjectData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Objects.NetObject>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      NetObjectData componentData1 = new NetObjectData();
      NetSectionFlags sectionFlags;
      NetCompositionHelpers.GetRequirementFlags(this.m_SetCompositionState, out componentData1.m_CompositionFlags, out sectionFlags);
      if (sectionFlags != (NetSectionFlags) 0)
        ComponentBase.baseLog.ErrorFormat((UnityEngine.Object) this.prefab, "NetObject ({0}) cannot set section flags: {1}", (object) this.prefab.name, (object) sectionFlags);
      componentData1.m_RequireRoad = this.m_RequireRoad;
      componentData1.m_TrackPassThrough = this.m_TrackPassThrough;
      entityManager.SetComponentData<NetObjectData>(entity, componentData1);
      PlaceableObjectData componentData2 = entityManager.GetComponentData<PlaceableObjectData>(entity);
      componentData2.m_Flags |= Game.Objects.PlacementFlags.NetObject;
      bool flag = (componentData1.m_CompositionFlags & CompositionFlags.nodeMask) != new CompositionFlags();
      int num = (componentData1.m_CompositionFlags & ~CompositionFlags.nodeMask) != new CompositionFlags() ? 1 : 0;
      if (flag)
        componentData2.m_Flags |= Game.Objects.PlacementFlags.RoadNode;
      if (num != 0 || !flag)
        componentData2.m_Flags |= Game.Objects.PlacementFlags.RoadEdge;
      if ((this.m_RequireRoad & RoadTypes.Watercraft) != RoadTypes.None)
        componentData2.m_Flags |= Game.Objects.PlacementFlags.Waterway;
      entityManager.SetComponentData<PlaceableObjectData>(entity, componentData2);
    }
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.HoveringObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Objects;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Objects/", new Type[] {typeof (StaticObjectPrefab), typeof (MarkerObjectPrefab)})]
  public class HoveringObject : ComponentBase
  {
    public float m_HoveringHeight;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<PlaceableObjectData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      PlaceableObjectData componentData = entityManager.GetComponentData<PlaceableObjectData>(entity);
      componentData.m_PlacementOffset.y = this.m_HoveringHeight;
      componentData.m_Flags &= ~PlacementFlags.OnGround;
      componentData.m_Flags |= PlacementFlags.Hovering;
      entityManager.SetComponentData<PlaceableObjectData>(entity, componentData);
    }
  }
}

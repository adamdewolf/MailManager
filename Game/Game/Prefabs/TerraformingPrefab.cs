// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TerraformingPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tools/", new System.Type[] {})]
  public class TerraformingPrefab : PrefabBase
  {
    public TerraformingType m_Type;
    public TerraformingTarget m_Target;
    public Material m_BrushMaterial;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<TerraformingData>());
      components.Add(ComponentType.ReadWrite<PlaceableInfoviewItem>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      TerraformingData componentData;
      componentData.m_Type = this.m_Type;
      componentData.m_Target = this.m_Target;
      entityManager.SetComponentData<TerraformingData>(entity, componentData);
    }
  }
}

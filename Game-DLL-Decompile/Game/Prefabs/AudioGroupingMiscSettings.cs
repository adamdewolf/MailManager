// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AudioGroupingMiscSettings
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Settings/", new Type[] {typeof (AudioGroupingSettingsPrefab)})]
  public class AudioGroupingMiscSettings : ComponentBase
  {
    public float m_ForestFireDistance = 100f;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<AudioGroupingMiscSetting>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      base.LateInitialize(entityManager, entity);
      AudioGroupingMiscSetting componentData = new AudioGroupingMiscSetting()
      {
        m_ForestFireDistance = this.m_ForestFireDistance
      };
      entityManager.SetComponentData<AudioGroupingMiscSetting>(entity, componentData);
    }
  }
}

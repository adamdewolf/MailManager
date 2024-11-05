// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.HeatmapInfomodePrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Rendering;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tools/Infomode/", new Type[] {})]
  public class HeatmapInfomodePrefab : GradientInfomodeBasePrefab
  {
    public HeatmapData m_Type;

    public override string infomodeTypeLocaleKey => "TerrainColor";

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<InfoviewHeatmapData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<InfoviewHeatmapData>(entity, new InfoviewHeatmapData()
      {
        m_Type = this.m_Type
      });
    }

    public override int GetColorGroup()
    {
      switch (this.m_Type)
      {
        case HeatmapData.WaterFlow:
          return 1;
        case HeatmapData.WaterPollution:
          return 1;
        default:
          return 0;
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TerrainPropertiesPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Simulation;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public class TerrainPropertiesPrefab : PrefabBase
  {
    public WaterSystem.WaterSource[] m_WaterSources;
    public int m_WaterSourceSteps;
    public int m_WaterVelocitySteps;
    public int m_WaterDepthSteps;
    public int m_WaterMaxSpeed;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<TerrainPropertiesData>());
    }
  }
}

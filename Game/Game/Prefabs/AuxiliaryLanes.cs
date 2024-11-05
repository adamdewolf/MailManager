// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AuxiliaryLanes
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/", new Type[] {typeof (NetLanePrefab)})]
  public class AuxiliaryLanes : ComponentBase
  {
    public AuxiliaryLaneInfo[] m_AuxiliaryLanes;

    public override bool ignoreUnlockDependencies => true;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      for (int index = 0; index < this.m_AuxiliaryLanes.Length; ++index)
        prefabs.Add((PrefabBase) this.m_AuxiliaryLanes[index].m_Lane);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<AuxiliaryNetLane>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}

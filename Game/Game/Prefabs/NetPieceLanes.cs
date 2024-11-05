// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetPieceLanes
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Net/", new Type[] {typeof (NetPiecePrefab)})]
  public class NetPieceLanes : ComponentBase
  {
    public NetLaneInfo[] m_Lanes;

    public override bool ignoreUnlockDependencies => true;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      if (this.m_Lanes == null)
        return;
      for (int index = 0; index < this.m_Lanes.Length; ++index)
        prefabs.Add((PrefabBase) this.m_Lanes[index].m_Lane);
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<NetPieceLane>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}

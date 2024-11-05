// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.InfomodeBasePrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;

#nullable disable
namespace Game.Prefabs
{
  public abstract class InfomodeBasePrefab : InfomodePrefab
  {
    public InfomodeGroupPrefab[] m_IncludeInGroups;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      if (this.m_IncludeInGroups == null)
        return;
      for (int index = 0; index < this.m_IncludeInGroups.Length; ++index)
        prefabs.Add((PrefabBase) this.m_IncludeInGroups[index]);
    }
  }
}

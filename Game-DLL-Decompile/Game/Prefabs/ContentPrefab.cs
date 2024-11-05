// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ContentPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Prefabs/Content/", new Type[] {})]
  public class ContentPrefab : PrefabBase
  {
    public bool IsAvailable()
    {
      foreach (ComponentBase component in this.components)
      {
        if (component is ContentRequirementBase contentRequirementBase && !contentRequirementBase.CheckRequirement())
          return false;
      }
      return true;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.PdxLoginRequirement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.PSI.Common;
using Colossal.PSI.PdxSdk;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Prefabs/Content/", new Type[] {typeof (ContentPrefab)})]
  public class PdxLoginRequirement : ContentRequirementBase
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override bool CheckRequirement()
    {
      PdxSdkPlatform psi = PlatformManager.instance.GetPSI<PdxSdkPlatform>("PdxSdk");
      return psi != null && psi.hasEverLoggedIn;
    }
  }
}

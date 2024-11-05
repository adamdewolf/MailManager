// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.DlcRequirement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.PSI.Common;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Prefabs/Content/", new Type[] {typeof (ContentPrefab), typeof (UIWhatsNewPanelPrefab)})]
  public class DlcRequirement : ContentRequirementBase
  {
    public DlcId m_Dlc;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override bool CheckRequirement() => PlatformManager.instance.IsDlcOwned(this.m_Dlc);
  }
}

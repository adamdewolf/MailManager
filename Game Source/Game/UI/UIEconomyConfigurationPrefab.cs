// Decompiled with JetBrains decompiler
// Type: Game.UI.UIEconomyConfigurationPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Game.Prefabs;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.UI
{
  [ComponentMenu("Settings/", new Type[] {})]
  public class UIEconomyConfigurationPrefab : PrefabBase
  {
    public BudgetItem<IncomeSource>[] m_IncomeItems;
    public BudgetItem<ExpenseSource>[] m_ExpenseItems;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<UIEconomyConfigurationData>());
    }
  }
}

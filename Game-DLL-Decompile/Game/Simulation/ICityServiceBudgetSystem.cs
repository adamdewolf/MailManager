// Decompiled with JetBrains decompiler
// Type: Game.Simulation.ICityServiceBudgetSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public interface ICityServiceBudgetSystem
  {
    int GetIncome(IncomeSource source);

    int GetExpense(ExpenseSource source);

    int GetBalance();

    int GetTotalIncome();

    int GetTotalExpenses();

    int GetTotalTaxIncome();

    int GetServiceBudget(Entity servicePrefab);

    void SetServiceBudget(Entity servicePrefab, int percentage);

    int GetServiceEfficiency(Entity servicePrefab, int budget);

    void GetEstimatedServiceBudget(Entity servicePrefab, out int upkeep);

    int GetNumberOfServiceBuildings(Entity serviceBuildingPrefab);

    int2 GetWorkersAndWorkplaces(Entity serviceBuildingPrefab);

    Entity[] GetServiceBuildings(Entity servicePrefab);
  }
}

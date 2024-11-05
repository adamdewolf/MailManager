// Decompiled with JetBrains decompiler
// Type: Game.Simulation.IBudgetSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public interface IBudgetSystem
  {
    bool HasData { get; }

    uint LastUpdate { get; }

    int GetTrade(Resource resource);

    int GetTradeWorth(Resource resource);

    int GetHouseholdWealth();

    int GetCompanyWealth(bool service, Resource resource);

    int GetTotalTradeWorth();

    int GetHouseholdCount();

    int GetCompanyCount(bool service, Resource resource);

    int2 GetHouseholdWorkers();

    int2 GetCompanyWorkers(bool service, Resource resource);

    float2 GetCitizenWellbeing();

    int GetTouristCount();

    int2 GetLodgingData();

    int GetTouristIncome();
  }
}

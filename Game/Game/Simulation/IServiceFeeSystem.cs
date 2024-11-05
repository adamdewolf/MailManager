// Decompiled with JetBrains decompiler
// Type: Game.Simulation.IServiceFeeSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Unity.Mathematics;

#nullable disable
namespace Game.Simulation
{
  public interface IServiceFeeSystem
  {
    int3 GetServiceFees(PlayerResource resource);

    int GetServiceFeeIncomeEstimate(PlayerResource resource, float fee);
  }
}

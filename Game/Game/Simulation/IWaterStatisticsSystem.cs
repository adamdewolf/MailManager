// Decompiled with JetBrains decompiler
// Type: Game.Simulation.IWaterStatisticsSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Simulation
{
  public interface IWaterStatisticsSystem
  {
    int freshCapacity { get; }

    int freshConsumption { get; }

    int fulfilledFreshConsumption { get; }

    int sewageCapacity { get; }

    int sewageConsumption { get; }

    int fulfilledSewageConsumption { get; }
  }
}

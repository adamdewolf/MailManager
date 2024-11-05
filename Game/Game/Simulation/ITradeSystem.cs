// Decompiled with JetBrains decompiler
// Type: Game.Simulation.ITradeSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.City;
using Game.Economy;
using Game.Prefabs;
using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public interface ITradeSystem
  {
    float GetTradePrice(
      Resource resource,
      OutsideConnectionTransferType type,
      bool import,
      DynamicBuffer<CityModifier> cityEffects);
  }
}

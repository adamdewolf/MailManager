﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.IAvailabilityInfoCell
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Simulation
{
  public interface IAvailabilityInfoCell
  {
    void AddAttractiveness(float amount);

    void AddConsumers(float amount);

    void AddServices(float amount);

    void AddWorkplaces(float amount);
  }
}
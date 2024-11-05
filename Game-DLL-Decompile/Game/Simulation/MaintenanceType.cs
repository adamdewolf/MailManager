// Decompiled with JetBrains decompiler
// Type: Game.Simulation.MaintenanceType
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Simulation
{
  [Flags]
  public enum MaintenanceType : byte
  {
    Park = 1,
    Road = 2,
    Snow = 4,
    Vehicle = 8,
    None = 0,
  }
}

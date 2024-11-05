// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.MaintenanceVehicleFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum MaintenanceVehicleFlags : uint
  {
    Returning = 1,
    TransformTarget = 2,
    EdgeTarget = 4,
    TryWork = 8,
    Working = 16, // 0x00000010
    ClearingDebris = 32, // 0x00000020
    Full = 64, // 0x00000040
    EstimatedFull = 128, // 0x00000080
    Disabled = 256, // 0x00000100
    ClearChecked = 512, // 0x00000200
  }
}

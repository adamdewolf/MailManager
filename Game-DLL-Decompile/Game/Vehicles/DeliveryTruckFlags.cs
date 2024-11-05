// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.DeliveryTruckFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum DeliveryTruckFlags : uint
  {
    Returning = 1,
    Loaded = 2,
    DummyTraffic = 4,
    Buying = 16, // 0x00000010
    StorageTransfer = 32, // 0x00000020
    Delivering = 64, // 0x00000040
    NoUnloading = 128, // 0x00000080
    TransactionCancelled = 256, // 0x00000100
    UpdateOwnerQuantity = 512, // 0x00000200
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Simulation.GoodsDeliveryFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Simulation
{
  [Flags]
  public enum GoodsDeliveryFlags : ushort
  {
    BuildingUpkeep = 1,
    CommercialAllowed = 2,
    IndustrialAllowed = 4,
    ImportAllowed = 8,
    ResourceExportTarget = 16, // 0x0010
  }
}

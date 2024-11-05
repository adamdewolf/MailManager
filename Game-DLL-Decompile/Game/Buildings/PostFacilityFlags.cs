// Decompiled with JetBrains decompiler
// Type: Game.Buildings.PostFacilityFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Buildings
{
  [Flags]
  public enum PostFacilityFlags : byte
  {
    CanDeliverMailWithVan = 1,
    CanCollectMailWithVan = 2,
    HasAvailableTrucks = 4,
    AcceptsUnsortedMail = 8,
    DeliversLocalMail = 16, // 0x10
    AcceptsLocalMail = 32, // 0x20
    DeliversUnsortedMail = 64, // 0x40
  }
}

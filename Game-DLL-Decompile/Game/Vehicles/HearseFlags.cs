// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.HearseFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum HearseFlags : uint
  {
    Returning = 1,
    Dispatched = 2,
    Transporting = 4,
    AtTarget = 8,
    Disembarking = 16, // 0x00000010
    Disabled = 32, // 0x00000020
  }
}

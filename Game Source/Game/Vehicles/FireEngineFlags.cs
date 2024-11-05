// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.FireEngineFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum FireEngineFlags : uint
  {
    Returning = 1,
    Extinguishing = 2,
    Empty = 4,
    DisasterResponse = 8,
    Rescueing = 16, // 0x00000010
    EstimatedEmpty = 32, // 0x00000020
    Disabled = 64, // 0x00000040
  }
}

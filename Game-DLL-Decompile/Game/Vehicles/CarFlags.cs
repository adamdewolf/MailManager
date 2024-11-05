// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.CarFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Vehicles
{
  [Flags]
  public enum CarFlags : uint
  {
    Emergency = 1,
    StayOnRoad = 2,
    AnyLaneTarget = 4,
    Warning = 8,
    Queueing = 16, // 0x00000010
    UsePublicTransportLanes = 32, // 0x00000020
    PreferPublicTransportLanes = 64, // 0x00000040
    Sign = 128, // 0x00000080
    Interior = 256, // 0x00000100
    Working = 512, // 0x00000200
    SignalAnimation1 = 1024, // 0x00000400
    SignalAnimation2 = 2048, // 0x00000800
  }
}

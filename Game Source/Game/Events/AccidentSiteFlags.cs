// Decompiled with JetBrains decompiler
// Type: Game.Events.AccidentSiteFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Events
{
  [Flags]
  public enum AccidentSiteFlags : uint
  {
    StageAccident = 1,
    Secured = 2,
    CrimeScene = 4,
    TrafficAccident = 8,
    CrimeFinished = 16, // 0x00000010
    CrimeDetected = 32, // 0x00000020
    CrimeMonitored = 64, // 0x00000040
    RequirePolice = 128, // 0x00000080
    MovingVehicles = 256, // 0x00000100
  }
}

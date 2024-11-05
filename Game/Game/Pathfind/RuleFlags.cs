// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.RuleFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  [Flags]
  public enum RuleFlags : byte
  {
    HasBlockage = 1,
    ForbidCombustionEngines = 2,
    ForbidTransitTraffic = 4,
    ForbidHeavyTraffic = 8,
    ForbidPrivateTraffic = 16, // 0x10
    ForbidSlowTraffic = 32, // 0x20
  }
}

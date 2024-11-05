// Decompiled with JetBrains decompiler
// Type: Game.Net.UtilityTypes
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Net
{
  [Flags]
  public enum UtilityTypes : byte
  {
    None = 0,
    WaterPipe = 1,
    SewagePipe = 2,
    StormwaterPipe = 4,
    LowVoltageLine = 8,
    Fence = 16, // 0x10
    Catenary = 32, // 0x20
    HighVoltageLine = 64, // 0x40
  }
}

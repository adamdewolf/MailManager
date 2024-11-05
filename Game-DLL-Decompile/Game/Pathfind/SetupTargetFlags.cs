// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.SetupTargetFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  [Flags]
  public enum SetupTargetFlags : uint
  {
    None = 0,
    Industrial = 1,
    Commercial = 2,
    Import = 4,
    Service = 8,
    Residential = 16, // 0x00000010
    Export = 32, // 0x00000020
    SecondaryPath = 64, // 0x00000040
    RequireTransport = 128, // 0x00000080
    PathEnd = 256, // 0x00000100
  }
}

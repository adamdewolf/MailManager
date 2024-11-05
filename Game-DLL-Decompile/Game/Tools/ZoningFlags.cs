// Decompiled with JetBrains decompiler
// Type: Game.Tools.ZoningFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Tools
{
  [Flags]
  public enum ZoningFlags : uint
  {
    FloodFill = 1,
    Marquee = 2,
    Zone = 4,
    Dezone = 8,
    Paint = 16, // 0x00000010
    Overwrite = 32, // 0x00000020
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  [Flags]
  public enum PathFlags : ushort
  {
    Pending = 1,
    Failed = 2,
    Obsolete = 4,
    Scheduled = 8,
    Append = 16, // 0x0010
    Updated = 32, // 0x0020
    Stuck = 64, // 0x0040
    WantsEvent = 128, // 0x0080
    AddDestination = 256, // 0x0100
    Debug = 512, // 0x0200
    Divert = 1024, // 0x0400
    DivertObsolete = 2048, // 0x0800
    CachedObsolete = 4096, // 0x1000
  }
}
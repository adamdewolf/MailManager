﻿// Decompiled with JetBrains decompiler
// Type: Game.Creatures.HumanFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Creatures
{
  [Flags]
  public enum HumanFlags : uint
  {
    Run = 1,
    Selfies = 2,
    Emergency = 4,
    Dead = 8,
    Carried = 16, // 0x00000010
    Cold = 32, // 0x00000020
    Homeless = 64, // 0x00000040
    Waiting = 128, // 0x00000080
    Sad = 256, // 0x00000100
    Happy = 512, // 0x00000200
    Angry = 1024, // 0x00000400
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Citizens.CitizenFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Citizens
{
  [Flags]
  public enum CitizenFlags : short
  {
    None = 0,
    AgeBit1 = 1,
    AgeBit2 = 2,
    MovingAwayReachOC = 4,
    Male = 8,
    EducationBit1 = 16, // 0x0010
    EducationBit2 = 32, // 0x0020
    EducationBit3 = 64, // 0x0040
    FailedEducationBit1 = 128, // 0x0080
    FailedEducationBit2 = 256, // 0x0100
    Tourist = 512, // 0x0200
    Commuter = 1024, // 0x0400
    LookingForPartner = 2048, // 0x0800
    NeedsNewJob = 4096, // 0x1000
  }
}
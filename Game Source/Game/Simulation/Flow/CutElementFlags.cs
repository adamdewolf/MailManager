﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.Flow.CutElementFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Simulation.Flow
{
  [Flags]
  public enum CutElementFlags
  {
    None = 0,
    Created = 1,
    Admissible = 2,
    Changed = 4,
    Deleted = 8,
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.Simulation.ElectricityFlowEdgeFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Simulation
{
  [Flags]
  public enum ElectricityFlowEdgeFlags : byte
  {
    None = 0,
    Forward = 1,
    Backward = 2,
    Bottleneck = 4,
    BeyondBottleneck = 8,
    Disconnected = 16, // 0x10
    ForwardBackward = Backward | Forward, // 0x03
  }
}
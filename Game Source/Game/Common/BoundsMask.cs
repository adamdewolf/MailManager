﻿// Decompiled with JetBrains decompiler
// Type: Game.Common.BoundsMask
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Common
{
  [Flags]
  public enum BoundsMask : ushort
  {
    Debug = 1,
    NormalLayers = 2,
    PipelineLayer = 4,
    SubPipelineLayer = 8,
    WaterwayLayer = 16, // 0x0010
    IsTree = 32, // 0x0020
    OccupyZone = 64, // 0x0040
    NotOverridden = 128, // 0x0080
    NotWalkThrough = 256, // 0x0100
    AllLayers = WaterwayLayer | SubPipelineLayer | PipelineLayer | NormalLayers, // 0x001E
  }
}
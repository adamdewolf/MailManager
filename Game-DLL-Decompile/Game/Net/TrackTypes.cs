﻿// Decompiled with JetBrains decompiler
// Type: Game.Net.TrackTypes
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Net
{
  [Flags]
  public enum TrackTypes : byte
  {
    None = 0,
    Train = 1,
    Tram = 2,
    Subway = 4,
  }
}
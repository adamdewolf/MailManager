﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AgeMask
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum AgeMask : byte
  {
    Child = 1,
    Teen = 2,
    Adult = 4,
    Elderly = 8,
    Any = Elderly | Adult | Teen | Child, // 0x0F
  }
}
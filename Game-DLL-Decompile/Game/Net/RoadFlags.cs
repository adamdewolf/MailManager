// Decompiled with JetBrains decompiler
// Type: Game.Net.RoadFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Net
{
  [Flags]
  public enum RoadFlags : byte
  {
    StartHalfAligned = 1,
    EndHalfAligned = 2,
    IsLit = 4,
    AlwaysLit = 8,
    LightsOff = 16, // 0x10
  }
}

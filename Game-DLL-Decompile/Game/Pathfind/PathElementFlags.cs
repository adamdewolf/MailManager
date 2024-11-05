// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.PathElementFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Pathfind
{
  [Flags]
  public enum PathElementFlags : byte
  {
    Secondary = 1,
    PathStart = 2,
    Action = 4,
    Return = 8,
    Reverse = 16, // 0x10
    WaitPosition = 32, // 0x20
    Leader = 64, // 0x40
  }
}

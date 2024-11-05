// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetAreaFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum NetAreaFlags
  {
    Buildable = 1,
    Invert = 2,
    Hole = 4,
    NoBridge = 8,
  }
}

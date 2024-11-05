// Decompiled with JetBrains decompiler
// Type: Game.Common.CollisionMask
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Common
{
  [Flags]
  public enum CollisionMask
  {
    OnGround = 1,
    Overground = 2,
    Underground = 4,
    ExclusiveGround = 8,
  }
}

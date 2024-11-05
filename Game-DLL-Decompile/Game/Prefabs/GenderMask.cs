// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.GenderMask
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum GenderMask : byte
  {
    Female = 1,
    Male = 2,
    Other = 4,
    Any = Other | Male | Female, // 0x07
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ObjectRequirementFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum ObjectRequirementFlags : ushort
  {
    Renter = 1,
    Children = 2,
    Snow = 4,
    Teens = 8,
    GoodWealth = 16, // 0x0010
    Dogs = 32, // 0x0020
    Homeless = 64, // 0x0040
  }
}

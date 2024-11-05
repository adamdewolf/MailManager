// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.OutsideConnectionTransferType
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum OutsideConnectionTransferType
  {
    None = 0,
    Road = 1,
    Train = 2,
    Air = 4,
    Ship = 16, // 0x00000010
    Last = 32, // 0x00000020
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Citizens.CriminalFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Citizens
{
  [Flags]
  public enum CriminalFlags : ushort
  {
    Robber = 1,
    Prisoner = 2,
    Planning = 4,
    Preparing = 8,
    Monitored = 16, // 0x0010
    Arrested = 32, // 0x0020
    Sentenced = 64, // 0x0040
  }
}

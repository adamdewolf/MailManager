// Decompiled with JetBrains decompiler
// Type: Game.Triggers.TargetType
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Triggers
{
  [Flags]
  public enum TargetType
  {
    Nothing = 0,
    Building = 1,
    Citizen = 2,
    Policy = 4,
    Road = 8,
    ServiceBuilding = 16, // 0x00000010
  }
}

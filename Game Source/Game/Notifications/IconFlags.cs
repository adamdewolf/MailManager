// Decompiled with JetBrains decompiler
// Type: Game.Notifications.IconFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Notifications
{
  [Flags]
  public enum IconFlags : byte
  {
    Unique = 1,
    IgnoreTarget = 2,
    TargetLocation = 4,
    OnTop = 8,
    SecondaryLocation = 16, // 0x10
    CustomLocation = 32, // 0x20
  }
}

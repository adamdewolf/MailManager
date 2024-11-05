// Decompiled with JetBrains decompiler
// Type: Game.Notifications.IconPriority
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Notifications
{
  public enum IconPriority : byte
  {
    Min = 0,
    Info = 10, // 0x0A
    Problem = 50, // 0x32
    Warning = 100, // 0x64
    MajorProblem = 150, // 0x96
    Error = 200, // 0xC8
    FatalProblem = 250, // 0xFA
    Max = 255, // 0xFF
  }
}

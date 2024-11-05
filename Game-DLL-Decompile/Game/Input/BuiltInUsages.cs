// Decompiled with JetBrains decompiler
// Type: Game.Input.BuiltInUsages
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Input
{
  [Flags]
  public enum BuiltInUsages
  {
    Menu = 1,
    Default = 2,
    Overlay = 4,
    Tool = 8,
    CancelableTool = 16, // 0x00000010
    Debug = 32, // 0x00000020
    Editor = 64, // 0x00000040
    PhotoMode = 128, // 0x00000080
    Options = 256, // 0x00000100
    Tutorial = 512, // 0x00000200
    All = Tutorial | Options | PhotoMode | Editor | Debug | CancelableTool | Tool | Overlay | Default | Menu, // 0x000003FF
  }
}

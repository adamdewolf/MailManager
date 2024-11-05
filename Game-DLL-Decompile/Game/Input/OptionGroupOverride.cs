// Decompiled with JetBrains decompiler
// Type: Game.Input.OptionGroupOverride
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.ComponentModel;

#nullable disable
namespace Game.Input
{
  public enum OptionGroupOverride
  {
    None,
    [Description("kNavigationMap")] Navigation,
    [Description("kMenuMap")] Menu,
    [Description("kCameraMap")] Camera,
    [Description("kToolMap")] Tool,
    [Description("kShortcutsMap")] Shortcuts,
    [Description("kPhotoModeMap")] PhotoMode,
    [Description("Toolbar")] Toolbar,
    [Description("Tutorial")] Tutorial,
    [Description("Simulation")] Simulation,
    [Description("SIP")] SIP,
  }
}

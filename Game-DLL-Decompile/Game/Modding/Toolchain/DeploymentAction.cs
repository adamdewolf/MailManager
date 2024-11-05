// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.DeploymentAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Modding.Toolchain
{
  [Flags]
  public enum DeploymentAction
  {
    None = 0,
    Install = 2,
    Update = 4,
    Repair = 8,
    Uninstall = 16, // 0x00000010
  }
}

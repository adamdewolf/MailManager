// Decompiled with JetBrains decompiler
// Type: Game.Modding.Toolchain.DeploymentState
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Modding.Toolchain
{
  public enum DeploymentState
  {
    Unknown = -1, // 0xFFFFFFFF
    Installed = 0,
    NotInstalled = 1,
    Outdated = 2,
    Invalid = 3,
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Settings.GraphicsSettingsExtensions
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using UnityEngine;

#nullable disable
namespace Game.Settings
{
  public static class GraphicsSettingsExtensions
  {
    public static CursorLockMode ToUnityCursorMode(this GraphicsSettings.CursorMode mode)
    {
      if (mode == GraphicsSettings.CursorMode.Free)
        return CursorLockMode.None;
      if (mode == GraphicsSettings.CursorMode.ConfinedToWindow)
        return CursorLockMode.Confined;
      throw new ArgumentException(string.Format("Unsupported cursor mode: {0}", (object) mode), nameof (mode));
    }
  }
}

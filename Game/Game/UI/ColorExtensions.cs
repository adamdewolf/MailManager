﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.ColorExtensions
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine;

#nullable disable
namespace Game.UI
{
  public static class ColorExtensions
  {
    public static string ToHexCode(this Color color, bool ignoreAlpha = false)
    {
      if (ignoreAlpha)
        return string.Format("#{0:X2}{1:X2}{2:X2}", (object) (int) ((double) color.r * (double) byte.MaxValue), (object) (int) ((double) color.g * (double) byte.MaxValue), (object) (int) ((double) color.b * (double) byte.MaxValue));
      return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", (object) (int) ((double) color.r * (double) byte.MaxValue), (object) (int) ((double) color.g * (double) byte.MaxValue), (object) (int) ((double) color.b * (double) byte.MaxValue), (object) (int) ((double) color.a * (double) byte.MaxValue));
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.ModifierUIUtils
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Prefabs;
using Unity.Mathematics;

#nullable disable
namespace Game.UI.InGame
{
  public static class ModifierUIUtils
  {
    public static float GetModifierDelta(ModifierValueMode mode, float delta)
    {
      if (mode == ModifierValueMode.Relative)
        return 100f * delta;
      return mode == ModifierValueMode.InverseRelative ? (float) (100.0 * (1.0 / (double) math.max(1f / 1000f, 1f + delta) - 1.0)) : delta;
    }

    public static string GetModifierUnit(ModifierValueMode mode)
    {
      return mode == ModifierValueMode.Absolute ? "floatSingleFraction" : "percentage";
    }
  }
}
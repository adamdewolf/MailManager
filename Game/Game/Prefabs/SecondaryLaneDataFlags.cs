// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SecondaryLaneDataFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [Flags]
  public enum SecondaryLaneDataFlags
  {
    SkipSafePedestrianOverlap = 1,
    SkipSafeCarOverlap = 2,
    SkipUnsafeCarOverlap = 4,
    SkipMergeOverlap = 8,
    FitToParkingSpaces = 16, // 0x00000010
    SkipTrackOverlap = 32, // 0x00000020
    EvenSpacing = 64, // 0x00000040
  }
}

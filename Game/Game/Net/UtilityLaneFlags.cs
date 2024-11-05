// Decompiled with JetBrains decompiler
// Type: Game.Net.UtilityLaneFlags
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Net
{
  [Flags]
  public enum UtilityLaneFlags
  {
    SecondaryStartAnchor = 1,
    SecondaryEndAnchor = 2,
    PipelineConnection = 4,
    CutForTraffic = 8,
  }
}

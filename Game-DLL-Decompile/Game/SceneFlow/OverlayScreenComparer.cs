// Decompiled with JetBrains decompiler
// Type: Game.SceneFlow.OverlayScreenComparer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;

#nullable disable
namespace Game.SceneFlow
{
  internal class OverlayScreenComparer : IComparer<OverlayScreen>
  {
    public int Compare(OverlayScreen x, OverlayScreen y) => ((int) x).CompareTo((int) y);
  }
}

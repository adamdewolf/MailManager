// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.IGradientInfomode
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.UI.Localization;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public interface IGradientInfomode
  {
    GradientLegendType legendType { get; }

    LocalizedString? lowLabel { get; }

    LocalizedString? mediumLabel { get; }

    LocalizedString? highLabel { get; }

    Color lowColor { get; }

    Color mediumColor { get; }

    Color highColor { get; }
  }
}

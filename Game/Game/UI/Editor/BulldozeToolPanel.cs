// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.BulldozeToolPanel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.UI.Localization;
using Game.UI.Widgets;
using System;
using System.Collections.Generic;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.Editor
{
  public class BulldozeToolPanel : EditorPanelSystemBase
  {
    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.children = (IList<IWidget>) Array.Empty<IWidget>();
      this.title = (LocalizedString) "Editor.TOOL[BulldozeTool]";
    }

    [Preserve]
    public BulldozeToolPanel()
    {
    }
  }
}

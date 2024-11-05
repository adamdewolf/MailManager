// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.IEditorPanel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.UI.Localization;
using Game.UI.Widgets;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Editor
{
  public interface IEditorPanel
  {
    [CanBeNull]
    LocalizedString title { get; }

    IList<IWidget> children { get; }

    void OnValueChanged(IWidget widget);

    bool OnCancel();

    bool OnClose();

    EditorPanelWidgetRenderer widgetRenderer { get; }
  }
}

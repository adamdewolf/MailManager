﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.ButtonRow
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Game.UI.Widgets
{
  public class ButtonRow : Widget
  {
    private Button[] m_Children = Array.Empty<Button>();

    public Button[] children
    {
      get => this.m_Children;
      set
      {
        if (value == this.m_Children)
          return;
        ContainerExtensions.SetDefaults<Button>((IList<Button>) value);
        this.m_Children = value;
        this.SetChildrenChanged();
      }
    }

    public override bool isVisible
    {
      get
      {
        return ((IEnumerable<Button>) this.children).Any<Button>((Func<Button, bool>) (c => c.isVisible));
      }
    }

    public override bool isActive
    {
      get
      {
        return ((IEnumerable<Button>) this.children).Any<Button>((Func<Button, bool>) (c => c.isActive));
      }
    }

    public override IList<IWidget> visibleChildren => (IList<IWidget>) this.children;

    public static ButtonRow WithChildren(Button[] children)
    {
      return new ButtonRow() { children = children };
    }

    public override WidgetChanges UpdateVisibility()
    {
      WidgetChanges widgetChanges = base.UpdateVisibility();
      foreach (Widget widget in this.visibleChildren.OfType<Widget>())
        widgetChanges |= widget.UpdateVisibility();
      return widgetChanges;
    }
  }
}
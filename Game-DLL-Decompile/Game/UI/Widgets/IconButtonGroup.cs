// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.IconButtonGroup
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Widgets
{
  public class IconButtonGroup : Widget
  {
    private IconButton[] m_Children = Array.Empty<IconButton>();

    public IconButton[] children
    {
      get => this.m_Children;
      set
      {
        if (value == this.m_Children)
          return;
        ContainerExtensions.SetDefaults<IconButton>((IList<IconButton>) value);
        this.m_Children = value;
        this.SetChildrenChanged();
      }
    }

    public override IList<IWidget> visibleChildren => (IList<IWidget>) this.children;

    public static IconButtonGroup WithChildren(IconButton[] children)
    {
      return new IconButtonGroup() { children = children };
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.LayoutContainer
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Widgets
{
  public abstract class LayoutContainer : Widget, IContainerWidget
  {
    private IList<IWidget> m_Children = (IList<IWidget>) Array.Empty<IWidget>();

    public FlexLayout flex { get; set; } = FlexLayout.Default;

    public IList<IWidget> children
    {
      get => this.m_Children;
      set
      {
        if (object.Equals((object) value, (object) this.m_Children))
          return;
        ContainerExtensions.SetDefaults<IWidget>(value);
        this.m_Children = value;
        this.SetChildrenChanged();
      }
    }

    public override IList<IWidget> visibleChildren => this.children;

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("flex");
      writer.Write<FlexLayout>(this.flex);
    }
  }
}

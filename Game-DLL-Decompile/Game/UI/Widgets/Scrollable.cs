// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Scrollable
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Widgets
{
  public class Scrollable : LayoutContainer
  {
    public Direction direction { get; set; }

    public Scrollable() => this.flex = FlexLayout.Fill;

    public static Scrollable WithChildren(IList<IWidget> children)
    {
      Scrollable scrollable = new Scrollable();
      scrollable.children = children;
      return scrollable;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("direction");
      writer.Write((int) this.direction);
    }
  }
}

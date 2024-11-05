// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Breadcrumbs
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Game.UI.Widgets
{
  public class Breadcrumbs : Widget, IEnumerable<Label>, IEnumerable, IContainerWidget
  {
    private List<IWidget> m_Labels = new List<IWidget>();

    public int labelCount => this.m_Labels.Count;

    public IList<IWidget> children => (IList<IWidget>) this.m_Labels;

    public Breadcrumbs WithLabel(Label label)
    {
      this.m_Labels.Add((IWidget) label);
      return this;
    }

    public Breadcrumbs WithOutLabel(Label label)
    {
      this.m_Labels.Remove((IWidget) label);
      return this;
    }

    public override IList<IWidget> visibleChildren => (IList<IWidget>) this.m_Labels;

    public IEnumerator<Label> GetEnumerator() => this.m_Labels.OfType<Label>().GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => (IEnumerator) this.GetEnumerator();
  }
}

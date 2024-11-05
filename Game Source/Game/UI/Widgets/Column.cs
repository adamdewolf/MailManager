// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Column
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;

#nullable disable
namespace Game.UI.Widgets
{
  internal class Column : LayoutContainer
  {
    public static Column WithChildren(IList<IWidget> children)
    {
      Column column = new Column();
      column.children = children;
      return column;
    }
  }
}

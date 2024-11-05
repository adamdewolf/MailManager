// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.IWidget
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Widgets
{
  public interface IWidget : IJsonWritable
  {
    PathSegment path { get; set; }

    IList<IWidget> visibleChildren { get; }

    WidgetChanges Update();

    string propertiesTypeName { get; }

    void WriteProperties(IJsonWriter writer);
  }
}

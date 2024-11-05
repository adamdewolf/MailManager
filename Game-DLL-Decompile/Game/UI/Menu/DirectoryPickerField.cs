// Decompiled with JetBrains decompiler
// Type: Game.UI.Menu.DirectoryPickerField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Widgets;
using System;

#nullable disable
namespace Game.UI.Menu
{
  public class DirectoryPickerField : Field<string>, IInvokable, IWidget, IJsonWritable
  {
    public override string propertiesTypeName => "Game.UI.Widgets.DirectoryPickerField";

    public Action action { get; set; }

    public void Invoke()
    {
      Action action = this.action;
      if (action == null)
        return;
      action();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.DirectoryPickerButton
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class DirectoryPickerButton : NamedWidgetWithTooltip, IInvokable, IWidget, IJsonWritable
  {
    private string m_SelectedDirectory;

    public string displayValue { get; set; }

    public Action action { get; set; }

    public override string propertiesTypeName => "Game.UI.Widgets.DirectoryPickerButton";

    public void Invoke() => this.action();

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("selectedDirectory");
      writer.Write(this.m_SelectedDirectory);
      writer.PropertyName("displayValue");
      writer.Write(this.displayValue);
      writer.PropertyName("uiTag");
      writer.Write(this.uiTag);
    }
  }
}

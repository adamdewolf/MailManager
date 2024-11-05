// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.SearchField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Widgets;

#nullable disable
namespace Game.UI.Editor
{
  public class SearchField : Widget, ISettable, IWidget, IJsonWritable
  {
    private string m_Value;

    public SearchField.IAdapter adapter { get; set; }

    public bool shouldTriggerValueChangedEvent => true;

    public void SetValue(IJsonReader reader)
    {
      string str;
      reader.Read(out str);
      this.SetValue(str);
    }

    public void SetValue(string value)
    {
      if (!(value != this.m_Value))
        return;
      this.adapter.searchQuery = value;
    }

    protected override WidgetChanges Update()
    {
      WidgetChanges widgetChanges = base.Update();
      if (this.adapter.searchQuery != this.m_Value)
      {
        widgetChanges |= WidgetChanges.Properties;
        this.m_Value = this.adapter.searchQuery;
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("value");
      writer.Write(this.m_Value ?? string.Empty);
    }

    public interface IAdapter
    {
      string searchQuery { get; set; }
    }
  }
}

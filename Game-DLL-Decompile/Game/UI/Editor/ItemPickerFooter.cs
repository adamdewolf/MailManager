// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.ItemPickerFooter
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Widgets;

#nullable disable
namespace Game.UI.Editor
{
  public class ItemPickerFooter : Widget, ISettable, IWidget, IJsonWritable
  {
    private int m_Length;
    private int m_ColumnCount;

    public ItemPickerFooter.IAdapter adapter { get; set; }

    public bool shouldTriggerValueChangedEvent => true;

    public void SetValue(IJsonReader reader)
    {
      int num;
      reader.Read(out num);
      this.adapter.columnCount = num;
    }

    protected override WidgetChanges Update()
    {
      WidgetChanges widgetChanges = base.Update();
      if (this.adapter.length != this.m_Length)
      {
        widgetChanges |= WidgetChanges.Properties;
        this.m_Length = this.adapter.length;
      }
      if (this.adapter.columnCount != this.m_ColumnCount)
      {
        widgetChanges |= WidgetChanges.Properties;
        this.m_ColumnCount = this.adapter.columnCount;
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("length");
      writer.Write(this.m_Length);
      writer.PropertyName("columnCount");
      writer.Write(this.m_ColumnCount);
    }

    public interface IAdapter
    {
      int length { get; }

      int columnCount { get; set; }
    }
  }
}

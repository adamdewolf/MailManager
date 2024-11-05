// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.DropdownField`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.Reflection;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class DropdownField<T> : Field<T>
  {
    private int m_ItemsVersion = -1;

    public DropdownItem<T>[] items { get; set; } = Array.Empty<DropdownItem<T>>();

    [CanBeNull]
    public Func<int> itemsVersion { get; set; }

    public ITypedValueAccessor<DropdownItem<T>[]> itemsAccessor { get; set; }

    public new IWriter<T> valueWriter
    {
      protected get => base.valueWriter;
      set => base.valueWriter = value;
    }

    public new IReader<T> valueReader
    {
      protected get => base.valueReader;
      set => base.valueReader = value;
    }

    public override string propertiesTypeName => "Game.UI.Widgets.DropdownField";

    protected override WidgetChanges Update()
    {
      WidgetChanges widgetChanges = base.Update();
      if (this.itemsAccessor != null)
      {
        Func<int> itemsVersion = this.itemsVersion;
        int num = itemsVersion != null ? itemsVersion() : 0;
        if (num != this.m_ItemsVersion)
        {
          widgetChanges |= WidgetChanges.Properties;
          this.m_ItemsVersion = num;
          this.items = this.itemsAccessor.GetTypedValue() ?? Array.Empty<DropdownItem<T>>();
        }
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("items");
      writer.ArrayBegin(this.items.Length);
      foreach (DropdownItem<T> dropdownItem in this.items)
        dropdownItem.Write(this.valueWriter, writer);
      writer.ArrayEnd();
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.EnumField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.Reflection;
using System;
using System.Collections.Generic;

#nullable disable
namespace Game.UI.Widgets
{
  public class EnumField : Field<ulong>
  {
    private int m_ItemsVersion = -1;

    public EnumMember[] enumMembers { get; set; } = Array.Empty<EnumMember>();

    [CanBeNull]
    public Func<int> itemsVersion { get; set; }

    public ITypedValueAccessor<EnumMember[]> itemsAccessor { get; set; }

    public EnumField()
    {
      this.valueWriter = (IWriter<ulong>) new ULongWriter();
      this.valueReader = (IReader<ulong>) new ULongReader();
    }

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
          this.enumMembers = this.itemsAccessor.GetTypedValue() ?? Array.Empty<EnumMember>();
        }
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("enumMembers");
      writer.Write<EnumMember>((IList<EnumMember>) this.enumMembers);
    }
  }
}

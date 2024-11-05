// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.DropdownItem`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Localization;

#nullable disable
namespace Game.UI.Widgets
{
  public class DropdownItem<T>
  {
    public T value { get; set; }

    public LocalizedString displayName { get; set; }

    public bool disabled { get; set; }

    public void Write(IWriter<T> valueWriter, IJsonWriter writer)
    {
      writer.TypeBegin(typeof (DropdownItem<T>).FullName);
      writer.PropertyName("value");
      valueWriter.Write(writer, this.value);
      writer.PropertyName("displayName");
      writer.Write<LocalizedString>(this.displayName);
      writer.PropertyName("disabled");
      writer.Write(this.disabled);
      writer.TypeEnd();
    }
  }
}

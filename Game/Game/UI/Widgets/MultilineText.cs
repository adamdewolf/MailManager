// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.MultilineText
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public class MultilineText : NamedWidget
  {
    public string icon { get; set; }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("icon");
      writer.Write(this.icon);
    }
  }
}

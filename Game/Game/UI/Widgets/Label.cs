// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Label
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public class Label : NamedWidgetWithTooltip
  {
    public Label.Level level;
    public bool beta;

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("level");
      writer.Write((int) this.level);
      writer.PropertyName("beta");
      writer.Write(this.beta);
    }

    public enum Level
    {
      Title,
      SubTitle,
      GroupTitle,
    }
  }
}

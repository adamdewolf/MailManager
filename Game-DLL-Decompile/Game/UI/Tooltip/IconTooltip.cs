// Decompiled with JetBrains decompiler
// Type: Game.UI.Tooltip.IconTooltip
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.UI.Widgets;

#nullable disable
namespace Game.UI.Tooltip
{
  public abstract class IconTooltip : Widget
  {
    [CanBeNull]
    private string m_Icon;
    private TooltipColor m_Color;

    [CanBeNull]
    public string icon
    {
      get => this.m_Icon;
      set
      {
        if (!(value != this.m_Icon))
          return;
        this.m_Icon = value;
        this.SetPropertiesChanged();
      }
    }

    public TooltipColor color
    {
      get => this.m_Color;
      set
      {
        if (value == this.m_Color)
          return;
        this.m_Color = value;
        this.SetPropertiesChanged();
      }
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("icon");
      writer.Write(this.icon);
      writer.PropertyName("color");
      writer.Write((int) this.color);
    }
  }
}

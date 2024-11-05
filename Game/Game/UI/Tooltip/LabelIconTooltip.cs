// Decompiled with JetBrains decompiler
// Type: Game.UI.Tooltip.LabelIconTooltip
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.UI.Localization;

#nullable disable
namespace Game.UI.Tooltip
{
  public abstract class LabelIconTooltip : IconTooltip
  {
    [CanBeNull]
    private LocalizedString m_Label;

    [CanBeNull]
    public LocalizedString label
    {
      get => this.m_Label;
      set
      {
        if (object.Equals((object) value, (object) this.m_Label))
          return;
        this.m_Label = value;
        this.SetPropertiesChanged();
      }
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("label");
      writer.Write<LocalizedString>(this.label);
    }
  }
}

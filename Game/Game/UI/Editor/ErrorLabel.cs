// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.ErrorLabel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Widgets;

#nullable disable
namespace Game.UI.Editor
{
  public class ErrorLabel : Label
  {
    private bool m_Visible;

    public bool visible
    {
      get => this.m_Visible;
      set
      {
        if (this.m_Visible == value)
          return;
        this.m_Visible = value;
        this.SetPropertiesChanged();
      }
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("visible");
      writer.Write(this.m_Visible);
    }
  }
}

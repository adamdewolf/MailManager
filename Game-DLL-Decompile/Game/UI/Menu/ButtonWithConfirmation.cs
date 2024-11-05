// Decompiled with JetBrains decompiler
// Type: Game.UI.Menu.ButtonWithConfirmation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Localization;
using Game.UI.Widgets;

#nullable disable
namespace Game.UI.Menu
{
  public class ButtonWithConfirmation : Button
  {
    private LocalizedString? m_ConfirmationMessage;

    public LocalizedString? confirmationMessage
    {
      get => this.m_ConfirmationMessage;
      set
      {
        if (this.m_ConfirmationMessage.Equals((object) value))
          return;
        this.m_ConfirmationMessage = value;
        this.SetPropertiesChanged();
      }
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("confirmationMessage");
      writer.Write<LocalizedString>(this.confirmationMessage);
    }
  }
}

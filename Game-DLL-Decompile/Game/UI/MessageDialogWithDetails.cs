// Decompiled with JetBrains decompiler
// Type: Game.UI.MessageDialogWithDetails
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public class MessageDialogWithDetails : ConfirmationDialogBase
  {
    public MessageDialogWithDetails(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [CanBeNull] LocalizedString details,
      bool copyButton,
      [NotNull] LocalizedString confirmAction)
      : base(false, "Default", title, message, new LocalizedString?(details), copyButton, confirmAction, (LocalizedString) (string) null)
    {
      this.hasCancelAction = false;
    }

    public MessageDialogWithDetails(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [CanBeNull] LocalizedString details,
      bool copyButton,
      [NotNull] LocalizedString confirmAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(false, "Default", title, message, new LocalizedString?(details), copyButton, confirmAction, (LocalizedString) (string) null, otherActions)
    {
      this.hasCancelAction = false;
    }
  }
}

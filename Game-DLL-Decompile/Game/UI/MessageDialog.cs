// Decompiled with JetBrains decompiler
// Type: Game.UI.MessageDialog
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public class MessageDialog : ConfirmationDialogBase
  {
    public MessageDialog(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [NotNull] LocalizedString confirmAction)
      : base(false, "Default", title, message, new LocalizedString?(), false, confirmAction, (LocalizedString) (string) null)
    {
      this.hasCancelAction = false;
    }

    public MessageDialog(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [NotNull] LocalizedString confirmAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(false, "Default", title, message, new LocalizedString?(), false, confirmAction, (LocalizedString) (string) null, otherActions)
    {
      this.hasCancelAction = false;
    }
  }
}

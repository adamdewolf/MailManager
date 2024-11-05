// Decompiled with JetBrains decompiler
// Type: Game.UI.DismissableConfirmationDialog
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public class DismissableConfirmationDialog : ConfirmationDialogBase
  {
    public DismissableConfirmationDialog(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [NotNull] LocalizedString confirmAction,
      [NotNull] LocalizedString cancelAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(true, "Default", title, message, new LocalizedString?(), false, confirmAction, cancelAction, otherActions)
    {
    }
  }
}

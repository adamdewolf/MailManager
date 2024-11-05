// Decompiled with JetBrains decompiler
// Type: Game.UI.ConfirmationDialog
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public class ConfirmationDialog : ConfirmationDialogBase
  {
    public ConfirmationDialog(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [NotNull] LocalizedString confirmAction,
      [NotNull] LocalizedString cancelAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(false, "Default", title, message, new LocalizedString?(), false, confirmAction, cancelAction, otherActions)
    {
    }

    protected ConfirmationDialog(
      string skin,
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [NotNull] LocalizedString confirmAction,
      [NotNull] LocalizedString cancelAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(false, skin, title, message, new LocalizedString?(), false, confirmAction, cancelAction, otherActions)
    {
    }
  }
}

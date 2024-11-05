// Decompiled with JetBrains decompiler
// Type: Game.UI.ConfirmationDialogWithDetails
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public class ConfirmationDialogWithDetails : ConfirmationDialogBase
  {
    public ConfirmationDialogWithDetails(
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [CanBeNull] LocalizedString details,
      bool copyButton,
      [NotNull] LocalizedString confirmAction,
      [NotNull] LocalizedString cancelAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(false, "Default", title, message, new LocalizedString?(details), copyButton, confirmAction, cancelAction, otherActions)
    {
    }

    protected ConfirmationDialogWithDetails(
      string skin,
      [CanBeNull] LocalizedString title,
      [NotNull] LocalizedString message,
      [CanBeNull] LocalizedString details,
      bool copyButton,
      [NotNull] LocalizedString confirmAction,
      [NotNull] LocalizedString cancelAction,
      [CanBeNull] params LocalizedString[] otherActions)
      : base(false, skin, title, message, new LocalizedString?(details), copyButton, confirmAction, cancelAction, otherActions)
    {
    }
  }
}

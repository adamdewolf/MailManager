// Decompiled with JetBrains decompiler
// Type: Game.UI.ParadoxCloudConflictResolutionDialog
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.UI.Localization;

#nullable disable
namespace Game.UI
{
  public class ParadoxCloudConflictResolutionDialog : ConfirmationDialog
  {
    private const string kTitle = "Common.DIALOG_TITLE[PdxSdkCloudConflict]";
    private const string kMessage = "Common.DIALOG_MESSAGE[PdxSdkCloudConflict]";
    private const string kUseLocal = "Common.DIALOG_ACTION[UseLocal]";
    private const string kUseCloud = "Common.DIALOG_ACTION[UseCloud]";

    public ParadoxCloudConflictResolutionDialog()
      : base("Paradox", (LocalizedString) "Common.DIALOG_TITLE[PdxSdkCloudConflict]", (LocalizedString) "Common.DIALOG_MESSAGE[PdxSdkCloudConflict]", (LocalizedString) "Common.DIALOG_ACTION[UseCloud]", new LocalizedString(), (LocalizedString) "Common.DIALOG_ACTION[UseLocal]")
    {
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.DialogMessage
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.UI
{
  public static class DialogMessage
  {
    public const string kBulldozer = "Common.DIALOG_MESSAGE[Bulldozer]";
    public const string kProgressLoss = "Common.DIALOG_MESSAGE[ProgressLoss]";
    public const string kOverwriteSave = "Common.DIALOG_MESSAGE[Overwrite]";
    public const string kOverwriteMap = "Common.DIALOG_MESSAGE[OverwriteMap]";
    public const string kOverwriteAsset = "Common.DIALOG_MESSAGE[OverwriteAsset]";
    public const string kConfirmWipe = "Common.DIALOG_MESSAGE[ConfirmRemoteStorageWipe]";

    public static string GetId(string value) => "Common.DIALOG_MESSAGE[" + value + "]";
  }
}

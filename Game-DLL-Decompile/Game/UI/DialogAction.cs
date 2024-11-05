// Decompiled with JetBrains decompiler
// Type: Game.UI.DialogAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.UI
{
  public static class DialogAction
  {
    public const string kYes = "Common.DIALOG_ACTION[Yes]";
    public const string kNo = "Common.DIALOG_ACTION[No]";

    public static string GetId(string value) => "Common.DIALOG_ACTION[" + value + "]";
  }
}

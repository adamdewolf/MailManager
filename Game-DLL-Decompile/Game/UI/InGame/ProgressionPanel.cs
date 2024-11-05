// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.ProgressionPanel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.UI.InGame
{
  public class ProgressionPanel : TabbedGamePanel
  {
    public override bool blocking => true;

    public override GamePanel.LayoutPosition position => GamePanel.LayoutPosition.Center;

    public override bool retainProperties => true;

    public enum Tab
    {
      Development,
      Milestones,
      Achievements,
    }
  }
}

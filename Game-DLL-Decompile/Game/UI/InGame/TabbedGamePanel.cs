// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.TabbedGamePanel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;

#nullable disable
namespace Game.UI.InGame
{
  public abstract class TabbedGamePanel : GamePanel, IEquatable<TabbedGamePanel>
  {
    public virtual int selectedTab { get; set; }

    protected override void BindProperties(IJsonWriter writer)
    {
      base.BindProperties(writer);
      writer.PropertyName("selectedTab");
      writer.Write(this.selectedTab);
    }

    public bool Equals(TabbedGamePanel other)
    {
      if (other == null)
        return false;
      return this == other || this.selectedTab.Equals(other.selectedTab);
    }
  }
}

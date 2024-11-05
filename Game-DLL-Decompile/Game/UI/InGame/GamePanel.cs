// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.GamePanel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.InGame
{
  public abstract class GamePanel : IJsonWritable
  {
    public virtual bool blocking => false;

    public virtual bool retainSelection => false;

    public virtual bool retainProperties => false;

    public virtual GamePanel.LayoutPosition position => GamePanel.LayoutPosition.Undefined;

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      this.BindProperties(writer);
      writer.TypeEnd();
    }

    protected virtual void BindProperties(IJsonWriter writer)
    {
    }

    public enum LayoutPosition
    {
      Undefined,
      Left,
      Center,
      Right,
    }
  }
}

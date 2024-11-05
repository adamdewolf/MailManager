// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.StringProperty
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.InGame
{
  public struct StringProperty : IJsonWritable
  {
    public string labelId;
    public string valueId;
    public string icon;
    public string valueIcon;

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin("Game.UI.Common.StringProperty");
      writer.PropertyName("labelId");
      writer.Write(this.labelId);
      writer.PropertyName("valueId");
      writer.Write(this.valueId);
      writer.PropertyName("icon");
      writer.Write(this.icon);
      writer.PropertyName("valueIcon");
      writer.Write(this.valueIcon);
      writer.TypeEnd();
    }
  }
}

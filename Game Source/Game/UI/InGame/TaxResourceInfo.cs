// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.TaxResourceInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.InGame
{
  public struct TaxResourceInfo : IJsonWritable
  {
    public string m_ID;
    public string m_Icon;

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin("taxation.TaxResourceInfo");
      writer.PropertyName("id");
      writer.Write(this.m_ID);
      writer.PropertyName("icon");
      writer.Write(this.m_Icon);
      writer.TypeEnd();
    }
  }
}

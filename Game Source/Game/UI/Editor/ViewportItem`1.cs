// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.ViewportItem`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Editor
{
  public struct ViewportItem<T> : IJsonWritable
  {
    public HierarchyItem<T> m_Item;
    public int m_ItemIndex;

    public void Write(IJsonWriter writer) => writer.Write<HierarchyItem<T>>(this.m_Item);
  }
}

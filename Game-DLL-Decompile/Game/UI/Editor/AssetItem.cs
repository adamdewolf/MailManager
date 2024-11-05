// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.AssetItem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal;
using System;

#nullable disable
namespace Game.UI.Editor
{
  public class AssetItem : IItemPicker.Item, IComparable<AssetItem>
  {
    public Hash128 guid { get; set; }

    public string fileName { get; set; }

    public int CompareTo(AssetItem other)
    {
      return this.favorite == other.favorite ? string.CompareOrdinal(this.fileName, other.fileName) : -this.favorite.CompareTo(other.favorite);
    }
  }
}

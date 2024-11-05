// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.FileItem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.UI.Editor
{
  public class FileItem : IItemPicker.Item, IComparable<FileItem>
  {
    public string path { get; set; }

    public int CompareTo(FileItem other) => string.CompareOrdinal(this.path, other.path);
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.EditorAssetImportTool
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.UI.Editor
{
  public class EditorAssetImportTool : EditorTool
  {
    public EditorAssetImportTool(World world)
      : base(world)
    {
      this.id = "AssetImportTool";
      this.uiTag = "UITagPrefab:AssetImportButton";
      this.icon = "Media/Editor/AssetImport.svg";
      this.panel = (IEditorPanel) world.GetOrCreateSystemManaged<AssetImportPanel>();
    }
  }
}
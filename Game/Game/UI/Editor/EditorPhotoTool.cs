// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.EditorPhotoTool
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.UI.Editor
{
  public class EditorPhotoTool : EditorTool
  {
    public EditorPhotoTool(World world)
      : base(world)
    {
      this.id = "PhotoTool";
      this.icon = "Media/Editor/CinematicCameraOff.svg";
      this.panel = (IEditorPanel) world.GetOrCreateSystemManaged<EditorPhotoModePanel>();
    }
  }
}

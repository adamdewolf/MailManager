// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.IEditorGenerator
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Game.Reflection;

#nullable disable
namespace Game.UI.Widgets
{
  public interface IEditorGenerator
  {
    IWidget Build([NotNull] IValueAccessor accessor, [NotNull] object[] attributes, int level, string path);
  }
}

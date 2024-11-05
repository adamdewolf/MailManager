// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ComponentMenu
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Prefabs
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  public sealed class ComponentMenu : Attribute
  {
    public readonly string menu;
    public readonly Type[] requiredPrefab;

    public ComponentMenu(params Type[] requiredPrefab) => this.requiredPrefab = requiredPrefab;

    public ComponentMenu(string menu, params Type[] requiredPrefab)
      : this(requiredPrefab)
    {
      this.menu = menu;
    }
  }
}

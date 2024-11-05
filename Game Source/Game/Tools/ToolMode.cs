// Decompiled with JetBrains decompiler
// Type: Game.Tools.ToolMode
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Tools
{
  public readonly struct ToolMode
  {
    public string name { get; }

    public int index { get; }

    public ToolMode(string name, int index)
    {
      this.name = name;
      this.index = index;
    }
  }
}

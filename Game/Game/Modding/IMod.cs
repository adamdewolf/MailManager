// Decompiled with JetBrains decompiler
// Type: Game.Modding.IMod
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Modding
{
  public interface IMod
  {
    void OnLoad(UpdateSystem updateSystem);

    void OnDispose();
  }
}

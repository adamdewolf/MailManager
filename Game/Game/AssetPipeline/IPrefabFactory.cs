// Decompiled with JetBrains decompiler
// Type: Game.AssetPipeline.IPrefabFactory
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Prefabs;

#nullable disable
namespace Game.AssetPipeline
{
  public interface IPrefabFactory
  {
    T CreatePrefab<T>(string sourcePath, string name, int lodLevel) where T : PrefabBase;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.SceneFlow.SaveHelpers
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.IO.AssetDatabase;
using Colossal.PSI.Environment;
using Game.Assets;
using Game.PSI.PdxSdk;
using Game.Settings;

#nullable disable
namespace Game.SceneFlow
{
  public static class SaveHelpers
  {
    public const string kSaveLoadTaskName = "SaveLoadGame";

    public static AssetDataPath GetAssetDataPath<T>(ILocalAssetDatabase database, string saveName)
    {
      AssetDataPath assetDataPath = (AssetDataPath) saveName;
      if (!database.dataSource.isRemoteStorageSource)
      {
        string specialPath = EnvPath.GetSpecialPath<T>();
        if (specialPath != null)
          assetDataPath = AssetDataPath.Create(specialPath, saveName);
      }
      return assetDataPath;
    }

    public static void DeleteSaveGame(SaveGameMetadata saveGameMetadata)
    {
      UserState userState = GameManager.instance.settings.userState;
      if ((AssetData) userState.lastSaveGameMetadata == (IAssetData) saveGameMetadata)
      {
        userState.lastSaveGameMetadata = (SaveGameMetadata) null;
        userState.ApplyAndSave();
        Launcher.DeleteLastSaveMetadata();
      }
      Colossal.IO.AssetDatabase.AssetDatabase.global.DeleteAsset<SaveGameMetadata>(saveGameMetadata);
    }
  }
}

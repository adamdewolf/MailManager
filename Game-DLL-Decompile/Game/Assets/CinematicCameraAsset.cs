// Decompiled with JetBrains decompiler
// Type: Game.Assets.CinematicCameraAsset
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.IO.AssetDatabase;
using Colossal.PSI.Common;
using Colossal.UI.Binding;
using Game.CinematicCamera;
using Game.UI.Menu;
using System;

#nullable disable
namespace Game.Assets
{
  public class CinematicCameraAsset : Metadata<CinematicCameraSequence>, IJsonWritable
  {
    public const string kExtension = ".CinematicCamera";
    public static readonly Func<string> kPersistentLocation = (Func<string>) (() => "CinematicCamera/" + PlatformManager.instance.userSpecificPath);
    private static readonly string kCloudTargetProperty = "cloudTarget";
    private static readonly string kReadOnlyProperty = "isReadOnly";

    public void Write(IJsonWriter writer)
    {
      SourceMeta meta = this.GetMeta();
      writer.TypeBegin(nameof (CinematicCameraAsset));
      writer.PropertyName("name");
      writer.Write(this.name);
      writer.PropertyName("guid");
      writer.Write(this.guid.ToString());
      writer.PropertyName("identifier");
      writer.Write(this.identifier);
      writer.PropertyName(CinematicCameraAsset.kCloudTargetProperty);
      writer.Write(MenuHelpers.GetSanitizedCloudTarget(meta.remoteStorageSourceName).name);
      writer.PropertyName(CinematicCameraAsset.kReadOnlyProperty);
      writer.Write(!meta.belongsToCurrentUser);
      writer.TypeEnd();
    }
  }
}

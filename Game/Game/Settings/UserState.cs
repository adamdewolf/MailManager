// Decompiled with JetBrains decompiler
// Type: Game.Settings.UserState
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.IO.AssetDatabase;
using Game.Assets;
using Game.Tutorials;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Settings
{
  [FileLocation("UserState")]
  public class UserState : Setting
  {
    public System.Collections.Generic.Dictionary<string, bool> shownTutorials { get; set; }

    public SaveGameMetadata lastSaveGameMetadata { get; set; }

    public string lastCloudTarget { get; set; }

    public bool leftHandTraffic { get; set; }

    public bool naturalDisasters { get; set; }

    public bool unlockAll { get; set; }

    public bool unlimitedMoney { get; set; }

    public bool unlockMapTiles { get; set; }

    [SettingsUIHidden]
    public List<string> seenWhatsNew { get; set; }

    public void ResetTutorials()
    {
      this.shownTutorials.Clear();
      this.ApplyAndSave();
      // ISSUE: reference to a compiler-generated method
      World.DefaultGameObjectInjectionWorld.GetExistingSystemManaged<TutorialSystem>().OnResetTutorials();
    }

    public UserState() => this.SetDefaults();

    public override void SetDefaults()
    {
      this.shownTutorials = new System.Collections.Generic.Dictionary<string, bool>();
      this.lastSaveGameMetadata = (SaveGameMetadata) null;
      this.lastCloudTarget = this.GetDefaultCloudTarget();
      this.leftHandTraffic = false;
      this.naturalDisasters = true;
      this.unlockAll = false;
      this.unlimitedMoney = false;
      this.unlockMapTiles = false;
      this.seenWhatsNew = new List<string>();
    }

    private string GetDefaultCloudTarget() => "Local";
  }
}

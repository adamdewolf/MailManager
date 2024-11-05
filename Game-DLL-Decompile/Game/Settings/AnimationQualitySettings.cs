// Decompiled with JetBrains decompiler
// Type: Game.Settings.AnimationQualitySettings
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine;

#nullable disable
namespace Game.Settings
{
  [SettingsUIAdvanced]
  [SettingsUISection("AnimationQualitySettings")]
  [SettingsUIDisableByCondition(typeof (AnimationQualitySettings), "IsOptionsDisabled")]
  public class AnimationQualitySettings : QualitySetting<AnimationQualitySettings>
  {
    public AnimationQualitySettings.Skinning maxBoneInfuence { get; set; }

    static AnimationQualitySettings()
    {
      QualitySetting<AnimationQualitySettings>.RegisterSetting(QualitySetting.Level.Medium, AnimationQualitySettings.mediumQuality);
      QualitySetting<AnimationQualitySettings>.RegisterSetting(QualitySetting.Level.High, AnimationQualitySettings.highQuality);
    }

    public AnimationQualitySettings()
    {
    }

    public AnimationQualitySettings(QualitySetting.Level quality) => this.SetLevel(quality, false);

    public override void Apply()
    {
      base.Apply();
      if (this.maxBoneInfuence == AnimationQualitySettings.Skinning.FourBones)
      {
        Shader.DisableKeyword("TWO_BONES_INFLUENCE");
      }
      else
      {
        if (this.maxBoneInfuence != AnimationQualitySettings.Skinning.TwoBones)
          return;
        Shader.EnableKeyword("TWO_BONES_INFLUENCE");
      }
    }

    private static AnimationQualitySettings highQuality
    {
      get
      {
        return new AnimationQualitySettings()
        {
          maxBoneInfuence = AnimationQualitySettings.Skinning.FourBones
        };
      }
    }

    private static AnimationQualitySettings mediumQuality
    {
      get
      {
        return new AnimationQualitySettings()
        {
          maxBoneInfuence = AnimationQualitySettings.Skinning.TwoBones
        };
      }
    }

    public enum Skinning
    {
      TwoBones,
      FourBones,
    }
  }
}

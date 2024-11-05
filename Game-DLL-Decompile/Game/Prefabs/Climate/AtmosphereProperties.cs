// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Climate.AtmosphereProperties
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Rendering;
using System;
using UnityEngine.Rendering;
using UnityEngine.Rendering.HighDefinition;

#nullable disable
namespace Game.Prefabs.Climate
{
  [ComponentMenu("Weather/", new Type[] {typeof (WeatherPrefab)})]
  public class AtmosphereProperties : OverrideablePropertiesComponent
  {
    public MinFloatParameter m_AuroraBorealisEmissionMultiplier = new MinFloatParameter(0.0f, 0.0f);
    public MinFloatParameter m_AuroraBorealisSpeedMultiplier = new MinFloatParameter(1f, 0.0f);

    protected override void OnBindVolumeProperties(Volume volume)
    {
      PhysicallyBasedSky component = (PhysicallyBasedSky) null;
      VolumeHelper.GetOrCreateVolumeComponent<PhysicallyBasedSky>(volume, ref component);
      this.m_AuroraBorealisEmissionMultiplier = component.auroraBorealisEmissionMultiplier;
      this.m_AuroraBorealisSpeedMultiplier = component.auroraBorealisSpeedMultiplier;
    }
  }
}

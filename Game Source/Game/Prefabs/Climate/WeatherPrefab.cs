﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.Climate.WeatherPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal;
using Game.Simulation;
using System;
using System.Collections.Generic;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs.Climate
{
  [ComponentMenu("Weather/", new Type[] {})]
  public class WeatherPrefab : PrefabBase
  {
    public WeatherPrefab.RandomizationLayer m_RandomizationLayer;
    [MinMaxSlider(0.0f, 1f)]
    public float2 m_CloudinessRange;
    public ClimateSystem.WeatherClassification m_Classification;

    public IReadOnlyCollection<OverrideablePropertiesComponent> overrideableProperties { get; private set; }

    protected override void OnEnable()
    {
      base.OnEnable();
      List<OverrideablePropertiesComponent> list = new List<OverrideablePropertiesComponent>();
      this.GetComponents<OverrideablePropertiesComponent>(list);
      this.overrideableProperties = (IReadOnlyCollection<OverrideablePropertiesComponent>) list.AsReadOnly();
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<WeatherData>());
    }

    public enum RandomizationLayer
    {
      None,
      Cloudiness,
      Aurora,
      Season,
    }
  }
}
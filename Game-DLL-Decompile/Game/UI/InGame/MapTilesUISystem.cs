// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.MapTilesUISystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Colossal.UI.Binding;
using Game.Areas;
using Game.City;
using Game.Simulation;
using System;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.InGame
{
  public class MapTilesUISystem : UISystemBase
  {
    private const string kGroup = "mapTiles";
    private MapTilePurchaseSystem m_MapTileSystem;
    private CityConfigurationSystem m_CityConfigurationSystem;
    private GetterValueBinding<bool> m_MapTilesPanelVisibleBinding;
    private GetterValueBinding<bool> m_MapTilesViewActiveBinding;
    private RawValueBinding m_ResourcesBinding;
    private ValueBinding<MapTilesUISystem.UIMapTileResource> m_BuildableLandBinding;
    private ValueBinding<MapTilesUISystem.UIMapTileResource> m_WaterBinding;
    private GetterValueBinding<int> m_PurchasePriceBinding;
    private GetterValueBinding<int> m_PurchaseUpkeepBinding;
    private GetterValueBinding<int> m_PurchaseFlagsBinding;
    private GetterValueBinding<int> m_ExpansionPermitsBinding;
    private GetterValueBinding<int> m_ExpansionPermitCostBinding;
    private int m_LastSelected;

    public static bool mapTileViewActive { get; private set; }

    [Preserve]
    protected override void OnCreate()
    {
      base.OnCreate();
      this.m_MapTileSystem = this.World.GetOrCreateSystemManaged<MapTilePurchaseSystem>();
      this.m_CityConfigurationSystem = this.World.GetOrCreateSystemManaged<CityConfigurationSystem>();
      this.AddBinding((IBinding) (this.m_MapTilesPanelVisibleBinding = new GetterValueBinding<bool>("mapTiles", "mapTilePanelVisible", (Func<bool>) (() => MapTilesUISystem.mapTileViewActive && !this.m_CityConfigurationSystem.unlockMapTiles))));
      this.AddBinding((IBinding) (this.m_MapTilesViewActiveBinding = new GetterValueBinding<bool>("mapTiles", "mapTileViewActive", (Func<bool>) (() => MapTilesUISystem.mapTileViewActive))));
      this.AddBinding((IBinding) (this.m_BuildableLandBinding = new ValueBinding<MapTilesUISystem.UIMapTileResource>("mapTiles", "buildableLand", this.GetResource(MapFeature.BuildableLand), (IWriter<MapTilesUISystem.UIMapTileResource>) new ValueWriter<MapTilesUISystem.UIMapTileResource>())));
      this.AddBinding((IBinding) (this.m_WaterBinding = new ValueBinding<MapTilesUISystem.UIMapTileResource>("mapTiles", "water", this.GetResource(MapFeature.GroundWater), (IWriter<MapTilesUISystem.UIMapTileResource>) new ValueWriter<MapTilesUISystem.UIMapTileResource>())));
      this.AddBinding((IBinding) (this.m_PurchasePriceBinding = new GetterValueBinding<int>("mapTiles", "purchasePrice", (Func<int>) (() => this.m_MapTileSystem.cost))));
      this.AddBinding((IBinding) (this.m_PurchaseUpkeepBinding = new GetterValueBinding<int>("mapTiles", "purchaseUpkeep", (Func<int>) (() => this.m_MapTileSystem.upkeep))));
      this.AddBinding((IBinding) (this.m_PurchaseFlagsBinding = new GetterValueBinding<int>("mapTiles", "purchaseFlags", (Func<int>) (() => (int) this.m_MapTileSystem.status))));
      // ISSUE: reference to a compiler-generated method
      this.AddBinding((IBinding) (this.m_ExpansionPermitsBinding = new GetterValueBinding<int>("mapTiles", "expansionPermits", (Func<int>) (() => this.m_MapTileSystem.GetAvailableTiles()))));
      // ISSUE: reference to a compiler-generated method
      this.AddBinding((IBinding) (this.m_ExpansionPermitCostBinding = new GetterValueBinding<int>("mapTiles", "expansionPermitCost", (Func<int>) (() => this.m_MapTileSystem.GetSelectedTileCount()))));
      this.AddBinding((IBinding) (this.m_ResourcesBinding = new RawValueBinding("mapTiles", "resources", new Action<IJsonWriter>(this.BindResources))));
      this.AddBinding((IBinding) new TriggerBinding<bool>("mapTiles", "setMapTileViewActive", new Action<bool>(this.SetMapTileViewActive)));
      this.AddBinding((IBinding) new TriggerBinding("mapTiles", "purchaseMapTiles", new Action(this.PurchaseMapTiles)));
    }

    private void BindResources(IJsonWriter binder)
    {
      binder.ArrayBegin(4U);
      binder.Write<MapTilesUISystem.UIMapTileResource>(this.GetResource(MapFeature.FertileLand));
      binder.Write<MapTilesUISystem.UIMapTileResource>(this.GetResource(MapFeature.Forest));
      binder.Write<MapTilesUISystem.UIMapTileResource>(this.GetResource(MapFeature.Oil));
      binder.Write<MapTilesUISystem.UIMapTileResource>(this.GetResource(MapFeature.Ore));
      binder.ArrayEnd();
    }

    private MapTilesUISystem.UIMapTileResource GetResource(MapFeature feature)
    {
      switch (feature)
      {
        case MapFeature.BuildableLand:
          // ISSUE: reference to a compiler-generated method
          return new MapTilesUISystem.UIMapTileResource("BuildableLand", "Media/Game/Icons/MapTile.svg", this.m_MapTileSystem.GetFeatureAmount(MapFeature.BuildableLand), "area");
        case MapFeature.FertileLand:
          // ISSUE: reference to a compiler-generated method
          return new MapTilesUISystem.UIMapTileResource("FertileLand", "Media/Game/Icons/Fertility.svg", this.m_MapTileSystem.GetFeatureAmount(MapFeature.FertileLand), "area");
        case MapFeature.Forest:
          // ISSUE: reference to a compiler-generated method
          return new MapTilesUISystem.UIMapTileResource("Forest", "Media/Game/Icons/Forest.svg", this.m_MapTileSystem.GetFeatureAmount(MapFeature.Forest), "weight");
        case MapFeature.Oil:
          // ISSUE: reference to a compiler-generated method
          return new MapTilesUISystem.UIMapTileResource("Oil", "Media/Game/Icons/Oil.svg", this.m_MapTileSystem.GetFeatureAmount(MapFeature.Oil), "weight");
        case MapFeature.Ore:
          // ISSUE: reference to a compiler-generated method
          return new MapTilesUISystem.UIMapTileResource("Ore", "Media/Game/Icons/Coal.svg", this.m_MapTileSystem.GetFeatureAmount(MapFeature.Ore), "weight");
        default:
          // ISSUE: reference to a compiler-generated method
          return new MapTilesUISystem.UIMapTileResource("Water", "Media/Game/Icons/Water.svg", this.m_MapTileSystem.GetFeatureAmount(MapFeature.GroundWater), "volume");
      }
    }

    [Preserve]
    protected override void OnUpdate()
    {
      this.m_MapTilesViewActiveBinding.Update();
      this.m_MapTilesPanelVisibleBinding.Update();
      this.m_ExpansionPermitsBinding.Update();
      if (!MapTilesUISystem.mapTileViewActive)
        return;
      this.m_MapTileSystem.Update();
      if (!this.m_MapTileSystem.selecting)
        return;
      this.m_PurchaseFlagsBinding.Update();
      // ISSUE: reference to a compiler-generated method
      int selectedTileCount = this.m_MapTileSystem.GetSelectedTileCount();
      if (this.m_LastSelected == selectedTileCount)
        return;
      this.m_LastSelected = selectedTileCount;
      this.m_PurchasePriceBinding.Update();
      this.m_PurchaseUpkeepBinding.Update();
      this.m_ExpansionPermitCostBinding.Update();
      this.m_ResourcesBinding.Update();
      this.m_BuildableLandBinding.Update(this.GetResource(MapFeature.BuildableLand));
      this.m_WaterBinding.Update(this.GetResource(MapFeature.GroundWater));
    }

    protected override void OnGamePreload(Purpose purpose, GameMode mode)
    {
      base.OnGamePreload(purpose, mode);
      MapTilesUISystem.mapTileViewActive = false;
    }

    private void SetMapTileViewActive(bool enabled)
    {
      MapTilesUISystem.mapTileViewActive = enabled;
      this.m_MapTileSystem.selecting = enabled && !this.m_CityConfigurationSystem.unlockMapTiles;
    }

    private void PurchaseMapTiles() => this.m_MapTileSystem.PurchaseSelection();

    [Preserve]
    public MapTilesUISystem()
    {
    }

    public readonly struct UIMapTileResource : IJsonWritable
    {
      public string id { get; }

      public string icon { get; }

      public float value { get; }

      public string unit { get; }

      public UIMapTileResource(string id, string icon, float value, string unit)
      {
        this.id = id;
        this.icon = icon;
        this.value = value;
        this.unit = unit;
      }

      public void Write(IJsonWriter writer)
      {
        writer.TypeBegin("mapTiles.UIMapTileResource");
        writer.PropertyName("id");
        writer.Write(this.id);
        writer.PropertyName("icon");
        writer.Write(this.icon);
        writer.PropertyName("value");
        writer.Write(this.value);
        writer.PropertyName("unit");
        writer.Write(this.unit);
        writer.TypeEnd();
      }
    }
  }
}

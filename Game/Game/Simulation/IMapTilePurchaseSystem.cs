// Decompiled with JetBrains decompiler
// Type: Game.Simulation.IMapTilePurchaseSystem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Areas;

#nullable disable
namespace Game.Simulation
{
  public interface IMapTilePurchaseSystem
  {
    bool selecting { get; set; }

    int cost { get; }

    float GetFeatureAmount(MapFeature feature);

    TilePurchaseErrorFlags status { get; }

    void PurchaseSelection();

    void Update();
  }
}

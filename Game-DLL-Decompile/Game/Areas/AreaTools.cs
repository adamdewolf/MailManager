// Decompiled with JetBrains decompiler
// Type: Game.Areas.AreaTools
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Areas
{
  public class AreaTools
  {
    public static string GetMapFeatureIconName(MapFeature feature)
    {
      switch (feature)
      {
        case MapFeature.None:
          return "None";
        case MapFeature.Area:
          return "Area";
        case MapFeature.BuildableLand:
          return "Building";
        case MapFeature.FertileLand:
          return "Fertility";
        case MapFeature.Forest:
          return "Forest";
        case MapFeature.Oil:
          return "Oil";
        case MapFeature.Ore:
          return "Coal";
        case MapFeature.SurfaceWater:
          return "Water";
        case MapFeature.GroundWater:
          return "Water";
        default:
          return "None";
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Rendering.ViewerDistances
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.Rendering
{
  public struct ViewerDistances
  {
    public float focus { get; set; }

    public float closestSurface { get; set; }

    public float farthestSurface { get; set; }

    public float averageSurface { get; set; }

    public float ground { get; set; }

    public float maxDistanceToSeaLevel { get; set; }
  }
}

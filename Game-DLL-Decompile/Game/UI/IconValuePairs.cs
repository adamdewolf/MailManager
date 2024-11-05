// Decompiled with JetBrains decompiler
// Type: Game.UI.IconValuePairs
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

#nullable disable
namespace Game.UI
{
  public class IconValuePairs
  {
    private IconValuePairs.IconValuePair[] iconValuePairArray;

    public IconValuePairs(IconValuePairs.IconValuePair[] iconValuePairArray)
    {
      this.iconValuePairArray = iconValuePairArray;
    }

    public string GetIconFromValue(float value)
    {
      if (this.iconValuePairArray == null || this.iconValuePairArray.Length == 0)
        return string.Empty;
      foreach (IconValuePairs.IconValuePair iconValuePair in this.iconValuePairArray)
      {
        if ((double) value <= (double) iconValuePair.stop)
          return iconValuePair.icon;
      }
      IconValuePairs.IconValuePair[] iconValuePairArray = this.iconValuePairArray;
      return iconValuePairArray[iconValuePairArray.Length - 1].icon;
    }

    public struct IconValuePair
    {
      public string icon { get; }

      public float stop { get; }

      public IconValuePair(string icon, float stop)
      {
        this.icon = icon;
        this.stop = stop;
      }
    }
  }
}

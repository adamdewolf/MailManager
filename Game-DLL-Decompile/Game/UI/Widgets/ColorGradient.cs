// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.ColorGradient
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  public struct ColorGradient : IJsonWritable
  {
    public GradientStop[] stops;

    public ColorGradient(GradientStop[] stops) => this.stops = stops;

    public static explicit operator ColorGradient(Gradient gradient)
    {
      List<GradientStop> gradientStopList = new List<GradientStop>();
      foreach (GradientColorKey colorKey in gradient.colorKeys)
        gradientStopList.Add(new GradientStop(colorKey.time, (Color32) colorKey.color));
      return new ColorGradient(gradientStopList.ToArray());
    }

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      writer.PropertyName("stops");
      int length = this.stops != null ? this.stops.Length : 0;
      writer.ArrayBegin(length);
      for (int index = 0; index < length; ++index)
        writer.Write<GradientStop>(this.stops[index]);
      writer.ArrayEnd();
      writer.TypeEnd();
    }
  }
}

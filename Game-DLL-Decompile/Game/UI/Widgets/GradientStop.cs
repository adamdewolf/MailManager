// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.GradientStop
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  public struct GradientStop : IJsonWritable
  {
    public float offset;
    public Color32 color;

    public GradientStop(float offset, Color32 color)
    {
      this.offset = offset;
      this.color = color;
    }

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      writer.PropertyName("offset");
      writer.Write(this.offset);
      writer.PropertyName("color");
      writer.Write(this.color);
      writer.TypeEnd();
    }
  }
}

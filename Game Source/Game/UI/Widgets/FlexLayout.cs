﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.FlexLayout
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public struct FlexLayout : IJsonWritable
  {
    public static FlexLayout Default => new FlexLayout(0.0f, 1f, -1);

    public static FlexLayout Fill => new FlexLayout(1f, 0.0f, 0);

    public float grow { get; set; }

    public float shrink { get; set; }

    public int basis { get; set; }

    public FlexLayout(float grow, float shrink, int basis)
    {
      this.grow = grow;
      this.shrink = shrink;
      this.basis = basis;
    }

    public void Write(IJsonWriter writer)
    {
      writer.TypeBegin(this.GetType().FullName);
      writer.PropertyName("grow");
      writer.Write(this.grow);
      writer.PropertyName("shrink");
      writer.Write(this.shrink);
      writer.PropertyName("basis");
      writer.Write(this.basis);
      writer.TypeEnd();
    }
  }
}
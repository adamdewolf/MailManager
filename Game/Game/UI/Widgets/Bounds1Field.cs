﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Bounds1Field
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public abstract class Bounds1Field : Field<Bounds1>
  {
    public float min { get; set; } = float.MinValue;

    public float max { get; set; } = float.MaxValue;

    public int fractionDigits { get; set; } = 3;

    public float step { get; set; } = 0.1f;

    public bool allowMinGreaterMax { get; set; }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("min");
      writer.Write(this.min);
      writer.PropertyName("max");
      writer.Write(this.max);
      writer.PropertyName("fractionDigits");
      writer.Write(this.fractionDigits);
      writer.PropertyName("step");
      writer.Write(this.step);
      writer.PropertyName("allowMinGreaterMax");
      writer.Write(this.allowMinGreaterMax);
    }
  }
}
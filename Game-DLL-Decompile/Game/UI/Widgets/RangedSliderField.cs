// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.RangedSliderField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class RangedSliderField : FloatSliderField<float>, IIconProvider
  {
    protected override float defaultMin => float.MinValue;

    protected override float defaultMax => float.MaxValue;

    public override float ToFieldType(double value) => (float) value;

    public float[] ranges { get; set; }

    public Func<string> iconSrc { get; set; }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("ranges");
      int length = this.ranges != null ? this.ranges.Length : 0;
      writer.ArrayBegin(length);
      for (int index = 0; index < length; ++index)
        writer.Write(this.ranges[index]);
      writer.ArrayEnd();
      writer.PropertyName("iconSrc");
      writer.Write(this.iconSrc());
    }
  }
}

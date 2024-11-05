// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.FloatField`1
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public abstract class FloatField<T> : MinMaxField<T>
  {
    public int fractionDigits { get; set; } = 3;

    public double step { get; set; } = 0.1;

    public double stepMultiplier { get; set; } = 10.0;

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("fractionDigits");
      writer.Write(this.fractionDigits);
      writer.PropertyName("step");
      writer.Write(this.step);
      writer.PropertyName("stepMultiplier");
      writer.Write(this.stepMultiplier);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.TimeOfDayWeightsChart
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Reflection;
using Game.UI.Widgets;
using Unity.Mathematics;

#nullable disable
namespace Game.UI.Editor
{
  public class TimeOfDayWeightsChart : Widget
  {
    private float4 m_Value;

    public float min { get; set; }

    public float max { get; set; }

    public ITypedValueAccessor<float4> accessor { get; set; }

    protected override WidgetChanges Update()
    {
      WidgetChanges widgetChanges = base.Update();
      float4 objA = math.unlerp((float4) this.min, (float4) this.max, this.accessor.GetTypedValue());
      if (!object.Equals((object) objA, (object) this.m_Value))
      {
        widgetChanges |= WidgetChanges.Properties;
        this.m_Value = objA;
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("value");
      writer.Write(this.m_Value);
    }
  }
}

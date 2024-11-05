// Decompiled with JetBrains decompiler
// Type: Game.UI.Tooltip.ZoningEvaluationTooltip
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Simulation;
using Game.UI.Widgets;
using System;

#nullable disable
namespace Game.UI.Tooltip
{
  public class ZoningEvaluationTooltip : Widget
  {
    private ZoneEvaluationUtils.ZoningEvaluationFactor m_Factor;
    private float m_Score;

    public ZoneEvaluationUtils.ZoningEvaluationFactor factor
    {
      get => this.m_Factor;
      set
      {
        if (value == this.m_Factor)
          return;
        this.m_Factor = value;
        this.SetPropertiesChanged();
      }
    }

    public float score
    {
      get => this.m_Score;
      set
      {
        if ((double) value == (double) this.m_Score)
          return;
        this.m_Score = value;
        this.SetPropertiesChanged();
      }
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("factor");
      writer.Write(Enum.GetName(typeof (ZoneEvaluationUtils.ZoningEvaluationFactor), (object) this.factor));
      writer.PropertyName("score");
      writer.Write(this.score);
    }
  }
}

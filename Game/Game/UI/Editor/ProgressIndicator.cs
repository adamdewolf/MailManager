// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.ProgressIndicator
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Widgets;
using System;
using UnityEngine;

#nullable disable
namespace Game.UI.Editor
{
  public class ProgressIndicator : NamedWidgetWithTooltip
  {
    private float m_Progress = 1f;
    private ProgressIndicator.State m_State;

    public Func<float> progress { get; set; }

    public Func<ProgressIndicator.State> state { get; set; }

    protected override WidgetChanges Update()
    {
      WidgetChanges widgetChanges = base.Update();
      if (this.state != null)
      {
        ProgressIndicator.State state = this.state();
        if (state != this.m_State)
        {
          this.m_State = state;
          widgetChanges |= WidgetChanges.Properties;
        }
      }
      if (this.progress != null)
      {
        float a = this.progress();
        if (!Mathf.Approximately(a, this.m_Progress))
        {
          this.m_Progress = a;
          widgetChanges |= WidgetChanges.Properties;
        }
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("state");
      writer.Write((int) this.m_State);
      writer.PropertyName("progress");
      writer.Write(this.m_Progress);
      writer.PropertyName("indeterminate");
      writer.Write(this.progress == null);
    }

    public enum State
    {
      Loading,
      Success,
      Failure,
    }
  }
}

﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.Compass
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.UI.Widgets;
using System;

#nullable disable
namespace Game.UI.Editor
{
  public class Compass : Widget
  {
    private float m_Angle;
    public Func<float> angle;

    protected override WidgetChanges Update()
    {
      WidgetChanges widgetChanges = base.Update();
      Func<float> angle = this.angle;
      float num = angle != null ? angle() : 0.0f;
      if ((double) num != (double) this.m_Angle)
      {
        widgetChanges |= WidgetChanges.Properties;
        this.m_Angle = num;
      }
      return widgetChanges;
    }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("angle");
      writer.Write(this.m_Angle);
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.TimeFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Game.Reflection;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class TimeFieldBuilders : IFieldBuilderFactory
  {
    public FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      if (memberType == typeof (float))
      {
        if (WidgetAttributeUtils.IsTimeField(attributes))
        {
          float min = 0.0f;
          float max = 1f;
          WidgetAttributeUtils.GetNumberRange(attributes, ref min, ref max);
          return (FieldBuilder) (accessor =>
          {
            return (IWidget) new TimeSliderField()
            {
              min = min,
              max = max,
              accessor = (ITypedValueAccessor<float>) new CastAccessor<float>(accessor)
            };
          });
        }
      }
      else if (memberType == typeof (Bounds1) && WidgetAttributeUtils.IsTimeField(attributes))
      {
        float min = 0.0f;
        float max = 1f;
        WidgetAttributeUtils.GetNumberRange(attributes, ref min, ref max);
        bool allowMinGreaterMax = WidgetAttributeUtils.AllowsMinGreaterMax(attributes);
        return (FieldBuilder) (accessor =>
        {
          return (IWidget) new TimeBoundsSliderField()
          {
            min = min,
            max = max,
            allowMinGreaterMax = allowMinGreaterMax,
            accessor = (ITypedValueAccessor<Bounds1>) new CastAccessor<Bounds1>(accessor)
          };
        });
      }
      return (FieldBuilder) null;
    }
  }
}
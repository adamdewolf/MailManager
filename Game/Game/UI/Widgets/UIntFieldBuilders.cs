﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.UIntFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Reflection;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class UIntFieldBuilders : IFieldBuilderFactory
  {
    private static readonly uint kGlobalValueRange = 10000000;

    public FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      if (!(memberType == typeof (uint)))
        return (FieldBuilder) null;
      uint min = 0;
      uint max = !EditorGenerator.sBypassValueLimits ? UIntFieldBuilders.kGlobalValueRange : uint.MaxValue;
      uint step = WidgetAttributeUtils.GetNumberStep(attributes, 1U);
      if (!WidgetAttributeUtils.GetNumberRange(attributes, ref min, ref max) || WidgetAttributeUtils.RequiresInputField(attributes))
        return (FieldBuilder) (accessor =>
        {
          return (IWidget) new UIntInputField()
          {
            min = min,
            max = max,
            step = step,
            accessor = (ITypedValueAccessor<uint>) new CastAccessor<uint>(accessor)
          };
        });
      string unit = WidgetAttributeUtils.GetNumberUnit(attributes);
      return (FieldBuilder) (accessor =>
      {
        return (IWidget) new UIntSliderField()
        {
          min = min,
          max = max,
          step = step,
          unit = unit,
          accessor = (ITypedValueAccessor<uint>) new CastAccessor<uint>(accessor)
        };
      });
    }
  }
}
﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.WidgetAttributeUtils
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  public static class WidgetAttributeUtils
  {
    public static bool RequiresInputField(object[] attributes)
    {
      return attributes.OfType<InputFieldAttribute>().Any<InputFieldAttribute>();
    }

    public static bool IsTimeField(object[] attributes)
    {
      return attributes.OfType<TimeFieldAttribute>().Any<TimeFieldAttribute>();
    }

    public static bool AllowsMinGreaterMax(object[] attributes)
    {
      return attributes.OfType<AllowMinGreaterMaxAttribute>().Any<AllowMinGreaterMaxAttribute>();
    }

    public static void GetColorUsage(object[] attributes, ref bool hdr, ref bool showAlpha)
    {
      ColorUsageAttribute colorUsageAttribute = attributes.OfType<ColorUsageAttribute>().FirstOrDefault<ColorUsageAttribute>();
      if (colorUsageAttribute == null)
        return;
      hdr = colorUsageAttribute.hdr;
      showAlpha = colorUsageAttribute.showAlpha;
    }

    public static bool GetNumberRange(object[] attributes, ref int min, ref int max)
    {
      RangeAttribute rangeAttribute = attributes.OfType<RangeAttribute>().FirstOrDefault<RangeAttribute>();
      if (rangeAttribute == null)
        return false;
      min = (int) rangeAttribute.min;
      max = (int) rangeAttribute.max;
      return true;
    }

    public static bool GetNumberRange(object[] attributes, ref uint min, ref uint max)
    {
      RangeAttribute rangeAttribute = attributes.OfType<RangeAttribute>().FirstOrDefault<RangeAttribute>();
      if (rangeAttribute == null)
        return false;
      min = (uint) rangeAttribute.min;
      max = (uint) rangeAttribute.max;
      return true;
    }

    public static bool GetNumberRange(object[] attributes, ref float min, ref float max)
    {
      RangeAttribute rangeAttribute = attributes.OfType<RangeAttribute>().FirstOrDefault<RangeAttribute>();
      if (rangeAttribute == null)
        return false;
      min = rangeAttribute.min;
      max = rangeAttribute.max;
      return true;
    }

    public static bool GetNumberRange(object[] attributes, ref double min, ref double max)
    {
      RangeAttribute rangeAttribute = attributes.OfType<RangeAttribute>().FirstOrDefault<RangeAttribute>();
      if (rangeAttribute == null)
        return false;
      min = (double) rangeAttribute.min;
      max = (double) rangeAttribute.max;
      return true;
    }

    public static int GetNumberStep(object[] attributes, int defaultStep = 1)
    {
      NumberStepAttribute numberStepAttribute = attributes.OfType<NumberStepAttribute>().FirstOrDefault<NumberStepAttribute>();
      if (numberStepAttribute != null)
      {
        int step = (int) numberStepAttribute.Step;
        if (step > 0)
          return step;
      }
      return defaultStep;
    }

    public static uint GetNumberStep(object[] attributes, uint defaultStep = 1)
    {
      NumberStepAttribute numberStepAttribute = attributes.OfType<NumberStepAttribute>().FirstOrDefault<NumberStepAttribute>();
      if (numberStepAttribute != null)
      {
        uint step = (uint) numberStepAttribute.Step;
        if (step > 0U)
          return step;
      }
      return defaultStep;
    }

    public static float GetNumberStep(object[] attributes, float defaultStep = 0.01f)
    {
      NumberStepAttribute numberStepAttribute = attributes.OfType<NumberStepAttribute>().FirstOrDefault<NumberStepAttribute>();
      return numberStepAttribute == null || (double) numberStepAttribute.Step <= 0.0 ? defaultStep : numberStepAttribute.Step;
    }

    public static double GetNumberStep(object[] attributes, double defaultStep = 0.01)
    {
      NumberStepAttribute numberStepAttribute = attributes.OfType<NumberStepAttribute>().FirstOrDefault<NumberStepAttribute>();
      return numberStepAttribute == null || (double) numberStepAttribute.Step <= 0.0 ? defaultStep : (double) numberStepAttribute.Step;
    }

    [CanBeNull]
    public static string GetNumberUnit(object[] attributes)
    {
      return attributes.OfType<NumberUnitAttribute>().FirstOrDefault<NumberUnitAttribute>()?.Unit;
    }

    public static System.Type GetCustomFieldFactory(object[] attributes)
    {
      return attributes.OfType<CustomFieldAttribute>().FirstOrDefault<CustomFieldAttribute>()?.Factory;
    }
  }
}
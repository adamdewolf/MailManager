﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.CustomFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  public class CustomFieldBuilders : IFieldBuilderFactory
  {
    public static readonly Dictionary<System.Type, IFieldBuilderFactory> kFactoryCache = new Dictionary<System.Type, IFieldBuilderFactory>();

    public FieldBuilder TryCreate(System.Type memberType, object[] attributes)
    {
      System.Type customFieldFactory = WidgetAttributeUtils.GetCustomFieldFactory(attributes);
      if (customFieldFactory != (System.Type) null)
      {
        IFieldBuilderFactory fieldBuilderFactory;
        if (!CustomFieldBuilders.kFactoryCache.TryGetValue(customFieldFactory, out fieldBuilderFactory))
        {
          if (typeof (IFieldBuilderFactory).IsAssignableFrom(customFieldFactory))
          {
            try
            {
              fieldBuilderFactory = (IFieldBuilderFactory) Activator.CreateInstance(customFieldFactory);
            }
            catch (Exception ex)
            {
              Debug.LogException(ex);
              fieldBuilderFactory = (IFieldBuilderFactory) null;
            }
            CustomFieldBuilders.kFactoryCache[customFieldFactory] = fieldBuilderFactory;
          }
          else
            Debug.LogError((object) string.Format("{0} is not assignable to IFieldBuilderFactory", (object) customFieldFactory));
        }
        if (fieldBuilderFactory != null)
          return fieldBuilderFactory.TryCreate(memberType, attributes);
      }
      return (FieldBuilder) null;
    }
  }
}
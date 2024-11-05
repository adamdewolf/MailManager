// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.SettableBindings
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;
using System.Collections.Generic;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  public class SettableBindings : IWidgetBindingFactory
  {
    public IEnumerable<IBinding> CreateBindings(
      string group,
      IReader<IWidget> pathResolver,
      ValueChangedCallback onValueChanged)
    {
      yield return (IBinding) new RawTriggerBinding(group, "setValue", (Action<IJsonReader>) (reader =>
      {
        IWidget widget;
        pathResolver.Read(reader, out widget);
        if (widget is ISettable settable2)
        {
          settable2.SetValue(reader);
          if (!settable2.shouldTriggerValueChangedEvent)
            return;
          onValueChanged(widget);
        }
        else
        {
          reader.SkipValue();
          Debug.LogError(widget != null ? (object) "Widget does not implement ISettable" : (object) "Invalid widget path");
        }
      }));
    }
  }
}

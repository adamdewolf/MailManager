﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.ExpandableBindings
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
  public class ExpandableBindings : IWidgetBindingFactory
  {
    public IEnumerable<IBinding> CreateBindings(
      string group,
      IReader<IWidget> pathResolver,
      ValueChangedCallback onValueChanged)
    {
      yield return (IBinding) new TriggerBinding<IWidget, bool>(group, "setExpanded", (Action<IWidget, bool>) ((widget, expanded) =>
      {
        if (widget is IExpandable expandable2)
          expandable2.expanded = expanded;
        else
          Debug.LogError(widget != null ? (object) "Widget does not implement IExpandable" : (object) "Invalid widget path");
      }), pathResolver);
    }
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.CustomFieldAttribute
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using System;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
  public class CustomFieldAttribute : PropertyAttribute
  {
    [NotNull]
    public System.Type Factory { get; set; }

    public CustomFieldAttribute([NotNull] System.Type factory)
    {
      this.Factory = factory ?? throw new ArgumentNullException(nameof (factory));
    }
  }
}

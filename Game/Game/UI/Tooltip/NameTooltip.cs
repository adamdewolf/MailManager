﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Tooltip.NameTooltip
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.UI.Widgets;
using Unity.Entities;

#nullable disable
namespace Game.UI.Tooltip
{
  public class NameTooltip : Widget
  {
    [CanBeNull]
    private string m_Icon;
    public Entity m_Entity;

    [CanBeNull]
    public string icon
    {
      get => this.m_Icon;
      set
      {
        if (!(value != this.m_Icon))
          return;
        this.m_Icon = value;
        this.SetPropertiesChanged();
      }
    }

    public Entity entity
    {
      get => this.m_Entity;
      set
      {
        if (!(value != this.m_Entity))
          return;
        this.m_Entity = value;
        this.SetPropertiesChanged();
      }
    }

    public NameSystem nameBinder { get; set; }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("icon");
      writer.Write(this.icon);
      writer.PropertyName("name");
      // ISSUE: reference to a compiler-generated method
      this.nameBinder.BindName(writer, this.entity);
    }
  }
}
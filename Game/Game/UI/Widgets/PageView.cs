﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.PageView
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public class PageView : LayoutContainer
  {
    private int m_CurrentPage;

    public int currentPage
    {
      get => this.m_CurrentPage;
      set
      {
        if (value == this.m_CurrentPage)
          return;
        this.m_CurrentPage = value;
        this.SetPropertiesChanged();
      }
    }

    public PageView() => this.flex = FlexLayout.Fill;

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("currentPage");
      writer.Write(this.currentPage);
    }
  }
}
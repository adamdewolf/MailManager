// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.PageLayout
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;
using Game.UI.Localization;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  internal class PageLayout : LayoutContainer, IInvokable, IWidget, IJsonWritable
  {
    public LocalizedString title { get; set; }

    [CanBeNull]
    public Action backAction { get; set; }

    public PageLayout() => this.flex = FlexLayout.Fill;

    public void Invoke() => this.backAction();

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("title");
      writer.Write<LocalizedString>(this.title);
      writer.PropertyName("hasBackAction");
      writer.Write(this.backAction != null);
    }
  }
}

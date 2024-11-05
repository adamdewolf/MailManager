// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.StringFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class StringFieldBuilders : IFieldBuilderFactory
  {
    public FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      return memberType == typeof (string) ? WidgetReflectionUtils.CreateFieldBuilder<StringInputField, string>() : (FieldBuilder) null;
    }
  }
}

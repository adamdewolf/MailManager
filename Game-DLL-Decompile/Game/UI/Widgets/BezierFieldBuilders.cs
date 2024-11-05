// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.BezierFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class BezierFieldBuilders : IFieldBuilderFactory
  {
    public FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      return memberType == typeof (Bezier4x3) ? WidgetReflectionUtils.CreateFieldBuilder<Bezier4x3Field, Bezier4x3>() : (FieldBuilder) null;
    }
  }
}

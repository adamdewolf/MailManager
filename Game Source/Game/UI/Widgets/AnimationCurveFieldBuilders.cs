// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.AnimationCurveFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Reflection;
using UnityEngine;

#nullable disable
namespace Game.UI.Widgets
{
  public class AnimationCurveFieldBuilders : IFieldBuilderFactory
  {
    public FieldBuilder TryCreate(System.Type memberType, object[] attributes)
    {
      return memberType == typeof (AnimationCurve) ? (FieldBuilder) (accessor =>
      {
        if (accessor.GetValue() == null)
          accessor.SetValue((object) new AnimationCurve());
        return (IWidget) new AnimationCurveField()
        {
          accessor = (ITypedValueAccessor<AnimationCurve>) new CastAccessor<AnimationCurve>(accessor)
        };
      }) : (FieldBuilder) null;
    }
  }
}

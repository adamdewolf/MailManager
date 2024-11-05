// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.PopupValueFieldBuilders
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Prefabs;
using Game.Reflection;
using Game.UI.Editor;
using System;

#nullable disable
namespace Game.UI.Widgets
{
  public class PopupValueFieldBuilders : IFieldBuilderFactory
  {
    public FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      return typeof (PrefabBase).IsAssignableFrom(memberType) ? (FieldBuilder) (accessor =>
      {
        CastAccessor<PrefabBase> castAccessor = new CastAccessor<PrefabBase>(accessor);
        return (IWidget) new PopupValueField<PrefabBase>()
        {
          accessor = (ITypedValueAccessor<PrefabBase>) castAccessor,
          popup = (IValueFieldPopup<PrefabBase>) new PrefabPickerPopup(memberType)
        };
      }) : (FieldBuilder) null;
    }
  }
}

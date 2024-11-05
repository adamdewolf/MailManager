// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.UIIconField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.IO.AssetDatabase;
using Colossal.UI;
using Game.Reflection;
using Game.UI.Localization;
using Game.UI.Widgets;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.UI.Editor
{
  public class UIIconField : IFieldBuilderFactory
  {
    public FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      return (FieldBuilder) (accessor =>
      {
        CastAccessor<string> castAccessor = new CastAccessor<string>(accessor);
        StringInputField stringInputField = new StringInputField()
        {
          displayName = (LocalizedString) "URI",
          accessor = (ITypedValueAccessor<string>) castAccessor
        };
        IconButton iconButton = new IconButton();
        if (!(accessor.GetValue() is string empty2))
          empty2 = string.Empty;
        iconButton.icon = empty2;
        IconButton iconPicker = iconButton;
        // ISSUE: reference to a compiler-generated method
        iconPicker.action = (Action) (() => World.DefaultGameObjectInjectionWorld.GetOrCreateSystemManaged<InspectorPanelSystem>().ShowThumbnailPicker((LoadAssetPanel.LoadCallback) (hash =>
        {
          string str = string.Empty;
          ImageAsset assetData;
          if (Colossal.IO.AssetDatabase.AssetDatabase.global.TryGetAsset<ImageAsset>(hash, out assetData))
            str = assetData.ToGlobalUri();
          castAccessor.SetValue((object) str);
          iconPicker.icon = str;
        })));
        return (IWidget) new Group()
        {
          displayName = (LocalizedString) "Icon",
          children = (IList<IWidget>) new IWidget[2]
          {
            (IWidget) stringInputField,
            (IWidget) iconPicker
          }
        };
      });
    }
  }
}

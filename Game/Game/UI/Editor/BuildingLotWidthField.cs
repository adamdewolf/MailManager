// Decompiled with JetBrains decompiler
// Type: Game.UI.Editor.BuildingLotWidthField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.UI.Widgets;
using System;

#nullable disable
namespace Game.UI.Editor
{
  public class BuildingLotWidthField : BuildingLotFieldBase
  {
    public override FieldBuilder TryCreate(Type memberType, object[] attributes)
    {
      return this.TryCreate(memberType, attributes, true);
    }
  }
}

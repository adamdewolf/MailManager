﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.IntSliderField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using Colossal.UI.Binding;

#nullable disable
namespace Game.UI.Widgets
{
  public class IntSliderField : IntField<int>
  {
    [CanBeNull]
    public string unit { get; set; }

    public bool signed { get; set; }

    public bool separateThousands { get; set; }

    public bool scaleDragVolume { get; set; }

    public bool updateOnDragEnd { get; set; }

    protected override void WriteProperties(IJsonWriter writer)
    {
      base.WriteProperties(writer);
      writer.PropertyName("unit");
      writer.Write(this.unit);
      writer.PropertyName("signed");
      writer.Write(this.signed);
      writer.PropertyName("separateThousands");
      writer.Write(this.separateThousands);
      writer.PropertyName("scaleDragVolume");
      writer.Write(this.scaleDragVolume);
      writer.PropertyName("updateOnDragEnd");
      writer.Write(this.updateOnDragEnd);
    }
  }
}
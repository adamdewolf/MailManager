﻿// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Float2InputField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Mathematics;

#nullable disable
namespace Game.UI.Widgets
{
  public class Float2InputField : FloatField<float2>
  {
    protected override float2 defaultMin => new float2(float.MinValue);

    protected override float2 defaultMax => new float2(float.MaxValue);

    public override float2 ToFieldType(double value) => new float2(value);
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Float3InputField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Mathematics;

#nullable disable
namespace Game.UI.Widgets
{
  public class Float3InputField : FloatField<float3>
  {
    protected override float3 defaultMin => new float3(float.MinValue);

    protected override float3 defaultMax => new float3(float.MaxValue);

    public override float3 ToFieldType(double value) => new float3(value);
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.Widgets.Float4InputField
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Mathematics;

#nullable disable
namespace Game.UI.Widgets
{
  public class Float4InputField : FloatField<float4>
  {
    protected override float4 defaultMin => new float4(float.MinValue);

    protected override float4 defaultMax => new float4(float.MaxValue);

    public override float4 ToFieldType(double value) => new float4(value);
  }
}

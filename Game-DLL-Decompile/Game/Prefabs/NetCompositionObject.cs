// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.NetCompositionObject
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct NetCompositionObject : IBufferElementData
  {
    public Entity m_Prefab;
    public float2 m_Position;
    public float3 m_Offset;
    public quaternion m_Rotation;
    public SubObjectFlags m_Flags;
    public CompositionFlags.General m_SpacingIgnore;
    public float2 m_UseCurveRotation;
    public float2 m_CurveOffsetRange;
    public int m_Probability;
    public float m_Spacing;
    public float m_AvoidSpacing;
    public float m_MinLength;
  }
}

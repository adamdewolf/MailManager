// Decompiled with JetBrains decompiler
// Type: Game.Net.ArrowPosition
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Net
{
  [InternalBufferCapacity(0)]
  public struct ArrowPosition : IBufferElementData, IEmptySerializable
  {
    public float3 m_Position;
    public float3 m_Direction;
    public float m_MaxScale;
    public bool m_IsTrack;
    public bool m_IsUnderground;
  }
}

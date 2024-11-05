// Decompiled with JetBrains decompiler
// Type: Game.Rendering.CullingInfo
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Game.Common;
using Unity.Entities;

#nullable disable
namespace Game.Rendering
{
  public struct CullingInfo : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Bounds3 m_Bounds;
    public float m_Radius;
    public int m_CullingIndex;
    public BoundsMask m_Mask;
    public byte m_MinLod;
    public byte m_PassedCulling;
  }
}

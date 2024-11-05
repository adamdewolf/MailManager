// Decompiled with JetBrains decompiler
// Type: Game.Areas.Geometry
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Areas
{
  public struct Geometry : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Bounds3 m_Bounds;
    public float3 m_CenterPosition;
    public float m_SurfaceArea;
  }
}

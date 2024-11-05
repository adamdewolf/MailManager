// Decompiled with JetBrains decompiler
// Type: Game.Net.EdgeGeometry
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Mathematics;
using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Net
{
  public struct EdgeGeometry : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Segment m_Start;
    public Segment m_End;
    public Bounds3 m_Bounds;
  }
}

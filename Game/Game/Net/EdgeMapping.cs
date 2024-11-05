// Decompiled with JetBrains decompiler
// Type: Game.Net.EdgeMapping
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Net
{
  public struct EdgeMapping : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Entity m_Parent1;
    public Entity m_Parent2;
    public float2 m_CurveDelta1;
    public float2 m_CurveDelta2;
  }
}

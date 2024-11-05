// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.SwayingData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct SwayingData : IComponentData, IQueryTypeParameter
  {
    public float3 m_VelocityFactors;
    public float3 m_SpringFactors;
    public float3 m_DampingFactors;
    public float3 m_MaxPosition;
  }
}

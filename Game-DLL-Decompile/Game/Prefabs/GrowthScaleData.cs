// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.GrowthScaleData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct GrowthScaleData : IComponentData, IQueryTypeParameter
  {
    public float3 m_ChildSize;
    public float3 m_TeenSize;
    public float3 m_AdultSize;
    public float3 m_ElderlySize;
    public float3 m_DeadSize;
  }
}

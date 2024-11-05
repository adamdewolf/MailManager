// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.LightEffectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct LightEffectData : IComponentData, IQueryTypeParameter
  {
    public float m_Range;
    public float m_DistanceFactor;
    public float m_InvDistanceFactor;
    public int m_MinLod;
    public float m_ColorTemperature;
  }
}

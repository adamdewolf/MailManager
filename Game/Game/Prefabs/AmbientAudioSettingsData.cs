// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.AmbientAudioSettingsData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct AmbientAudioSettingsData : IComponentData, IQueryTypeParameter
  {
    public float m_MinHeight;
    public float m_MaxHeight;
    public float m_OverlapRatio;
    public float m_MinDistanceRatio;
  }
}

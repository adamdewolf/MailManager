// Decompiled with JetBrains decompiler
// Type: Game.Effects.EnabledEffectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Effects
{
  public struct EnabledEffectData
  {
    public Entity m_Owner;
    public Entity m_Prefab;
    public int m_EffectIndex;
    public EnabledEffectFlags m_Flags;
    public float3 m_Position;
    public float3 m_Scale;
    public quaternion m_Rotation;
    public float m_Intensity;
    public float m_NextTime;
  }
}

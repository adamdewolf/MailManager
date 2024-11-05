// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.InfoviewLocalEffectData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Buildings;
using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public struct InfoviewLocalEffectData : IComponentData, IQueryTypeParameter
  {
    public LocalModifierType m_Type;
    public float4 m_Color;
  }
}

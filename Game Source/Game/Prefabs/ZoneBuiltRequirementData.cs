// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ZoneBuiltRequirementData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Zones;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ZoneBuiltRequirementData : IComponentData, IQueryTypeParameter
  {
    public Entity m_RequiredTheme;
    public Entity m_RequiredZone;
    public int m_MinimumSquares;
    public int m_MinimumCount;
    public AreaType m_RequiredType;
    public byte m_MinimumLevel;
  }
}

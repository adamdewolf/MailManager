// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.RoadComposition
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct RoadComposition : IComponentData, IQueryTypeParameter
  {
    public Entity m_ZoneBlockPrefab;
    public float m_SpeedLimit;
    public float m_Priority;
    public RoadFlags m_Flags;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.AvailabilityProvider
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Pathfind
{
  public struct AvailabilityProvider
  {
    public Entity m_Provider;
    public float m_Capacity;
    public float m_Cost;

    public AvailabilityProvider(Entity provider, float capacity, float cost)
    {
      this.m_Provider = provider;
      this.m_Capacity = capacity;
      this.m_Cost = cost;
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.City.MilestoneReachedEvent
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.City
{
  public struct MilestoneReachedEvent : IComponentData, IQueryTypeParameter
  {
    public Entity m_Milestone;
    public int m_Index;

    public MilestoneReachedEvent(Entity milestone, int index)
    {
      this.m_Milestone = milestone;
      this.m_Index = index;
    }
  }
}

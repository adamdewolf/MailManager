// Decompiled with JetBrains decompiler
// Type: Game.Policies.Modify
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Policies
{
  public struct Modify : IComponentData, IQueryTypeParameter
  {
    public Entity m_Entity;
    public Entity m_Policy;
    public PolicyFlags m_Flags;
    public float m_Adjustment;

    public Modify(Entity entity, Entity policy, bool active, float adjustment)
    {
      this.m_Entity = entity;
      this.m_Policy = policy;
      this.m_Flags = active ? PolicyFlags.Active : (PolicyFlags) 0;
      this.m_Adjustment = adjustment;
    }
  }
}

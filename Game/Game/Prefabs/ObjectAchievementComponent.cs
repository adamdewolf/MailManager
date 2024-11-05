// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ObjectAchievementComponent
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.PSI.Common;
using Game.Achievements;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Achievements/", new Type[] {})]
  public class ObjectAchievementComponent : ComponentBase
  {
    public ObjectAchievementComponent.ObjectAchievementSetup[] m_Achievements;

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ObjectAchievement>());
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ObjectAchievementData>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      DynamicBuffer<ObjectAchievementData> buffer = entityManager.GetBuffer<ObjectAchievementData>(entity);
      foreach (ObjectAchievementComponent.ObjectAchievementSetup achievement in this.m_Achievements)
        buffer.Add(new ObjectAchievementData()
        {
          m_ID = achievement.m_ID,
          m_BypassCounter = achievement.m_BypassCounter
        });
    }

    [Serializable]
    public struct ObjectAchievementSetup
    {
      public AchievementId m_ID;
      public bool m_BypassCounter;
    }
  }
}

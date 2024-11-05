// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TutorialCardPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Tutorials;
using System;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tutorials/Phases/", new Type[] {})]
  public class TutorialCardPrefab : TutorialPhasePrefab
  {
    public bool m_CenterCard;

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      entityManager.SetComponentData<TutorialPhaseData>(entity, new TutorialPhaseData()
      {
        m_Type = this.m_CenterCard ? TutorialPhaseType.CenterCard : TutorialPhaseType.Card,
        m_OverrideCompletionDelay = this.m_OverrideCompletionDelay
      });
    }
  }
}

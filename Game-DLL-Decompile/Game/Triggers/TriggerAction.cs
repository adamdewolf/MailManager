﻿// Decompiled with JetBrains decompiler
// Type: Game.Triggers.TriggerAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Triggers
{
  public struct TriggerAction
  {
    public TriggerType m_TriggerType;
    public Entity m_TriggerPrefab;
    public Entity m_PrimaryTarget;
    public Entity m_SecondaryTarget;
    public float m_Value;

    public TriggerAction(
      TriggerType triggerType,
      Entity triggerPrefab,
      Entity primaryTarget,
      Entity secondaryTarget,
      float value = 0.0f)
    {
      this.m_TriggerType = triggerType;
      this.m_TriggerPrefab = triggerPrefab;
      this.m_PrimaryTarget = primaryTarget;
      this.m_SecondaryTarget = secondaryTarget;
      this.m_Value = value;
    }

    public TriggerAction(TriggerType triggerType, Entity triggerPrefab, float value)
    {
      this.m_TriggerType = triggerType;
      this.m_TriggerPrefab = triggerPrefab;
      this.m_PrimaryTarget = Entity.Null;
      this.m_SecondaryTarget = Entity.Null;
      this.m_Value = value;
    }
  }
}
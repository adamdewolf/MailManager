﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ToolError
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Tools;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Notifications/", new Type[] {typeof (NotificationIconPrefab)})]
  public class ToolError : ComponentBase
  {
    public ErrorType m_Error;
    public bool m_TemporaryOnly;
    public bool m_DisableInGame;
    public bool m_DisableInEditor;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<ToolErrorData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      ToolErrorData componentData;
      componentData.m_Error = this.m_Error;
      componentData.m_Flags = (ToolErrorFlags) 0;
      if (this.m_TemporaryOnly)
        componentData.m_Flags |= ToolErrorFlags.TemporaryOnly;
      if (this.m_DisableInGame)
        componentData.m_Flags |= ToolErrorFlags.DisableInGame;
      if (this.m_DisableInEditor)
        componentData.m_Flags |= ToolErrorFlags.DisableInEditor;
      entityManager.SetComponentData<ToolErrorData>(entity, componentData);
    }
  }
}
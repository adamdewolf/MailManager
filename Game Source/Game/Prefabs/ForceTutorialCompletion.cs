﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ForceTutorialCompletion
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Tutorials/", new Type[] {typeof (TutorialPhasePrefab)})]
  public class ForceTutorialCompletion : ComponentBase
  {
    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Tutorials.ForceTutorialCompletion>());
    }
  }
}
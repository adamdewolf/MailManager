﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UIShortcut
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Input;
using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("UI/", new Type[] {})]
  public class UIShortcut : ComponentBase
  {
    public UIInputAction m_Action;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }
  }
}
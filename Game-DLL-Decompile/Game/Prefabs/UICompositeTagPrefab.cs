﻿// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UICompositeTagPrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.OdinSerializer.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("UI/", new System.Type[] {})]
  public class UICompositeTagPrefab : UITagPrefabBase
  {
    [Tooltip("This prefab generates a single tag by concatenating the tags of the items in this array, in the order they appear. The tag is treated as a single tag by the Tutorials system.")]
    public PrefabBase[] m_UITagProviders;

    public override void GetDependencies(List<PrefabBase> prefabs)
    {
      base.GetDependencies(prefabs);
      if (this.m_UITagProviders == null)
        return;
      for (int index = 0; index < this.m_UITagProviders.Length; ++index)
        prefabs.Add(this.m_UITagProviders[index]);
    }

    public override string uiTag
    {
      get
      {
        if (!this.m_Override.IsNullOrWhitespace())
          return this.m_Override;
        return this.m_UITagProviders == null ? base.uiTag : string.Join("+", ((IEnumerable<PrefabBase>) this.m_UITagProviders).Select<PrefabBase, string>((Func<PrefabBase, string>) (t => t.uiTag)));
      }
    }
  }
}
// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UITagPrefabBase
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Annotations;
using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  public abstract class UITagPrefabBase : PrefabBase
  {
    [Tooltip("If set, the override is used as a UI tag instead of the generated tag.")]
    [CanBeNull]
    public string m_Override;

    public override void GetPrefabComponents(HashSet<ComponentType> prefabComponents)
    {
      base.GetPrefabComponents(prefabComponents);
      prefabComponents.Add(ComponentType.ReadWrite<UITagPrefabData>());
    }
  }
}

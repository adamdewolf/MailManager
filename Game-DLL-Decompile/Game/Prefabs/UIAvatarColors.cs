// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UIAvatarColors
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;
using UnityEngine;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("UI/", new System.Type[] {})]
  public class UIAvatarColors : PrefabBase
  {
    public Color32[] m_AvatarColors;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      base.GetPrefabComponents(components);
      components.Add(ComponentType.ReadWrite<UIAvatarColorData>());
    }

    public override void LateInitialize(EntityManager entityManager, Entity entity)
    {
      DynamicBuffer<UIAvatarColorData> buffer = entityManager.GetBuffer<UIAvatarColorData>(entity);
      for (int index = 0; index < this.m_AvatarColors.Length; ++index)
        buffer.Add(new UIAvatarColorData(this.m_AvatarColors[index]));
      base.LateInitialize(entityManager, entity);
    }
  }
}

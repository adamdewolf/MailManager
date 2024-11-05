// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ManualUnlockable
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Prefabs/Unlocking/", new Type[] {})]
  public class ManualUnlockable : UnlockableBase
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }

    public override void LateInitialize(
      EntityManager entityManager,
      Entity entity,
      List<PrefabBase> dependencies)
    {
      entityManager.GetBuffer<UnlockRequirement>(entity).Add(new UnlockRequirement(entity, UnlockFlags.RequireAll));
      base.LateInitialize(entityManager, entity, dependencies);
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.UnlockableBase
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public abstract class UnlockableBase : ComponentBase
  {
    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
    }

    public virtual void LateInitialize(
      EntityManager entityManager,
      Entity entity,
      List<PrefabBase> dependencies)
    {
      this.LateInitialize(entityManager, entity);
    }

    public static void DefaultLateInitialize(
      EntityManager entityManager,
      Entity entity,
      List<PrefabBase> dependencies)
    {
      // ISSUE: variable of a compiler-generated type
      PrefabSystem existingSystemManaged = entityManager.World.GetExistingSystemManaged<PrefabSystem>();
      DynamicBuffer<UnlockRequirement> buffer = entityManager.GetBuffer<UnlockRequirement>(entity);
      for (int index = 0; index < dependencies.Count; ++index)
      {
        PrefabBase dependency = dependencies[index];
        // ISSUE: reference to a compiler-generated method
        if (existingSystemManaged.IsUnlockable(dependency))
        {
          // ISSUE: reference to a compiler-generated method
          Entity entity1 = existingSystemManaged.GetEntity(dependency);
          buffer.Add(new UnlockRequirement(entity1, UnlockFlags.RequireAll));
        }
      }
    }
  }
}

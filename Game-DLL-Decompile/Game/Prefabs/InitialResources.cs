// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.InitialResources
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using System.Collections.Generic;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  [ComponentMenu("Buildings/", new System.Type[] {typeof (BuildingPrefab), typeof (BuildingExtensionPrefab)})]
  public class InitialResources : ComponentBase, IServiceUpgrade
  {
    public InitialResourceItem[] m_InitialResources;

    public override void GetPrefabComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<InitialResourceData>());
    }

    public override void GetArchetypeComponents(HashSet<ComponentType> components)
    {
      if (!((UnityEngine.Object) this.GetComponent<ServiceUpgrade>() == (UnityEngine.Object) null))
        return;
      components.Add(ComponentType.ReadWrite<Game.Economy.Resources>());
    }

    public void GetUpgradeComponents(HashSet<ComponentType> components)
    {
      components.Add(ComponentType.ReadWrite<Game.Economy.Resources>());
    }

    public override void Initialize(EntityManager entityManager, Entity entity)
    {
      base.Initialize(entityManager, entity);
      DynamicBuffer<InitialResourceData> dynamicBuffer = entityManager.AddBuffer<InitialResourceData>(entity);
      if (this.m_InitialResources == null)
        return;
      for (int index = 0; index < this.m_InitialResources.Length; ++index)
        dynamicBuffer.Add(new InitialResourceData()
        {
          m_Value = new ResourceStack()
          {
            m_Resource = EconomyUtils.GetResource(this.m_InitialResources[index].m_Value.m_Resource),
            m_Amount = this.m_InitialResources[index].m_Value.m_Amount
          }
        });
    }
  }
}

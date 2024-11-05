// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.DestroyedTreeSection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Entities;
using Colossal.UI.Binding;
using Game.Objects;
using Game.Prefabs;
using System.Runtime.CompilerServices;
using Unity.Entities;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.InGame
{
  [CompilerGenerated]
  public class DestroyedTreeSection : InfoSectionBase
  {
    protected override string group => nameof (DestroyedTreeSection);

    private Entity destroyer { get; set; }

    protected override bool displayForDestroyedObjects => true;

    protected override void Reset() => this.destroyer = Entity.Null;

    private bool Visible()
    {
      return this.Destroyed && this.EntityManager.HasComponent<Tree>(this.selectedEntity);
    }

    [Preserve]
    protected override void OnUpdate() => this.visible = this.Visible();

    protected override void OnProcess()
    {
      PrefabRef component;
      this.EntityManager.TryGetComponent<PrefabRef>(this.EntityManager.GetComponentData<Game.Common.Destroyed>(this.selectedEntity).m_Event, out component);
      this.destroyer = component.m_Prefab;
      // ISSUE: reference to a compiler-generated field
      this.m_InfoUISystem.tooltipTags.Add(TooltipTags.Destroyed);
    }

    public override void OnWriteProperties(IJsonWriter writer)
    {
      writer.PropertyName("destroyer");
      if (this.destroyer != Entity.Null)
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        PrefabBase prefab = this.m_PrefabSystem.GetPrefab<PrefabBase>(this.destroyer);
        writer.Write(prefab.name);
      }
      else
        writer.WriteNull();
    }

    [Preserve]
    public DestroyedTreeSection()
    {
    }
  }
}

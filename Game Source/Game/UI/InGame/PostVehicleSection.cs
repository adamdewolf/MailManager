// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.PostVehicleSection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Common;
using Game.Vehicles;
using System.Runtime.CompilerServices;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.InGame
{
  [CompilerGenerated]
  public class PostVehicleSection : VehicleSection
  {
    protected override string group => nameof (PostVehicleSection);

    private bool Visible()
    {
      return this.EntityManager.HasComponent<Vehicle>(this.selectedEntity) && this.EntityManager.HasComponent<PostVan>(this.selectedEntity) && this.EntityManager.HasComponent<Owner>(this.selectedEntity);
    }

    [Preserve]
    protected override void OnUpdate() => this.visible = this.Visible();

    protected override void OnProcess()
    {
      this.stateKey = VehicleUIUtils.GetStateKey(this.selectedEntity, this.EntityManager.GetComponentData<PostVan>(this.selectedEntity), this.EntityManager);
      // ISSUE: reference to a compiler-generated method
      base.OnProcess();
    }

    [Preserve]
    public PostVehicleSection()
    {
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.VehicleWithLineSection
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Entities;
using Colossal.UI.Binding;
using Game.Routes;
using Unity.Entities;
using UnityEngine.Scripting;

#nullable disable
namespace Game.UI.InGame
{
  public abstract class VehicleWithLineSection : VehicleSection
  {
    protected Entity lineEntity { get; set; }

    protected override void Reset()
    {
      // ISSUE: reference to a compiler-generated method
      base.Reset();
      this.lineEntity = Entity.Null;
    }

    protected override void OnProcess()
    {
      CurrentRoute component;
      this.lineEntity = this.EntityManager.TryGetComponent<CurrentRoute>(this.selectedEntity, out component) ? component.m_Route : Entity.Null;
      // ISSUE: reference to a compiler-generated method
      base.OnProcess();
    }

    public override void OnWriteProperties(IJsonWriter writer)
    {
      // ISSUE: reference to a compiler-generated method
      base.OnWriteProperties(writer);
      writer.PropertyName("line");
      if (this.lineEntity == Entity.Null)
      {
        writer.WriteNull();
      }
      else
      {
        // ISSUE: reference to a compiler-generated field
        // ISSUE: reference to a compiler-generated method
        this.m_NameSystem.BindName(writer, this.lineEntity);
      }
      writer.PropertyName("lineEntity");
      writer.Write(this.lineEntity);
    }

    [Preserve]
    protected VehicleWithLineSection()
    {
    }
  }
}

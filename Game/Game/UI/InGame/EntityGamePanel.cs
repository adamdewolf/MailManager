// Decompiled with JetBrains decompiler
// Type: Game.UI.InGame.EntityGamePanel
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using System;
using Unity.Entities;

#nullable disable
namespace Game.UI.InGame
{
  public abstract class EntityGamePanel : GamePanel, IEquatable<EntityGamePanel>
  {
    public virtual Entity selectedEntity { get; set; } = Entity.Null;

    protected override void BindProperties(IJsonWriter writer)
    {
      base.BindProperties(writer);
      writer.PropertyName("selectedEntity");
      writer.Write(this.selectedEntity);
    }

    public bool Equals(EntityGamePanel other)
    {
      if (other == null)
        return false;
      return this == other || this.selectedEntity.Equals(other.selectedEntity);
    }
  }
}

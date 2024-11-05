// Decompiled with JetBrains decompiler
// Type: Game.Tools.SelectionElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Tools
{
  [InternalBufferCapacity(0)]
  public struct SelectionElement : IBufferElementData
  {
    public Entity m_Entity;

    public SelectionElement(Entity entity) => this.m_Entity = entity;
  }
}

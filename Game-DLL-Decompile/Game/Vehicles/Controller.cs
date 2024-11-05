// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.Controller
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.Serialization.Entities;
using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct Controller : IComponentData, IQueryTypeParameter, IEmptySerializable
  {
    public Entity m_Controller;

    public Controller(Entity controller) => this.m_Controller = controller;
  }
}

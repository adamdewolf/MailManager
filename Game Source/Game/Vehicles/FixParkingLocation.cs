// Decompiled with JetBrains decompiler
// Type: Game.Vehicles.FixParkingLocation
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Vehicles
{
  public struct FixParkingLocation : IComponentData, IQueryTypeParameter
  {
    public Entity m_ChangeLane;
    public Entity m_ResetLocation;

    public FixParkingLocation(Entity changeLane, Entity resetLocation)
    {
      this.m_ChangeLane = changeLane;
      this.m_ResetLocation = resetLocation;
    }
  }
}

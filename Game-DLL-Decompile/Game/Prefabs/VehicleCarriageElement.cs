// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.VehicleCarriageElement
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  [InternalBufferCapacity(0)]
  public struct VehicleCarriageElement : IBufferElementData
  {
    public Entity m_Prefab;
    public int2 m_Count;
    public VehicleCarriageDirection m_Direction;

    public VehicleCarriageElement(
      Entity carriage,
      int minCount,
      int maxCount,
      VehicleCarriageDirection direction)
    {
      this.m_Prefab = carriage;
      this.m_Count = new int2(minCount, maxCount);
      this.m_Direction = direction;
    }
  }
}

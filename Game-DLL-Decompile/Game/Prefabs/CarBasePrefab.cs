// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CarBasePrefab
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Vehicles;
using Unity.Mathematics;

#nullable disable
namespace Game.Prefabs
{
  public abstract class CarBasePrefab : VehiclePrefab
  {
    public SizeClass m_SizeClass;
    public EnergyTypes m_EnergyType = EnergyTypes.Fuel;
    public float m_MaxSpeed = 200f;
    public float m_Acceleration = 5f;
    public float m_Braking = 10f;
    public float2 m_Turning = new float2(90f, 15f);
    public float m_Stiffness = 100f;
  }
}

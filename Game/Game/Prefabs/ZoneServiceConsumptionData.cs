// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ZoneServiceConsumptionData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ZoneServiceConsumptionData : IComponentData, IQueryTypeParameter
  {
    public float m_Upkeep;
    public float m_ElectricityConsumption;
    public float m_WaterConsumption;
    public float m_GarbageAccumulation;
    public float m_TelecomNeed;
  }
}

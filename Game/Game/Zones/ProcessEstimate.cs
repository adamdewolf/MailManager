// Decompiled with JetBrains decompiler
// Type: Game.Zones.ProcessEstimate
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Zones
{
  public struct ProcessEstimate : IBufferElementData
  {
    public float m_ProductionPerCell;
    public float m_BaseProfitabilityPerCell;
    public float m_WorkerProductionPerCell;
    public float m_LowEducationWeight;
    public Entity m_ProcessEntity;
  }
}

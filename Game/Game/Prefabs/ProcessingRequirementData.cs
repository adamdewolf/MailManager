// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.ProcessingRequirementData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Economy;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct ProcessingRequirementData : IComponentData, IQueryTypeParameter
  {
    public Resource m_ResourceType;
    public int m_MinimumProducedAmount;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.ObjectPlacementTriggerCountData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Tutorials
{
  public struct ObjectPlacementTriggerCountData : IComponentData, IQueryTypeParameter
  {
    public int m_RequiredCount;
    public int m_Count;

    public ObjectPlacementTriggerCountData(int requiredCount)
    {
      this.m_RequiredCount = requiredCount;
      this.m_Count = 0;
    }
  }
}

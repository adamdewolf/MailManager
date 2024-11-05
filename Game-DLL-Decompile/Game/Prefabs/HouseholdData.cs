// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.HouseholdData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct HouseholdData : IComponentData, IQueryTypeParameter
  {
    public int m_InitialWealthRange;
    public int m_InitialWealthOffset;
    public int m_InitialCarProbability;
    public int m_ChildCount;
    public int m_AdultCount;
    public int m_ElderCount;
    public int m_StudentCount;
    public int m_FirstPetProbability;
    public int m_NextPetProbability;
    public int m_Weight;
  }
}

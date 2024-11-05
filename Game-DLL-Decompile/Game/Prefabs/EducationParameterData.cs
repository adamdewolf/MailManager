// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.EducationParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct EducationParameterData : IComponentData, IQueryTypeParameter
  {
    public Entity m_EducationServicePrefab;
    public float m_InoperableSchoolLeaveProbability;
    public float m_EnterHighSchoolProbability;
    public float m_AdultEnterHighSchoolProbability;
    public float m_WorkerContinueEducationProbability;
  }
}

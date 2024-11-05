// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.CompanyNotificationParameterData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct CompanyNotificationParameterData : IComponentData, IQueryTypeParameter
  {
    public Entity m_NoInputsNotificationPrefab;
    public Entity m_NoCustomersNotificationPrefab;
    public float m_NoInputCostLimit;
    public float m_NoCustomersServiceLimit;
  }
}

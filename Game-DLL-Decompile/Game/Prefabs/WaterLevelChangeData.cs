// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.WaterLevelChangeData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Events;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct WaterLevelChangeData : IComponentData, IQueryTypeParameter
  {
    public WaterLevelTargetType m_TargetType;
    public WaterLevelChangeType m_ChangeType;
    public float m_EscalationDelay;
    public DangerFlags m_DangerFlags;
    public float m_DangerLevel;
  }
}

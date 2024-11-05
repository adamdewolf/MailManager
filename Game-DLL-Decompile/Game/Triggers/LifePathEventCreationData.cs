// Decompiled with JetBrains decompiler
// Type: Game.Triggers.LifePathEventCreationData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Triggers
{
  public struct LifePathEventCreationData
  {
    public TriggerType m_TriggerType;
    public Entity m_EventPrefab;
    public Entity m_Sender;
    public Entity m_Target;
    public Entity m_OriginalSender;
  }
}

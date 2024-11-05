// Decompiled with JetBrains decompiler
// Type: Game.Prefabs.TriggerData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Triggers;
using Unity.Entities;

#nullable disable
namespace Game.Prefabs
{
  public struct TriggerData : IBufferElementData
  {
    public TriggerType m_TriggerType;
    public TargetType m_TargetTypes;
    public Entity m_TriggerPrefab;
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Tutorials.ZoningTriggerData
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Tutorials
{
  public struct ZoningTriggerData : IBufferElementData
  {
    public Entity m_Zone;

    public ZoningTriggerData(Entity zone) => this.m_Zone = zone;
  }
}

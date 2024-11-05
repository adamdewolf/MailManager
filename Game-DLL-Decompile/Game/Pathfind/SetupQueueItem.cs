// Decompiled with JetBrains decompiler
// Type: Game.Pathfind.SetupQueueItem
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Pathfind
{
  public struct SetupQueueItem
  {
    public Entity m_Owner;
    public PathfindParameters m_Parameters;
    public SetupQueueTarget m_Origin;
    public SetupQueueTarget m_Destination;

    public SetupQueueItem(
      Entity owner,
      PathfindParameters parameters,
      SetupQueueTarget origin,
      SetupQueueTarget destination)
    {
      this.m_Owner = owner;
      this.m_Parameters = parameters;
      this.m_Origin = origin;
      this.m_Destination = destination;
    }
  }
}

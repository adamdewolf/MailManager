// Decompiled with JetBrains decompiler
// Type: Game.Simulation.HandleRequest
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Unity.Entities;

#nullable disable
namespace Game.Simulation
{
  public struct HandleRequest : IComponentData, IQueryTypeParameter
  {
    public Entity m_Request;
    public Entity m_Handler;
    public bool m_Completed;
    public bool m_PathConsumed;

    public HandleRequest(Entity request, Entity handler, bool completed, bool pathConsumed = false)
    {
      this.m_Request = request;
      this.m_Handler = handler;
      this.m_Completed = completed;
      this.m_PathConsumed = pathConsumed;
    }
  }
}

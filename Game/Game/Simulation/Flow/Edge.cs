// Decompiled with JetBrains decompiler
// Type: Game.Simulation.Flow.Edge
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Net;

#nullable disable
namespace Game.Simulation.Flow
{
  public struct Edge
  {
    public int m_Capacity;
    public FlowDirection m_Direction;
    public int m_FinalFlow;
    public int m_TempFlow;
    public Identifier m_CutElementId;

    public int flow => this.m_FinalFlow + this.m_TempFlow;

    public Edge(int capacity, FlowDirection direction = FlowDirection.Both)
    {
      this.m_Capacity = capacity;
      this.m_Direction = direction;
      this.m_FinalFlow = 0;
      this.m_TempFlow = 0;
      this.m_CutElementId = new Identifier();
    }

    public int GetCapacity(bool backwards)
    {
      return backwards ? ((this.m_Direction & FlowDirection.Backward) == FlowDirection.None ? 0 : this.m_Capacity) : ((this.m_Direction & FlowDirection.Forward) == FlowDirection.None ? 0 : this.m_Capacity);
    }

    public int GetResidualCapacity(bool backwards)
    {
      if (this.m_Direction == FlowDirection.None)
        return 0;
      return backwards ? ((this.m_Direction & FlowDirection.Backward) != FlowDirection.None ? this.m_Capacity : 0) + this.flow : ((this.m_Direction & FlowDirection.Forward) != FlowDirection.None ? this.m_Capacity : 0) - this.flow;
    }

    public int GetFinalFlow(bool backwards) => !backwards ? this.m_FinalFlow : -this.m_FinalFlow;

    public void FinalizeTempFlow()
    {
      this.m_FinalFlow += this.m_TempFlow;
      this.m_TempFlow = 0;
    }
  }
}

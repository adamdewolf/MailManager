// Decompiled with JetBrains decompiler
// Type: Game.Input.Barrier
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
namespace Game.Input
{
  public class Barrier : IDisposable
  {
    private readonly ProxyActionMap[] m_Maps;
    private readonly ProxyAction[] m_Actions;
    private readonly string m_Name;
    private bool m_Blocked;
    private bool m_Disposed;

    public string name => this.m_Name;

    public Barrier(string barrierName, ProxyActionMap map, bool blocked = false)
    {
      this.m_Name = barrierName ?? nameof (Barrier);
      this.m_Maps = new ProxyActionMap[1]{ map };
      this.m_Actions = Array.Empty<ProxyAction>();
      map.m_Barriers.Add(this);
      this.blocked = blocked;
    }

    public Barrier(string barrierName, ProxyAction action, bool blocked = false)
    {
      this.m_Name = barrierName ?? nameof (Barrier);
      this.m_Actions = new ProxyAction[1]{ action };
      this.m_Maps = Array.Empty<ProxyActionMap>();
      action.m_Barriers.Add(this);
      this.blocked = blocked;
    }

    public Barrier(
      string barrierName,
      IEnumerable<ProxyActionMap> maps,
      IEnumerable<ProxyAction> actions,
      bool blocked = false)
    {
      this.m_Name = barrierName ?? nameof (Barrier);
      this.m_Maps = maps.Distinct<ProxyActionMap>().ToArray<ProxyActionMap>();
      this.m_Actions = actions.Distinct<ProxyAction>().ToArray<ProxyAction>();
      foreach (ProxyActionMap map in this.m_Maps)
        map.m_Barriers.Add(this);
      foreach (ProxyAction action in this.m_Actions)
        action.m_Barriers.Add(this);
      this.blocked = blocked;
    }

    public Barrier(string barrierName, IEnumerable<ProxyActionMap> maps, bool blocked = false)
      : this(barrierName, maps, (IEnumerable<ProxyAction>) Array.Empty<ProxyAction>(), blocked)
    {
    }

    public Barrier(string barrierName, IEnumerable<ProxyAction> actions, bool blocked = false)
      : this(barrierName, (IEnumerable<ProxyActionMap>) Array.Empty<ProxyActionMap>(), actions, blocked)
    {
    }

    public bool blocked
    {
      get => this.m_Blocked;
      set
      {
        if (this.m_Disposed || value == this.m_Blocked)
          return;
        this.m_Blocked = value;
        foreach (ProxyActionMap map in this.m_Maps)
          map.UpdateState();
        foreach (ProxyAction action in this.m_Actions)
          action.UpdateState();
      }
    }

    public void Dispose()
    {
      if (this.m_Disposed)
        return;
      this.m_Disposed = true;
      foreach (ProxyActionMap map in this.m_Maps)
      {
        map.m_Barriers.Remove(this);
        map.UpdateState();
      }
      foreach (ProxyAction action in this.m_Actions)
      {
        action.m_Barriers.Remove(this);
        action.UpdateState();
      }
    }
  }
}

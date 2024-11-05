// Decompiled with JetBrains decompiler
// Type: Game.Input.ProxyActionMap
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

#nullable disable
namespace Game.Input
{
  [DebuggerDisplay("{name}")]
  public class ProxyActionMap
  {
    private InputActionMap m_SourceMap;
    private readonly Dictionary<string, ProxyAction> m_Actions = new Dictionary<string, ProxyAction>();
    internal HashSet<Barrier> m_Barriers = new HashSet<Barrier>();
    private bool m_Enabled;
    private InputManager.DeviceType m_Mask = InputManager.DeviceType.All;

    internal InputActionMap sourceMap => this.m_SourceMap;

    public string name => this.m_SourceMap.name;

    public IReadOnlyDictionary<string, ProxyAction> actions
    {
      get => (IReadOnlyDictionary<string, ProxyAction>) this.m_Actions;
    }

    public IEnumerable<ProxyBinding> bindings
    {
      get
      {
        foreach (KeyValuePair<string, ProxyAction> action in this.m_Actions)
        {
          string str;
          ProxyAction proxyAction;
          action.Deconstruct(ref str, ref proxyAction);
          foreach (KeyValuePair<InputManager.DeviceType, ProxyComposite> composite in (IEnumerable<KeyValuePair<InputManager.DeviceType, ProxyComposite>>) proxyAction.composites)
          {
            InputManager.DeviceType deviceType;
            ProxyComposite proxyComposite;
            composite.Deconstruct(ref deviceType, ref proxyComposite);
            foreach (KeyValuePair<ActionComponent, ProxyBinding> binding1 in (IEnumerable<KeyValuePair<ActionComponent, ProxyBinding>>) proxyComposite.bindings)
            {
              ActionComponent actionComponent;
              ProxyBinding binding2;
              binding1.Deconstruct(ref actionComponent, ref binding2);
              yield return binding2;
            }
          }
        }
      }
    }

    public bool enabled => this.m_Enabled;

    public InputManager.DeviceType mask
    {
      get => this.m_Mask;
      internal set
      {
        if (value == this.m_Mask)
          return;
        this.m_Mask = value;
        this.m_SourceMap.bindingMask = value.ToInputBinding();
      }
    }

    internal ProxyActionMap(InputActionMap sourceMap) => this.m_SourceMap = sourceMap;

    internal void InitActions()
    {
      foreach (InputAction action in this.sourceMap.actions)
      {
        ProxyAction proxyAction = new ProxyAction(this, action);
        this.m_Actions.Add(proxyAction.name, proxyAction);
      }
      this.UpdateState();
    }

    public ProxyAction FindAction(string name)
    {
      return this.m_Actions.GetValueOrDefault<string, ProxyAction>(name);
    }

    internal ProxyAction FindAction(InputAction action) => this.FindAction(action.name);

    public bool TryFindAction(string name, out ProxyAction action)
    {
      return this.m_Actions.TryGetValue(name, out action);
    }

    public ProxyAction AddAction(ProxyAction.Info actionInfo, bool bulk = false)
    {
      using (Colossal.PerformanceCounter.Start((Action<TimeSpan>) (t => InputManager.log.InfoFormat("Action \"{1}\" added in {0}ms", (object) t.TotalMilliseconds, (object) actionInfo.m_Name))))
      {
        using (InputManager.DeferUpdating())
        {
          ProxyAction action;
          if (this.TryFindAction(actionInfo.m_Name, out action))
            return action;
          InputAction inputAction = this.m_SourceMap.AddAction(actionInfo.m_Name, actionInfo.m_Type.GetInputActionType(), expectedControlLayout: actionInfo.m_Type.GetExpectedControlLayout());
          foreach (ProxyComposite.Info composite in actionInfo.m_Composites)
            InputManager.CreateCompositeBinding(inputAction, composite);
          ProxyAction proxyAction = new ProxyAction(this, inputAction);
          this.m_Actions.Add(proxyAction.name, proxyAction);
          return proxyAction;
        }
      }
    }

    internal void UpdateState()
    {
      bool flag = this.m_Barriers.All<Barrier>((Func<Barrier, bool>) (b => !b.blocked));
      if (flag == this.m_Enabled)
        return;
      this.m_Enabled = flag;
      foreach (KeyValuePair<string, ProxyAction> action in this.m_Actions)
      {
        string str;
        ProxyAction proxyAction;
        action.Deconstruct(ref str, ref proxyAction);
        proxyAction.UpdateState();
      }
    }
  }
}

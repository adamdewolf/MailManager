// Decompiled with JetBrains decompiler
// Type: Game.Input.ProxyAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Input
{
  public class ProxyAction
  {
    private readonly InputAction m_SourceAction;
    private readonly ProxyActionMap m_Map;
    internal readonly HashSet<Barrier> m_Barriers = new HashSet<Barrier>();
    internal readonly HashSet<DisplayNameOverride> m_DisplayOverrides = new HashSet<DisplayNameOverride>();
    private readonly List<ProxyAction> m_LinkedActions = new List<ProxyAction>();
    internal readonly HashSet<UIInputAction> m_UIAliases = new HashSet<UIInputAction>();
    private bool m_ShouldBeEnabled;
    private InputManager.DeviceType m_Mask = InputManager.DeviceType.All;
    private readonly Dictionary<InputManager.DeviceType, ProxyComposite> m_Composites = new Dictionary<InputManager.DeviceType, ProxyComposite>();
    private readonly List<ProxyBinding> m_Bindings = new List<ProxyBinding>();
    private readonly List<ProxyBinding> m_MaskedBindings = new List<ProxyBinding>();
    private InputManager.DeviceType m_TotalMask;
    private Action<ProxyAction, InputActionPhase> m_OnInteraction;
    private static int m_DeferUpdating;
    private static HashSet<ProxyAction> m_UpdateQueue = new HashSet<ProxyAction>();
    private static ProxyAction.DeferActionUpdatingWrapper m_DeferUpdatingWrapper;

    public event Action<bool> onShouldBeEnabledChanged;

    public event Action<ProxyAction> onChanged;

    public ProxyActionMap map => this.m_Map;

    internal InputAction sourceAction => this.m_SourceAction;

    public IReadOnlyDictionary<InputManager.DeviceType, ProxyComposite> composites
    {
      get => (IReadOnlyDictionary<InputManager.DeviceType, ProxyComposite>) this.m_Composites;
    }

    public int compositesCount => this.m_Composites.Count;

    public IReadOnlyList<ProxyBinding> bindings => (IReadOnlyList<ProxyBinding>) this.m_Bindings;

    public IReadOnlyList<ProxyBinding> maskedBindings
    {
      get
      {
        if (this.m_TotalMask != (this.mask & this.map.mask))
        {
          this.m_TotalMask = this.mask & this.map.mask;
          this.m_MaskedBindings.Clear();
          foreach (KeyValuePair<InputManager.DeviceType, ProxyComposite> composite in this.m_Composites)
          {
            InputManager.DeviceType deviceType;
            ProxyComposite proxyComposite1;
            composite.Deconstruct(ref deviceType, ref proxyComposite1);
            ProxyComposite proxyComposite2 = proxyComposite1;
            if ((proxyComposite2.m_Device & this.m_TotalMask) != InputManager.DeviceType.None)
            {
              foreach (KeyValuePair<ActionComponent, ProxyBinding> binding in (IEnumerable<KeyValuePair<ActionComponent, ProxyBinding>>) proxyComposite2.bindings)
              {
                ActionComponent actionComponent;
                ProxyBinding proxyBinding;
                binding.Deconstruct(ref actionComponent, ref proxyBinding);
                this.m_MaskedBindings.Add(proxyBinding);
              }
            }
          }
        }
        return (IReadOnlyList<ProxyBinding>) this.m_MaskedBindings;
      }
    }

    internal IReadOnlyList<ProxyAction> linkedActions
    {
      get => (IReadOnlyList<ProxyAction>) this.m_LinkedActions;
    }

    public bool isSet
    {
      get
      {
        return this.m_Composites.Any<KeyValuePair<InputManager.DeviceType, ProxyComposite>>((Func<KeyValuePair<InputManager.DeviceType, ProxyComposite>, bool>) (c => c.Value.isSet));
      }
    }

    public bool isBuiltIn
    {
      get
      {
        return this.m_Composites.Any<KeyValuePair<InputManager.DeviceType, ProxyComposite>>((Func<KeyValuePair<InputManager.DeviceType, ProxyComposite>, bool>) (c => c.Value.isBuildIn));
      }
    }

    internal bool isDummy
    {
      get
      {
        return this.m_Composites.Count == 0 || this.m_Composites.Any<KeyValuePair<InputManager.DeviceType, ProxyComposite>>((Func<KeyValuePair<InputManager.DeviceType, ProxyComposite>, bool>) (c => c.Value.isDummy));
      }
    }

    public bool isKeyboardAction => this.ContainsComposite(InputManager.DeviceType.Keyboard);

    public bool isMouseAction => this.ContainsComposite(InputManager.DeviceType.Mouse);

    public bool isGamepadAction => this.ContainsComposite(InputManager.DeviceType.Gamepad);

    public bool isOnlyKeyboardAction
    {
      get => this.compositesCount == 1 && this.ContainsComposite(InputManager.DeviceType.Keyboard);
    }

    public bool isOnlyMouseAction
    {
      get => this.compositesCount == 1 && this.ContainsComposite(InputManager.DeviceType.Mouse);
    }

    public bool isOnlyGamepadAction
    {
      get => this.compositesCount == 1 && this.ContainsComposite(InputManager.DeviceType.Gamepad);
    }

    public bool isMultiDeviceAction => this.compositesCount > 1;

    public string name => this.m_SourceAction.name;

    public string mapName => this.m_Map.name;

    public string title => this.mapName + "/" + this.name;

    public System.Type valueType
    {
      get
      {
        System.Type valueType;
        switch (this.m_SourceAction.expectedControlType)
        {
          case "Dpad":
            valueType = typeof (Vector2);
            break;
          case "Stick":
            valueType = typeof (Vector2);
            break;
          case "Vector2":
            valueType = typeof (Vector2);
            break;
          case "Axis":
            valueType = typeof (float);
            break;
          case "Button":
            valueType = typeof (float);
            break;
          default:
            valueType = typeof (float);
            break;
        }
        return valueType;
      }
    }

    public bool enabled
    {
      get => this.m_SourceAction.enabled;
      internal set
      {
        this.m_ShouldBeEnabled = value;
        this.UpdateState();
      }
    }

    public InputManager.DeviceType mask
    {
      get => this.m_Mask;
      internal set
      {
        if (value == this.m_Mask)
          return;
        this.m_Mask = value;
        this.m_SourceAction.bindingMask = value.ToInputBinding();
        if (!InputManager.exists)
          return;
        Action actionMasksChanged = InputManager.instance.EventActionMasksChanged;
        if (actionMasksChanged == null)
          return;
        actionMasksChanged();
      }
    }

    public bool shouldBeEnabled
    {
      get => this.m_ShouldBeEnabled;
      set
      {
        if (value == this.m_ShouldBeEnabled)
          return;
        this.m_ShouldBeEnabled = value;
        Action<bool> beEnabledChanged = this.onShouldBeEnabledChanged;
        if (beEnabledChanged != null)
          beEnabledChanged(value);
        if (value)
          return;
        this.enabled = false;
      }
    }

    public DisplayNameOverride displayOverride { get; private set; }

    public IEnumerable<string> usedKeys
    {
      get
      {
        return this.bindings.Where<ProxyBinding>((Func<ProxyBinding, bool>) (b => b.isSet)).Select<ProxyBinding, string>((Func<ProxyBinding, string>) (b => b.path)).Distinct<string>();
      }
    }

    internal ProxyAction(ProxyActionMap map, InputAction sourceAction)
    {
      this.m_Map = map ?? throw new ArgumentNullException(nameof (map));
      this.m_SourceAction = sourceAction ?? throw new ArgumentNullException(nameof (sourceAction));
      this.m_ShouldBeEnabled = sourceAction.enabled;
      this.Update();
    }

    public T ReadValue<T>() where T : struct
    {
      return !this.IsInProgress() ? default (T) : this.m_SourceAction.ReadValue<T>();
    }

    public object ReadValueAsObject() => this.m_SourceAction.ReadValueAsObject();

    public unsafe T GetMinValue<T>() where T : struct
    {
      InputActionState state = this.m_SourceAction.GetOrCreateActionMap().m_State;
      if (state == null)
        return default (T);
      int bindingIndex = state.actionStates[this.m_SourceAction.m_ActionIndexInState].bindingIndex;
      if (state.bindingStates[bindingIndex].isPartOfComposite)
        bindingIndex = state.bindingStates[bindingIndex].compositeOrCompositeBindingIndex;
      return state.ApplyProcessors<T>(bindingIndex, default (T));
    }

    public unsafe T GetMaxValue<T>() where T : struct
    {
      InputActionState state = this.m_SourceAction.GetOrCreateActionMap().m_State;
      if (state == null)
        return default (T);
      T maxValue = default (T);
      T obj;
      if (!((ValueType) maxValue is int))
      {
        if (!((ValueType) maxValue is float))
        {
          if (!((ValueType) maxValue is Vector2))
            return maxValue;
          obj = (T) (ValueType) Vector2.one;
        }
        else
          obj = (T) (ValueType) 1f;
      }
      else
        obj = (T) (ValueType) 1;
      int bindingIndex = state.actionStates[this.m_SourceAction.m_ActionIndexInState].bindingIndex;
      if (state.bindingStates[bindingIndex].isPartOfComposite)
        bindingIndex = state.bindingStates[bindingIndex].compositeOrCompositeBindingIndex;
      return state.ApplyProcessors<T>(bindingIndex, obj);
    }

    public bool IsPressed() => this.m_SourceAction.IsPressed();

    public bool IsInProgress() => this.m_SourceAction.IsInProgress();

    public bool WasPressedThisFrame() => this.m_SourceAction.WasPressedThisFrame();

    public bool WasReleasedThisFrame() => this.m_SourceAction.WasReleasedThisFrame();

    public bool WasPerformedThisFrame() => this.m_SourceAction.WasPerformedThisFrame();

    public event Action<ProxyAction, InputActionPhase> onInteraction
    {
      add
      {
        if (this.m_OnInteraction == null)
        {
          this.m_OnInteraction += value;
          this.m_SourceAction.started += new Action<InputAction.CallbackContext>(this.SourceOnStarted);
          this.m_SourceAction.performed += new Action<InputAction.CallbackContext>(this.SourceOnPerformed);
          this.m_SourceAction.canceled += new Action<InputAction.CallbackContext>(this.SourceOnCanceled);
        }
        else
          this.m_OnInteraction += value;
      }
      remove
      {
        this.m_OnInteraction -= value;
        if (this.m_OnInteraction != null)
          return;
        this.m_SourceAction.started -= new Action<InputAction.CallbackContext>(this.SourceOnStarted);
        this.m_SourceAction.performed -= new Action<InputAction.CallbackContext>(this.SourceOnPerformed);
        this.m_SourceAction.canceled -= new Action<InputAction.CallbackContext>(this.SourceOnCanceled);
      }
    }

    private void SourceOnStarted(InputAction.CallbackContext context)
    {
      Action<ProxyAction, InputActionPhase> onInteraction = this.m_OnInteraction;
      if (onInteraction == null)
        return;
      onInteraction(this, InputActionPhase.Started);
    }

    private void SourceOnPerformed(InputAction.CallbackContext context)
    {
      Action<ProxyAction, InputActionPhase> onInteraction = this.m_OnInteraction;
      if (onInteraction == null)
        return;
      onInteraction(this, InputActionPhase.Performed);
    }

    private void SourceOnCanceled(InputAction.CallbackContext context)
    {
      Action<ProxyAction, InputActionPhase> onInteraction = this.m_OnInteraction;
      if (onInteraction == null)
        return;
      onInteraction(this, InputActionPhase.Canceled);
    }

    internal void UpdateState()
    {
      if (this.m_SourceAction == null)
        return;
      bool flag = this.m_ShouldBeEnabled && this.m_Map.enabled && this.m_Barriers.All<Barrier>((Func<Barrier, bool>) (b => !b.blocked));
      if (flag == this.m_SourceAction.enabled)
        return;
      if (flag)
        this.m_SourceAction.Enable();
      else
        this.m_SourceAction.Disable();
      this.UpdateDisplay();
      if (!InputManager.exists)
        return;
      Action enabledActionsChanged = InputManager.instance.EventEnabledActionsChanged;
      if (enabledActionsChanged == null)
        return;
      enabledActionsChanged();
    }

    internal void UpdateDisplay()
    {
      this.displayOverride = this.enabled ? this.m_DisplayOverrides.Where<DisplayNameOverride>((Func<DisplayNameOverride, bool>) (n => n.active)).OrderBy<DisplayNameOverride, int>((Func<DisplayNameOverride, int>) (n => n.priority)).FirstOrDefault<DisplayNameOverride>() : (DisplayNameOverride) null;
      if (!InputManager.exists)
        return;
      Action displayNamesChanged = InputManager.instance.EventActionDisplayNamesChanged;
      if (displayNamesChanged == null)
        return;
      displayNamesChanged();
    }

    internal void Update(bool ignoreDefer = false)
    {
      if (ProxyAction.isDeferred && !ignoreDefer)
      {
        ProxyAction.AddToUpdateQueue(this);
      }
      else
      {
        this.m_Composites.Clear();
        foreach (ProxyComposite composite in InputManager.instance.GetComposites(this.sourceAction))
          this.m_Composites[composite.m_Device] = composite;
        this.m_Bindings.Clear();
        foreach (KeyValuePair<InputManager.DeviceType, ProxyComposite> composite in this.m_Composites)
        {
          InputManager.DeviceType deviceType;
          ProxyComposite proxyComposite;
          composite.Deconstruct(ref deviceType, ref proxyComposite);
          foreach (KeyValuePair<ActionComponent, ProxyBinding> binding in (IEnumerable<KeyValuePair<ActionComponent, ProxyBinding>>) proxyComposite.bindings)
          {
            ActionComponent actionComponent;
            ProxyBinding proxyBinding;
            binding.Deconstruct(ref actionComponent, ref proxyBinding);
            this.m_Bindings.Add(proxyBinding);
          }
        }
        this.m_MaskedBindings.Clear();
        this.m_TotalMask = InputManager.DeviceType.None;
        InputManager.instance.UpdateActionInKeyActionMap(this);
        InputManager.instance.OnActionChanged();
        Action<ProxyAction> onChanged = this.onChanged;
        if (onChanged == null)
          return;
        onChanged(this);
      }
    }

    public bool TryGetComposite(InputManager.DeviceType device, out ProxyComposite composite)
    {
      return this.m_Composites.TryGetValue(device, out composite);
    }

    public bool TryGetBinding(ProxyBinding sampleBinding, out ProxyBinding foundBinding)
    {
      ProxyComposite composite;
      if (this.TryGetComposite(sampleBinding.device, out composite))
        return composite.TryGetBinding(sampleBinding, out foundBinding);
      foundBinding = new ProxyBinding();
      return false;
    }

    public bool ContainsComposite(InputManager.DeviceType device)
    {
      return this.m_Composites.ContainsKey(device);
    }

    internal void AddLinkedAction(ProxyAction linked)
    {
      if (this.Equals((object) linked) || this.m_LinkedActions.Contains(linked))
        return;
      this.m_LinkedActions.Add(linked);
    }

    internal static bool CanConflict(ProxyAction a, ProxyAction b)
    {
      if (a == b || a.m_LinkedActions != null && a.m_LinkedActions.Contains(b) || b.m_LinkedActions != null && b.m_LinkedActions.Contains(a))
        return false;
      if (a.m_LinkedActions != null && b.m_LinkedActions != null)
      {
        for (int index = 0; index < a.m_LinkedActions.Count; ++index)
        {
          if (b.m_LinkedActions.Contains(a.m_LinkedActions[index]))
            return false;
        }
      }
      return true;
    }

    public override string ToString()
    {
      return this.mapName + "/" + this.name + " ( " + string.Join(" | ", this.bindings.Where<ProxyBinding>((Func<ProxyBinding, bool>) (b => !string.IsNullOrEmpty(b.path))).Select<ProxyBinding, string>((Func<ProxyBinding, string>) (b => string.Format("{0}: {1}{2}", (object) b.component, (object) string.Join("", b.modifiers.Select<ProxyModifier, string>((Func<ProxyModifier, string>) (m => m.m_Path + " + "))), (object) b.path)))) + " )";
    }

    internal static ProxyAction.DeferActionUpdatingWrapper DeferUpdating()
    {
      if (ProxyAction.m_DeferUpdatingWrapper == null)
        ProxyAction.m_DeferUpdatingWrapper = new ProxyAction.DeferActionUpdatingWrapper();
      return ProxyAction.m_DeferUpdatingWrapper;
    }

    public static bool isDeferred => ProxyAction.m_DeferUpdating != 0;

    public static void AddToUpdateQueue(ProxyAction action)
    {
      ProxyAction.m_UpdateQueue.Add(action);
    }

    public struct Info
    {
      public string m_Name;
      public string m_Map;
      public ActionType m_Type;
      public List<ProxyComposite.Info> m_Composites;
    }

    internal class DeferActionUpdatingWrapper : IDisposable
    {
      public void Acquire() => ++ProxyAction.m_DeferUpdating;

      public void Dispose()
      {
        if (ProxyAction.m_DeferUpdating > 0)
          --ProxyAction.m_DeferUpdating;
        if (ProxyAction.m_DeferUpdating != 0)
          return;
        try
        {
          ++ProxyAction.m_DeferUpdating;
          while (ProxyAction.m_UpdateQueue.Count != 0)
          {
            ProxyAction[] array = ProxyAction.m_UpdateQueue.ToArray<ProxyAction>();
            ProxyAction.m_UpdateQueue.Clear();
            foreach (ProxyAction proxyAction in array)
              proxyAction.Update(true);
          }
        }
        finally
        {
          --ProxyAction.m_DeferUpdating;
        }
      }
    }
  }
}

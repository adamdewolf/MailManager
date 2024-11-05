// Decompiled with JetBrains decompiler
// Type: Game.UI.InputActionBindings
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Colossal.UI.Binding;
using Game.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.UI
{
  public class InputActionBindings : CompositeBinding, IDisposable
  {
    private const int kDisabledPriority = -1;
    private const string kGroup = "input";
    private RawEventBinding m_ActionPerformedBinding;
    private RawEventBinding m_ActionReleasedBinding;
    private InputActionBindings.ActionState[] m_SystemActionStates = Array.Empty<InputActionBindings.ActionState>();
    private InputActionBindings.ActionState[] m_UIActionStates = Array.Empty<InputActionBindings.ActionState>();
    private InputActionBindings.ActionState[] m_ModActionStates = Array.Empty<InputActionBindings.ActionState>();
    private Dictionary<(ProxyAction, UIInputAction.ProcessAs), InputActionBindings.IEventTrigger> m_Triggers = new Dictionary<(ProxyAction, UIInputAction.ProcessAs), InputActionBindings.IEventTrigger>();
    private bool m_ActionsDirty = true;
    private bool m_ConflictsDirty = true;
    private bool m_UpdateInProgress;

    public InputActionBindings()
    {
      this.AddBinding((IBinding) (this.m_ActionPerformedBinding = new RawEventBinding("input", "onActionPerformed")));
      this.AddBinding((IBinding) (this.m_ActionReleasedBinding = new RawEventBinding("input", "onActionReleased")));
      this.AddBinding((IBinding) new TriggerBinding<int, int>("input", "setActionPriority", new Action<int, int>(this.SetActionPriority)));
      this.AddBinding((IBinding) new ValueBinding<string[]>("input", "actionNames", ((IEnumerable<UIInputAction>) Game.Input.InputManager.instance.uiActionCollection.m_InputActions).Select<UIInputAction, string>((Func<UIInputAction, string>) (a => a.m_AliasName)).ToArray<string>(), (IWriter<string[]>) new ArrayWriter<string>()));
      Game.Input.InputManager.instance.EventActionsChanged += new Action(this.OnActionsChanged);
      Game.Input.InputManager.instance.EventEnabledActionsChanged += new Action(this.OnEnabledActionsChanged);
      Game.Input.InputManager.instance.EventActionMasksChanged += new Action(this.OnActionMasksChanged);
      Game.Input.InputManager.instance.EventControlSchemeChanged += new Action<Game.Input.InputManager.ControlScheme>(this.OnControlSchemeChanged);
    }

    public void Dispose()
    {
      Game.Input.InputManager.instance.EventActionsChanged -= new Action(this.OnActionsChanged);
      Game.Input.InputManager.instance.EventEnabledActionsChanged -= new Action(this.OnEnabledActionsChanged);
      Game.Input.InputManager.instance.EventActionMasksChanged += new Action(this.OnActionMasksChanged);
      Game.Input.InputManager.instance.EventControlSchemeChanged -= new Action<Game.Input.InputManager.ControlScheme>(this.OnControlSchemeChanged);
      foreach (InputActionBindings.ActionState uiActionState in this.m_UIActionStates)
        uiActionState.Dispose();
      foreach (InputActionBindings.ActionState modActionState in this.m_ModActionStates)
        modActionState.Dispose();
      foreach (IDisposable disposable in this.m_Triggers.Values)
        disposable.Dispose();
      this.m_Triggers.Clear();
    }

    private void SetActionPriority(int index, int priority)
    {
      this.m_UIActionStates[index].priority = priority;
    }

    private void SetConflictsDirty() => this.m_ConflictsDirty = true;

    private void SetActionDirty() => this.m_ActionsDirty = true;

    private void OnActionsChanged()
    {
      if (this.m_UpdateInProgress)
        return;
      this.m_ActionsDirty = true;
      this.m_ConflictsDirty = true;
    }

    private void OnEnabledActionsChanged()
    {
      if (this.m_UpdateInProgress)
        return;
      this.m_ConflictsDirty = true;
    }

    private void OnActionMasksChanged()
    {
      if (this.m_UpdateInProgress)
        return;
      this.m_ConflictsDirty = true;
    }

    private void OnControlSchemeChanged(Game.Input.InputManager.ControlScheme scheme)
    {
      if (this.m_UpdateInProgress)
        return;
      this.m_ConflictsDirty = true;
    }

    public override bool Update()
    {
      this.m_UpdateInProgress = true;
      if (this.m_ActionsDirty)
      {
        this.RefreshActions();
        this.m_ActionsDirty = false;
      }
      if (this.m_ConflictsDirty)
      {
        this.ResolveConflicts();
        this.m_ConflictsDirty = false;
      }
      this.m_UpdateInProgress = false;
      return base.Update();
    }

    private void RefreshActions()
    {
      if (this.m_UIActionStates.Length != Game.Input.InputManager.instance.uiActionCollection.m_InputActions.Length)
      {
        for (int index = 0; index < this.m_UIActionStates.Length; ++index)
        {
          if (this.m_UIActionStates[index] != null)
          {
            this.m_UIActionStates[index].action.enabled = false;
            this.m_UIActionStates[index].Dispose();
            RemoveTrigger(this.m_UIActionStates[index]);
          }
        }
        this.m_UIActionStates = new InputActionBindings.ActionState[Game.Input.InputManager.instance.uiActionCollection.m_InputActions.Length];
        for (int index = 0; index < Game.Input.InputManager.instance.uiActionCollection.m_InputActions.Length; ++index)
        {
          UIInputAction inputAction = Game.Input.InputManager.instance.uiActionCollection.m_InputActions[index];
          ProxyAction proxyAction = inputAction.GetProxyAction();
          this.m_UIActionStates[index] = new InputActionBindings.ActionState(proxyAction, inputAction.m_AliasName, inputAction.GetDisplayName(nameof (InputActionBindings)), inputAction.m_ProcessAs, inputAction.m_Transform);
          SetTrigger(this.m_UIActionStates[index]);
          proxyAction.enabled = true;
        }
      }
      if (this.m_ModActionStates != null)
      {
        for (int index = 0; index < this.m_ModActionStates.Length; ++index)
        {
          RemoveTrigger(this.m_ModActionStates[index]);
          this.m_ModActionStates[index].Dispose();
          this.m_ModActionStates[index] = (InputActionBindings.ActionState) null;
        }
      }
      this.m_ModActionStates = Game.Input.InputManager.instance.actions.Where<ProxyAction>((Func<ProxyAction, bool>) (a => !a.isBuiltIn && !a.isDummy)).Select<ProxyAction, InputActionBindings.ActionState>((Func<ProxyAction, InputActionBindings.ActionState>) (a =>
      {
        InputActionBindings.ActionState state = new InputActionBindings.ActionState(a, a.title, new DisplayNameOverride(nameof (InputActionBindings), a, a.title, 1000));
        SetTrigger(state);
        return state;
      })).ToArray<InputActionBindings.ActionState>();
      this.m_SystemActionStates = Game.Input.InputManager.instance.actions.Where<ProxyAction>((Func<ProxyAction, bool>) (a => a.isBuiltIn && !a.isDummy && ((IEnumerable<InputActionBindings.ActionState>) this.m_UIActionStates).All<InputActionBindings.ActionState>((Func<InputActionBindings.ActionState, bool>) (s => s?.action != a)))).Select<ProxyAction, InputActionBindings.ActionState>((Func<ProxyAction, InputActionBindings.ActionState>) (a =>
      {
        InputActionBindings.ActionState state = new InputActionBindings.ActionState(a, a.title);
        SetTrigger(state);
        return state;
      })).ToArray<InputActionBindings.ActionState>();

      void SetTrigger(InputActionBindings.ActionState state)
      {
        state.onChanged += new Action(this.SetConflictsDirty);
        InputActionBindings.IEventTrigger trigger;
        if (!this.m_Triggers.TryGetValue((state.action, state.processAs), out trigger))
        {
          trigger = InputActionBindings.IEventTrigger.GetTrigger(this, state.action, state.processAs);
          this.m_Triggers.Add((state.action, state.processAs), trigger);
        }
        trigger.states.Add(state);
      }

      void RemoveTrigger(InputActionBindings.ActionState state)
      {
        state.onChanged -= new Action(this.SetConflictsDirty);
        InputActionBindings.IEventTrigger eventTrigger;
        if (!this.m_Triggers.TryGetValue((state.action, state.processAs), out eventTrigger))
          return;
        eventTrigger.states.Remove(state);
        if (eventTrigger.states.Count != 0)
          return;
        eventTrigger.Dispose();
        this.m_Triggers.Remove((state.action, state.processAs));
      }
    }

    private void ResolveConflicts()
    {
      int[] array = Enumerable.Range(0, this.m_UIActionStates.Length).OrderBy<int, InputActionBindings.ActionState>((Func<int, InputActionBindings.ActionState>) (i => this.m_UIActionStates[i])).ToArray<int>();
      for (int index = 0; index < this.m_UIActionStates.Length; ++index)
        this.m_UIActionStates[index].UpdateState();
      for (int index = 0; index < this.m_ModActionStates.Length; ++index)
        this.m_ModActionStates[index].UpdateState();
      for (int index1 = 0; index1 < this.m_SystemActionStates.Length; ++index1)
      {
        InputActionBindings.ActionState systemActionState = this.m_SystemActionStates[index1];
        if (systemActionState.action.enabled)
        {
          for (int index2 = 0; index2 < this.m_UIActionStates.Length; ++index2)
            this.m_UIActionStates[index2].ResolveConflicts(systemActionState);
          for (int index3 = 0; index3 < this.m_ModActionStates.Length; ++index3)
            this.m_ModActionStates[index3].ResolveConflicts(systemActionState);
        }
      }
      for (int index4 = 0; index4 < array.Length; ++index4)
      {
        InputActionBindings.ActionState uiActionState = this.m_UIActionStates[array[index4]];
        if (uiActionState.state == InputActionBindings.ActionState.State.Enabled)
        {
          for (int index5 = index4 + 1; index5 < array.Length; ++index5)
            this.m_UIActionStates[array[index5]].ResolveConflicts(uiActionState);
          for (int index6 = 0; index6 < this.m_ModActionStates.Length; ++index6)
            this.m_ModActionStates[index6].ResolveConflicts(uiActionState);
        }
      }
      for (int index = 0; index < this.m_UIActionStates.Length; ++index)
        this.m_UIActionStates[index].Apply();
      for (int index = 0; index < this.m_ModActionStates.Length; ++index)
        this.m_ModActionStates[index].Apply();
    }

    private class ActionState : IComparable<InputActionBindings.ActionState>, IDisposable
    {
      private bool m_Disposed;
      private readonly string m_Name;
      private readonly ProxyAction m_Action;
      private readonly UIInputAction.ProcessAs m_ProcessAs;
      private readonly Barrier m_Barrier;
      private readonly DisplayNameOverride m_NameOverride;
      private int m_Priority;
      private InputActionBindings.ActionState.State m_State;
      private readonly UIInputAction.Transform m_Transform;

      public event Action onChanged;

      public bool isDisposed => this.m_Disposed;

      public ProxyAction action => this.m_Action;

      public string name => this.m_Name;

      public int priority
      {
        get => this.m_Priority;
        set
        {
          if (this.m_Disposed || value == this.m_Priority)
            return;
          this.m_Priority = value;
          Action onChanged = this.onChanged;
          if (onChanged == null)
            return;
          onChanged();
        }
      }

      public InputActionBindings.ActionState.State state
      {
        get => this.m_State;
        set
        {
          if (this.m_Disposed || value == this.m_State)
            return;
          this.m_State = value;
          Action onChanged = this.onChanged;
          if (onChanged == null)
            return;
          onChanged();
        }
      }

      public UIInputAction.Transform transform => this.m_Transform;

      public UIInputAction.ProcessAs processAs => this.m_ProcessAs;

      public ActionState(
        ProxyAction action,
        string name,
        DisplayNameOverride displayName = null,
        UIInputAction.ProcessAs processAs = UIInputAction.ProcessAs.AutoDetect,
        UIInputAction.Transform transform = UIInputAction.Transform.None)
      {
        this.m_Action = action ?? throw new ArgumentNullException(nameof (action));
        this.m_Name = name ?? throw new ArgumentNullException(nameof (name));
        this.m_Barrier = new Barrier(this.m_Name, action);
        this.m_NameOverride = displayName;
        this.m_ProcessAs = processAs;
        this.m_Transform = transform;
        this.m_Action.onShouldBeEnabledChanged += new Action<bool>(this.OnShouldBeEnabledChanged);
        this.UpdateState();
      }

      public void Dispose()
      {
        if (this.m_Disposed)
          return;
        this.m_Disposed = true;
        this.m_Barrier?.Dispose();
        this.m_NameOverride?.Dispose();
        this.m_Action.onShouldBeEnabledChanged -= new Action<bool>(this.OnShouldBeEnabledChanged);
      }

      private void OnShouldBeEnabledChanged(bool value) => this.UpdateState();

      public void UpdateState()
      {
        if (!this.m_Action.shouldBeEnabled)
          this.state = InputActionBindings.ActionState.State.Disabled;
        else if (this.m_Priority == -1)
          this.state = InputActionBindings.ActionState.State.DisabledNoConsumer;
        else if (!this.m_Action.isSet)
          this.state = InputActionBindings.ActionState.State.DisabledNotSet;
        else
          this.state = InputActionBindings.ActionState.State.Enabled;
      }

      public int CompareTo(InputActionBindings.ActionState other)
      {
        return -this.m_Priority.CompareTo(other.m_Priority);
      }

      public void ResolveConflicts(InputActionBindings.ActionState other)
      {
        switch (this.state)
        {
          case InputActionBindings.ActionState.State.Enabled:
            if (!ProxyAction.CanConflict(this.action, other.action))
            {
              if (this.transform != other.transform && (this.transform & other.transform) == UIInputAction.Transform.None)
                break;
              this.state = InputActionBindings.ActionState.State.DisabledDuplicate;
              break;
            }
            if (!Game.Input.InputManager.HasConflicts(this.action, other.action))
              break;
            this.state = InputActionBindings.ActionState.State.DisabledConflict;
            break;
          case InputActionBindings.ActionState.State.Disabled:
          case InputActionBindings.ActionState.State.DisabledNoConsumer:
          case InputActionBindings.ActionState.State.DisabledNotSet:
          case InputActionBindings.ActionState.State.DisabledConflict:
            if (this.action != other.action)
              break;
            this.state = InputActionBindings.ActionState.State.DisabledDuplicate;
            break;
        }
      }

      public void Apply()
      {
        if (this.m_Disposed)
          return;
        switch (this.state)
        {
          case InputActionBindings.ActionState.State.Enabled:
            if (this.m_Action.isBuiltIn && !this.m_Action.shouldBeEnabled)
              this.m_Action.enabled = true;
            this.m_Barrier.blocked = false;
            if (this.m_NameOverride == null)
              break;
            this.m_NameOverride.shouldBeActive = true;
            break;
          case InputActionBindings.ActionState.State.Disabled:
          case InputActionBindings.ActionState.State.DisabledNoConsumer:
          case InputActionBindings.ActionState.State.DisabledNotSet:
          case InputActionBindings.ActionState.State.DisabledConflict:
            this.m_Barrier.blocked = true;
            if (this.m_NameOverride == null)
              break;
            this.m_NameOverride.shouldBeActive = false;
            break;
          case InputActionBindings.ActionState.State.DisabledDuplicate:
            this.m_Barrier.blocked = false;
            if (this.m_NameOverride == null)
              break;
            this.m_NameOverride.shouldBeActive = false;
            break;
        }
      }

      public override string ToString()
      {
        return string.Format("{0} ({1})", (object) this.m_Name, (object) this.m_Action);
      }

      public enum State
      {
        Enabled,
        Disabled,
        DisabledNoConsumer,
        DisabledNotSet,
        DisabledConflict,
        DisabledDuplicate,
      }
    }

    private interface IEventTrigger : IDisposable
    {
      HashSet<InputActionBindings.ActionState> states { get; }

      static InputActionBindings.IEventTrigger GetTrigger(
        InputActionBindings parent,
        ProxyAction action,
        UIInputAction.ProcessAs processAs)
      {
        switch (action.sourceAction.expectedControlType)
        {
          case "Dpad":
          case "Stick":
          case "Vector2":
            InputActionBindings.IEventTrigger trigger1;
            switch (processAs)
            {
              case UIInputAction.ProcessAs.Button:
                trigger1 = (InputActionBindings.IEventTrigger) new InputActionBindings.Vector2ToButtonEventTrigger(parent, action);
                break;
              case UIInputAction.ProcessAs.Axis:
                trigger1 = (InputActionBindings.IEventTrigger) new InputActionBindings.Vector2ToAxisEventTrigger(parent, action);
                break;
              case UIInputAction.ProcessAs.Vector2:
                trigger1 = (InputActionBindings.IEventTrigger) new InputActionBindings.Vector2EventTrigger(parent, action);
                break;
              default:
                trigger1 = (InputActionBindings.IEventTrigger) new InputActionBindings.Vector2EventTrigger(parent, action);
                break;
            }
            return trigger1;
          case "Axis":
            InputActionBindings.IEventTrigger trigger2;
            switch (processAs)
            {
              case UIInputAction.ProcessAs.Button:
                trigger2 = (InputActionBindings.IEventTrigger) new InputActionBindings.AxisToButtonEventTrigger(parent, action);
                break;
              case UIInputAction.ProcessAs.Axis:
                trigger2 = (InputActionBindings.IEventTrigger) new InputActionBindings.AxisEventTrigger(parent, action);
                break;
              case UIInputAction.ProcessAs.Vector2:
                trigger2 = (InputActionBindings.IEventTrigger) new InputActionBindings.AxisToVector2EventTrigger(parent, action);
                break;
              default:
                trigger2 = (InputActionBindings.IEventTrigger) new InputActionBindings.AxisEventTrigger(parent, action);
                break;
            }
            return trigger2;
          case "Button":
            InputActionBindings.IEventTrigger trigger3;
            switch (processAs)
            {
              case UIInputAction.ProcessAs.Button:
                trigger3 = (InputActionBindings.IEventTrigger) new InputActionBindings.ButtonEventTrigger(parent, action);
                break;
              case UIInputAction.ProcessAs.Axis:
                trigger3 = (InputActionBindings.IEventTrigger) new InputActionBindings.ButtonToAxisEventTrigger(parent, action);
                break;
              case UIInputAction.ProcessAs.Vector2:
                trigger3 = (InputActionBindings.IEventTrigger) new InputActionBindings.ButtonToVector2EventTrigger(parent, action);
                break;
              default:
                trigger3 = (InputActionBindings.IEventTrigger) new InputActionBindings.ButtonEventTrigger(parent, action);
                break;
            }
            return trigger3;
          default:
            return (InputActionBindings.IEventTrigger) new InputActionBindings.DefaultEventTrigget(parent, action);
        }
      }
    }

    private abstract class EventTrigger<TRawValue, TValue> : 
      InputActionBindings.IEventTrigger,
      IDisposable
      where TRawValue : struct
      where TValue : struct
    {
      private bool m_Disposed;
      private readonly InputActionBindings m_Parent;
      private readonly ProxyAction m_Action;
      private readonly IWriter<TValue> m_ValueWriter;

      public HashSet<InputActionBindings.ActionState> states { get; } = new HashSet<InputActionBindings.ActionState>();

      public EventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<TValue> valueWriter = null)
      {
        this.m_Parent = parent;
        this.m_Action = action ?? throw new ArgumentNullException(nameof (action));
        this.m_ValueWriter = valueWriter ?? ValueWriters.Create<TValue>();
        this.m_Action.onInteraction += new Action<ProxyAction, InputActionPhase>(this.OnInteraction);
      }

      private void OnInteraction(ProxyAction _, InputActionPhase phase)
      {
        if (this.m_Disposed)
          return;
        switch (phase)
        {
          case InputActionPhase.Performed:
            if (!this.m_Parent.m_ActionPerformedBinding.active)
              break;
            this.TriggerEvent(this.m_Parent.m_ActionPerformedBinding);
            break;
          case InputActionPhase.Canceled:
            if (this.m_Action.sourceAction.type != InputActionType.PassThrough || !this.m_Parent.m_ActionReleasedBinding.active)
              break;
            this.TriggerEvent(this.m_Parent.m_ActionReleasedBinding);
            break;
        }
      }

      private void TriggerEvent(RawEventBinding binding)
      {
        TRawValue rawValue = this.m_Action.ReadValue<TRawValue>();
        foreach (InputActionBindings.ActionState state in this.states)
        {
          if (state.state == InputActionBindings.ActionState.State.Enabled)
          {
            TValue obj = this.TransformValue(rawValue, state.transform);
            if ((double) this.GetMagnitude(obj) != 0.0)
            {
              IJsonWriter writer = binding.EventBegin();
              writer.TypeBegin("input.InputActionEvent");
              writer.PropertyName("action");
              writer.Write(state.name);
              writer.PropertyName("value");
              this.m_ValueWriter.Write(writer, obj);
              writer.TypeEnd();
              binding.EventEnd();
            }
          }
        }
      }

      protected abstract TValue TransformValue(TRawValue value, UIInputAction.Transform transform);

      protected abstract float GetMagnitude(TValue value);

      public void Dispose()
      {
        if (this.m_Disposed)
          return;
        this.m_Disposed = true;
        this.states.Clear();
        this.m_Action.onInteraction -= new Action<ProxyAction, InputActionPhase>(this.OnInteraction);
      }
    }

    private class DefaultEventTrigget : InputActionBindings.EventTrigger<float, float>
    {
      public DefaultEventTrigget(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(float value, UIInputAction.Transform transform)
      {
        return value;
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class ButtonEventTrigger : InputActionBindings.EventTrigger<float, float>
    {
      public ButtonEventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(float value, UIInputAction.Transform transform)
      {
        return Mathf.Clamp(value, 0.0f, 1f);
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class AxisEventTrigger : InputActionBindings.EventTrigger<float, float>
    {
      public AxisEventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(float value, UIInputAction.Transform transform)
      {
        return value;
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class Vector2EventTrigger : InputActionBindings.EventTrigger<Vector2, Vector2>
    {
      public Vector2EventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<Vector2> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override Vector2 TransformValue(Vector2 value, UIInputAction.Transform transform)
      {
        return value;
      }

      protected override float GetMagnitude(Vector2 value) => value.magnitude;
    }

    private class AxisToButtonEventTrigger : InputActionBindings.EventTrigger<float, float>
    {
      public AxisToButtonEventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(float value, UIInputAction.Transform transform)
      {
        float num;
        switch (transform)
        {
          case UIInputAction.Transform.Negative:
            num = Mathf.Clamp(-value, 0.0f, 1f);
            break;
          case UIInputAction.Transform.Positive:
            num = Mathf.Clamp(value, 0.0f, 1f);
            break;
          default:
            num = Mathf.Abs(value);
            break;
        }
        return num;
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class Vector2ToButtonEventTrigger : InputActionBindings.EventTrigger<Vector2, float>
    {
      public Vector2ToButtonEventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(Vector2 value, UIInputAction.Transform transform)
      {
        float num;
        switch (transform)
        {
          case UIInputAction.Transform.Down:
            num = Mathf.Clamp(-value.y, 0.0f, 1f);
            break;
          case UIInputAction.Transform.Up:
            num = Mathf.Clamp(value.y, 0.0f, 1f);
            break;
          case UIInputAction.Transform.Vertical:
            num = Mathf.Abs(value.y);
            break;
          case UIInputAction.Transform.Left:
            num = Mathf.Clamp(-value.x, 0.0f, 1f);
            break;
          case UIInputAction.Transform.Right:
            num = Mathf.Clamp(value.x, 0.0f, 1f);
            break;
          case UIInputAction.Transform.Horizontal:
            num = Mathf.Abs(value.x);
            break;
          default:
            num = value.magnitude;
            break;
        }
        return num;
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class ButtonToAxisEventTrigger : InputActionBindings.EventTrigger<float, float>
    {
      public ButtonToAxisEventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(float value, UIInputAction.Transform transform)
      {
        float num;
        switch (transform)
        {
          case UIInputAction.Transform.Down:
            num = -value;
            break;
          case UIInputAction.Transform.Up:
            num = value;
            break;
          case UIInputAction.Transform.Left:
            num = -value;
            break;
          case UIInputAction.Transform.Negative:
            num = -value;
            break;
          case UIInputAction.Transform.Right:
            num = value;
            break;
          case UIInputAction.Transform.Positive:
            num = value;
            break;
          default:
            num = value;
            break;
        }
        return num;
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class Vector2ToAxisEventTrigger : InputActionBindings.EventTrigger<Vector2, float>
    {
      public Vector2ToAxisEventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<float> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override float TransformValue(Vector2 value, UIInputAction.Transform transform)
      {
        float num;
        switch (transform)
        {
          case UIInputAction.Transform.Vertical:
            num = value.y;
            break;
          case UIInputAction.Transform.Horizontal:
            num = value.x;
            break;
          default:
            num = value.magnitude;
            break;
        }
        return num;
      }

      protected override float GetMagnitude(float value) => Mathf.Abs(value);
    }

    private class ButtonToVector2EventTrigger : InputActionBindings.EventTrigger<float, Vector2>
    {
      public ButtonToVector2EventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<Vector2> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override Vector2 TransformValue(float value, UIInputAction.Transform transform)
      {
        Vector2 vector2;
        switch (transform)
        {
          case UIInputAction.Transform.Down:
            vector2 = new Vector2(0.0f, -value);
            break;
          case UIInputAction.Transform.Up:
            vector2 = new Vector2(0.0f, value);
            break;
          case UIInputAction.Transform.Left:
            vector2 = new Vector2(-value, 0.0f);
            break;
          case UIInputAction.Transform.Right:
            vector2 = new Vector2(value, 0.0f);
            break;
          default:
            vector2 = new Vector2(value, value);
            break;
        }
        return vector2;
      }

      protected override float GetMagnitude(Vector2 value) => value.magnitude;
    }

    private class AxisToVector2EventTrigger : InputActionBindings.EventTrigger<float, Vector2>
    {
      public AxisToVector2EventTrigger(
        InputActionBindings parent,
        ProxyAction action,
        IWriter<Vector2> valueWriter = null)
        : base(parent, action, valueWriter)
      {
      }

      protected override Vector2 TransformValue(float value, UIInputAction.Transform transform)
      {
        Vector2 vector2;
        switch (transform)
        {
          case UIInputAction.Transform.Vertical:
            vector2 = new Vector2(0.0f, value);
            break;
          case UIInputAction.Transform.Horizontal:
            vector2 = new Vector2(value, 0.0f);
            break;
          default:
            vector2 = Vector2.zero;
            break;
        }
        return vector2;
      }

      protected override float GetMagnitude(Vector2 value) => value.magnitude;
    }
  }
}

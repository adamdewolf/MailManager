// Decompiled with JetBrains decompiler
// Type: Game.Input.UIInputAction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Input
{
  [CreateAssetMenu(menuName = "Colossal/UI/UIInputAction")]
  public class UIInputAction : ScriptableObject
  {
    public string m_AliasName;
    [Tooltip("Start 10\nSelect 15\nA 20\nX 30\nY 40\nB 50\nDpad 55\nLB/RB 60")]
    public int m_DisplayPriority = -1;
    public InputActionReference m_Action;
    public InputActionReference m_LinkedAction;
    public UIInputAction.ProcessAs m_ProcessAs;
    public UIInputAction.Transform m_Transform;
    public InputManager.DeviceType m_Mask = InputManager.DeviceType.All;
    public bool m_ShowInOptions;
    public OptionGroupOverride m_OptionGroupOverride;

    public UIInputAction.State GetState(string source)
    {
      ProxyAction action = InputManager.instance.FindAction(this.m_Action.action);
      DisplayNameOverride displayName = new DisplayNameOverride(source, action, this.m_AliasName, this.m_DisplayPriority, this.m_Transform);
      return new UIInputAction.State(action, displayName, this.m_Mask);
    }

    public ProxyAction GetProxyAction() => InputManager.instance.FindAction(this.m_Action.action);

    public bool TryGetProxyAction(out ProxyAction action)
    {
      return InputManager.instance.TryFindAction(this.m_Action.action, out action);
    }

    public DisplayNameOverride GetDisplayName(string source)
    {
      return new DisplayNameOverride(source, this.GetProxyAction(), this.m_AliasName, this.m_DisplayPriority, this.m_Transform);
    }

    public class State
    {
      private readonly ProxyAction m_Action;
      private readonly DisplayNameOverride m_DisplayName;
      private readonly InputManager.DeviceType m_Mask;

      public ProxyAction action => this.m_Action;

      public DisplayNameOverride displayName => this.m_DisplayName;

      public State(
        ProxyAction action,
        DisplayNameOverride displayName,
        InputManager.DeviceType mask)
      {
        this.m_Action = action;
        this.m_DisplayName = displayName;
        this.m_Mask = mask;
      }

      public bool enabled
      {
        get => this.m_Action.enabled;
        set
        {
          this.m_Action.enabled = value;
          this.m_Action.mask = value ? this.m_Mask : InputManager.DeviceType.All;
          this.m_DisplayName.shouldBeActive = value;
        }
      }
    }

    public enum ProcessAs
    {
      AutoDetect,
      Button,
      Axis,
      Vector2,
    }

    [Flags]
    public enum Transform
    {
      None = 0,
      Down = 1,
      Up = 2,
      Left = 4,
      Right = 8,
      Negative = Left | Down, // 0x00000005
      Positive = Right | Up, // 0x0000000A
      Vertical = Up | Down, // 0x00000003
      Horizontal = Right | Left, // 0x0000000C
      Press = Horizontal | Vertical, // 0x0000000F
    }
  }
}

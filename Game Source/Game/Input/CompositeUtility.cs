// Decompiled with JetBrains decompiler
// Type: Game.Input.CompositeUtility
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;
using System.Collections.Generic;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Input
{
  public static class CompositeUtility
  {
    public static unsafe T ReadValue<T>(
      ref InputBindingCompositeContext context,
      int button,
      bool allowModifiers,
      int modifier,
      IComparer<T> comparer)
      where T : struct
    {
      return context.m_State != null && CompositeUtility.CheckModifiers(ref context, allowModifiers, modifier) ? context.m_State.ReadCompositePartValue<T, IComparer<T>>(context.m_BindingIndex, button, (bool*) null, out int _, comparer) : default (T);
    }

    public static bool ReadValueAsButton(
      ref InputBindingCompositeContext context,
      int button,
      bool allowModifiers,
      int modifier)
    {
      return context.m_State != null && CompositeUtility.CheckModifiers(ref context, allowModifiers, modifier) && context.ReadValueAsButton(button);
    }

    public static bool CheckModifiers(
      ref InputBindingCompositeContext context,
      bool allowModifiers,
      int modifier)
    {
      float f = !allowModifiers || modifier == 0 ? 1f : context.ReadValue<float, ModifiersComparer>(modifier);
      return !float.IsNaN(f) && (double) f != 0.0;
    }

    public static ActionType GetActionType(this ActionComponent component)
    {
      switch (component)
      {
        case ActionComponent.Press:
          return ActionType.Button;
        case ActionComponent.Negative:
          return ActionType.Axis;
        case ActionComponent.Positive:
          return ActionType.Axis;
        case ActionComponent.Down:
          return ActionType.Vector2;
        case ActionComponent.Up:
          return ActionType.Vector2;
        case ActionComponent.Left:
          return ActionType.Vector2;
        case ActionComponent.Right:
          return ActionType.Vector2;
        default:
          throw new ArgumentOutOfRangeException(nameof (component), (object) component, (string) null);
      }
    }

    public static Type GetCompositeType(this ActionType actionType)
    {
      switch (actionType)
      {
        case ActionType.Button:
          return typeof (ButtonWithModifiersComposite);
        case ActionType.Axis:
          return typeof (AxisSeparatedWithModifiersComposite);
        case ActionType.Vector2:
          return typeof (Vector2SeparatedWithModifiersComposite);
        default:
          throw new ArgumentOutOfRangeException(nameof (actionType), (object) actionType, (string) null);
      }
    }

    public static InputActionType GetInputActionType(this ActionType actionType)
    {
      switch (actionType)
      {
        case ActionType.Button:
          return InputActionType.Button;
        case ActionType.Axis:
          return InputActionType.Value;
        case ActionType.Vector2:
          return InputActionType.Value;
        default:
          throw new ArgumentOutOfRangeException(nameof (actionType), (object) actionType, (string) null);
      }
    }

    public static string GetExpectedControlLayout(this ActionType actionType)
    {
      switch (actionType)
      {
        case ActionType.Button:
          return "Button";
        case ActionType.Axis:
          return "Axis";
        case ActionType.Vector2:
          return "Vector2";
        default:
          throw new ArgumentOutOfRangeException(nameof (actionType), (object) actionType, (string) null);
      }
    }
  }
}

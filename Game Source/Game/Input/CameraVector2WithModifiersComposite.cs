﻿// Decompiled with JetBrains decompiler
// Type: Game.Input.CameraVector2WithModifiersComposite
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Layouts;
using UnityEngine.InputSystem.Utilities;

#nullable disable
namespace Game.Input
{
  [DisplayStringFormat("{binding}")]
  [DisplayName("CO Camera Vector 2D With Modifiers")]
  public class CameraVector2WithModifiersComposite : AnalogValueInputBindingComposite<Vector2>
  {
    private const string kName = "Camera2DVectorWithModifiers";
    public bool m_ModifierActuatesControl;
    [InputControl(layout = "Vector2")]
    public int vector;
    [InputControl(layout = "Button")]
    public int trigger;

    public override string typeName => "Camera2DVectorWithModifiers";

    public override Vector2 ReadValue(ref InputBindingCompositeContext context)
    {
      if (this.m_IsDummy)
        return new Vector2();
      if (this.m_Mode == Mode.Analog)
        return CompositeUtility.ReadValue<Vector2>(ref context, this.vector, true, this.trigger, (IComparer<Vector2>) AnalogValueInputBindingComposite<Vector2>.Vector2Comparer.instance);
      return !CompositeUtility.ReadValueAsButton(ref context, this.vector, true, this.trigger) ? Vector2.zero : Vector2.one;
    }

    public override float EvaluateMagnitude(ref InputBindingCompositeContext context)
    {
      if (!CompositeUtility.CheckModifiers(ref context, true, this.trigger))
        return 0.0f;
      if (this.m_ModifierActuatesControl && this.trigger != 0)
      {
        float f = context.ReadValue<float, ModifiersComparer>(this.trigger);
        if (!float.IsNaN(f) && (double) f != 0.0)
          return -1f;
      }
      return context.EvaluateMagnitude(this.vector);
    }

    static CameraVector2WithModifiersComposite()
    {
      InputManager.RegisterBindingComposite<CameraVector2WithModifiersComposite>("Camera2DVectorWithModifiers", ActionType.Button, new InputManager.CompositeComponentData[1]
      {
        new InputManager.CompositeComponentData(ActionComponent.Press, nameof (trigger), string.Empty)
      });
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
    }
  }
}
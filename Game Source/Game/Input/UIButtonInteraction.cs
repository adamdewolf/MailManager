﻿// Decompiled with JetBrains decompiler
// Type: Game.Input.UIButtonInteraction
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Input
{
  public class UIButtonInteraction : IInputInteraction
  {
    public float repeatDelay = 0.5f;
    public float repeatRate = 0.1f;
    public float pressPoint;

    private float pressPointOrDefault
    {
      get
      {
        return (double) this.pressPoint <= 0.0 ? UnityEngine.InputSystem.InputSystem.settings.defaultButtonPressPoint : this.pressPoint;
      }
    }

    public void Process(ref InputInteractionContext context)
    {
      switch (context.phase)
      {
        case InputActionPhase.Waiting:
          if (!context.ControlIsActuated(this.pressPointOrDefault))
            break;
          context.Started();
          context.PerformedAndStayStarted();
          context.SetTimeout(this.repeatDelay);
          break;
        case InputActionPhase.Started:
          if (context.timerHasExpired)
          {
            context.PerformedAndStayStarted();
            context.SetTimeout(this.repeatRate);
            break;
          }
          if (context.ControlIsActuated(this.pressPointOrDefault))
            break;
          context.Canceled();
          break;
      }
    }

    public void Reset()
    {
    }

    static UIButtonInteraction() => UnityEngine.InputSystem.InputSystem.RegisterInteraction<UIButtonInteraction>();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Init()
    {
    }
  }
}
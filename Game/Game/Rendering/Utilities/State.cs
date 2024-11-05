// Decompiled with JetBrains decompiler
// Type: Game.Rendering.Utilities.State
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using System;

#nullable disable
namespace Game.Rendering.Utilities
{
  public abstract class State
  {
    private StateMachine _machine;

    public StateMachine machine
    {
      get => this._machine;
      set
      {
        this._machine = this._machine == null ? value : throw new Exception("property is read only after first set");
      }
    }

    public virtual void TransitionIn()
    {
    }

    public virtual State.Result Update() => State.Result.Continue;

    public virtual void LateUpdate()
    {
    }

    public virtual void TransitionOut() => this._machine = (StateMachine) null;

    public string Name { get; set; }

    public enum ResultType
    {
      Continue,
      Stop,
      Transition,
    }

    public struct Result
    {
      public State.ResultType type;
      public State next;

      public bool isContinue => this.type == State.ResultType.Continue;

      public bool isStop => this.type == State.ResultType.Stop;

      public bool isTransition => this.type == State.ResultType.Transition;

      public static State.Result Continue
      {
        get
        {
          return new State.Result()
          {
            type = State.ResultType.Continue,
            next = (State) null
          };
        }
      }

      public static State.Result Stop
      {
        get
        {
          return new State.Result()
          {
            type = State.ResultType.Stop,
            next = (State) null
          };
        }
      }

      public static State.Result TransitionTo(State state)
      {
        return new State.Result()
        {
          type = State.ResultType.Transition,
          next = state
        };
      }
    }
  }
}

// Decompiled with JetBrains decompiler
// Type: Game.Input.ScrollSensitivityProcessor
// Assembly: Game, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9DBFD0F8-0F1C-47CD-A752-F580C9797E08
// Assembly location: G:\SteamLibrary\steamapps\common\Cities Skylines II\Cities2_Data\Managed\Game.dll

using Game.Settings;
using UnityEngine;
using UnityEngine.InputSystem;

#nullable disable
namespace Game.Input
{
  public class ScrollSensitivityProcessor : InputProcessor<float>
  {
    public override float Process(float value, InputControl control)
    {
      return value * SharedSettings.instance.input.finalScrollSensitivity;
    }

    static ScrollSensitivityProcessor() => ScrollSensitivityProcessor.Initialize();

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    private static void Initialize() => UnityEngine.InputSystem.InputSystem.RegisterProcessor<ScrollSensitivityProcessor>();
  }
}
